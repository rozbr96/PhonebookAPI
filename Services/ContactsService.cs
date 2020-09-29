
using System.Collections.Generic;

using MongoDB.Driver;

using PhonesbookAPI.Models;


namespace PhonesbookAPI.Services {
  public class ContactsService {
    private readonly IMongoCollection<Contact> _contacts;

    public ContactsService() {
      var client = new MongoClient("mongodb://localhost:27017");
      var database = client.GetDatabase("phonebook");

      _contacts = database.GetCollection<Contact>("contacts");
    }

    public List<Contact> Get() => _contacts.Find(contact => true).ToList();

    public Contact Get(string id) => _contacts.Find<Contact>(contact => contact.Id == id).FirstOrDefault();

    public Contact Create(Contact contact) {
      _contacts.InsertOne(contact);

      return contact;
    }
  }
}
