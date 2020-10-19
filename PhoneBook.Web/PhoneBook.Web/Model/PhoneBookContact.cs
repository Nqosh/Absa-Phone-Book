using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Model
{
    public class PhoneBookContact : IModel
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
    }
}
