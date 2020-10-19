using PhoneBook.Web.DTO;
using PhoneBook.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Repository
{
    public interface IPhoneBookRepository
    {
        bool CheckifContactExists(string contactName);
        bool UpdateContact(PhoneBookContactDto phoneBookContact);
        bool InsertContact(PhoneBookContactDto phoneBookContact);
        IList<PhoneBookContact> GetAllContacts();
        bool DeleteContact(PhoneBookContactDto phoneBookContactDto);
        bool CheckifContactEntryExists(PhoneBookContactDto phoneBookContactDto);

    }
}
