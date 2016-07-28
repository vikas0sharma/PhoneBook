using DataModel.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.UnitOfWork
{
    public class UnitOfWork:IDisposable
    {
        private PhoneBookDBEntities _context=null;
        private GenericRepository<Contact> _contactRepository;


        public UnitOfWork()
        {
            _context = new PhoneBookDBEntities();

        }

        public GenericRepository<Contact> ContactRepository 
        {
            get {
                if (this._contactRepository == null)
                {
                    this._contactRepository = new GenericRepository<Contact>(_context);
                }
                return this._contactRepository;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
 
            }
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
