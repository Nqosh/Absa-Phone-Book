using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Model
{
    public class Entry
    {

        public int Id { get; set; }
        public string EntryType { get; set; }
        public string PhoneNumber { get; set; }
    }
}
