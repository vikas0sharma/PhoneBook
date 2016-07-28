using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IContactServices
    {
        ContactEntity GetContactById(int contactId);
        IEnumerable<ContactEntity> GetAllContacts();
        int AddContact(ContactEntity contactEnity);
        bool UpdateContact(int contactId, ContactEntity contactEntity);
        bool DeleteContact(int contactId);
    }
}
