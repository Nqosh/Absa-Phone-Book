using AutoMapper;
using PhoneBook.Web.DTO;
using PhoneBook.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PhoneBookContact, PhoneBookContactDto>();

        }
    }
}
