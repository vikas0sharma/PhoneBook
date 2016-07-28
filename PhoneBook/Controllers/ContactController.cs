using Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneBook.Controllers
{
    public class ContactController : ApiController
    {

        private readonly IContactServices _contactServices;


        public ContactController()
        {
            _contactServices = new ContactServices();
        }

        // GET api/contact
        public HttpResponseMessage Get()
        {
            var contacts = _contactServices.GetAllContacts();
            if(contacts!=null)
            {
                var contactsEntities = contacts as List<ContactEntity> ?? contacts.ToList();
                if (contactsEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, contactsEntities);
                }

            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Contact not found!!");

        }

        // GET api/contact/5
        public HttpResponseMessage Get(int id)
        {
            var contact = _contactServices.GetContactById(id);
            if(contact!=null)
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No contact found for this id");

        }

        // POST api/contact
        public int Post([FromBody]ContactEntity contactEntity)
        {
            return _contactServices.AddContact(contactEntity);
        }

        // PUT api/contact/5
        public bool Put(int id, [FromBody]ContactEntity contactEntity)
        {
            if (id > 0)
            {
                return _contactServices.UpdateContact(id, contactEntity);
            }
            return false;
        }

        // DELETE api/contact/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _contactServices.DeleteContact(id);
            return false;
        }
    }
}
