using DataModel.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataModel;
namespace Services
{
    public class ContactServices:IContactServices
    {

        private readonly UnitOfWork _unitOfWork;
        public ContactServices()
        {
            _unitOfWork = new UnitOfWork();
        }
        //public ContactEntity GetContactById(int contactId)
        //{
        //     var contact=_unitOfWork.ContactRepository.GetById(contactId);
        //     if (contact != null)
        //     {
        //         Mapper.CreateMap<Contact, ContactEntity>();
        //         var contactModel = Mapper.Map<Contact, ContactEntity>(contact);
        //         return contactModel;
 
        //     }
        //     return null;

        //}
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
    }
}
