using BeanSceneApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeanSceneApp.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            LinkedList<Contact> contacts = new LinkedList<Contact>();
            contacts.AddFirst(new Contact("123 Fake Street", "Faketown", "notreal@fakemail.com", "12345678"));
            contacts.AddLast(new Contact("1 First Avenue", "Metro City", "ckent@dailyplanet.com", "11943123"));
            contacts.AddLast(new Contact("2 Cassandra View", "Darktown", "casscain@oracle.com", "21211991"));
            contacts.AddLast(new Contact("21 Magic Lane", "Mas Vega", "zatannaz@magicmail.com", "00224375"));
            contacts.AddLast(new Contact("32 Astra Street", "Yao", "evelync@lyramail.com", "5555555"));
            return View(contacts);
        }
    }
}
