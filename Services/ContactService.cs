using DataModel.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataModel;
using System.Transactions;

namespace Services
{
    public class ContactServices:IContactServices
    {

        private readonly UnitOfWork _unitOfWork;
        public ContactServices()
        {
            _unitOfWork = new UnitOfWork();
        }


        public ContactEntity GetContactById(int contactId)
        {
            var contact = _unitOfWork.ContactRepository.GetById(contactId);
            if (contact != null)
            {
                Mapper.CreateMap<Contact, ContactEntity>();
                var contactModel = Mapper.Map<Contact, ContactEntity>(contact);
                return contactModel;

            }
            return null;

        }
        public IEnumerable<ContactEntity> GetAllContacts()
        {
            var contacts = _unitOfWork.ContactRepository.GetAll().ToList();
            if (contacts.Any())
            {
                Mapper.CreateMap<Contact, ContactEntity>();
                var productsmodel = Mapper.Map<List<Contact>, List<ContactEntity>>(contacts);
                return productsmodel;
            }
            return null;
        }

        public int AddContact(ContactEntity contactEntity)
        {
            var contact = new Contact
            {
                ContactName = contactEntity.ContactName,
                MobileNo = contactEntity.MobileNo
            };
            using(var scope = new TransactionScope())
            {
               
                _unitOfWork.ContactRepository.Insert(contact);
                _unitOfWork.Save();
                scope.Complete();
            }
            return contact.ContactId;
        }

        public bool UpdateContact(int contactId, ContactEntity contactEntity)
        {
            bool success = false;
            if (contactEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var contact = _unitOfWork.ContactRepository.GetById(contactId);
                    if (contact != null)
                    {
                        contact.ContactName = contactEntity.ContactName;
                        contact.MobileNo = contactEntity.MobileNo;
                        _unitOfWork.ContactRepository.Update(contact);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteContact(int contactId)
        {
            bool success = false;
            if (contactId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var contact = _unitOfWork.ContactRepository.GetById(contactId);
                    if (contact != null)
                    {
                        _unitOfWork.ContactRepository.Delete(contact);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
 
        }

    }
}
