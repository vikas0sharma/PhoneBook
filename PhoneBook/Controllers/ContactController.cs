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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/contact
        public void Post([FromBody]string value)
        {
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
        }
    }
}
