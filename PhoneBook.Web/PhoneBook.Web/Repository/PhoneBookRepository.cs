using Microsoft.EntityFrameworkCore;
using PhoneBook.Web.Data;
using PhoneBook.Web.DTO;
using PhoneBook.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Repository
{
    public class PhoneBookRepository : IPhoneBookRepository
    {

        private DataContext _context;

        public PhoneBookRepository(DataContext context)
        {
            _context = context;
        }

        public bool CheckifContactEntryExists(PhoneBookContactDto phoneBookContactDto)
        {

            var contact = _context.PhoneBookContacts.Include(x => x.Entries)
             .Where(x => x.Name == phoneBookContactDto.Name)
             .FirstOrDefault();

            List<Entry> entries = contact?.Entries.ToList() ?? new List<Entry>();

            return entries.Any(x => x.EntryType.ToLower() == phoneBookContactDto.EntryType.ToLower()
                                      && x.PhoneNumber.ToLower() == phoneBookContactDto.Number.ToLower());

        }

        public bool CheckifContactExists(string contactName)
        {
            return _context.PhoneBookContacts.Include(x => x.Entries)
                     .Any(x => x.Name == contactName);    
        }

        public bool DeleteContact(PhoneBookContactDto phoneBookContactDto)
        {
            var contact = _context.PhoneBookContacts
                .Where(x => x.Name.Equals(phoneBookContactDto.Name, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            _context.PhoneBookContacts.Remove(contact);
            _context.SaveChanges();
            return true;

        }

        public IList<PhoneBookContact> GetAllContacts()
        {
            return _context.PhoneBookContacts.Include(x => x.Entries).ToList();
        }

        public bool InsertContact(PhoneBookContactDto phoneBookContact)
        {
            _context.Add(new PhoneBookContact
            {
                Name = phoneBookContact.Name,
                Entries = new List<Entry>
                {
                    new Entry
                    {
                        PhoneNumber = phoneBookContact.Number,
                        EntryType = phoneBookContact.EntryType
                    }
                }
            });

            _context.SaveChanges();

            return true;
        }

        public bool UpdateContact(PhoneBookContactDto phoneBookContactDto)
        {
            var contact = _context.PhoneBookContacts.Where(x => x.Name.Equals(phoneBookContactDto.Name, StringComparison.OrdinalIgnoreCase))
               .FirstOrDefault();

            List<Entry> entries = contact?.Entries.ToList() ?? new List<Entry>();
            entries.Add(new Entry
            {
                PhoneNumber = phoneBookContactDto.Number,
                EntryType = phoneBookContactDto.EntryType
            });

            if (contact != null)
            {
                _context.Update(new PhoneBookContact
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Entries = entries
                });
            }
            _context.SaveChanges();

            return true;
        }
    }
}
