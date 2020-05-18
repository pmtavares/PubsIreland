using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class PubDtoForCreation
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionDetailed { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public string ImagePath { get; set; }

        public DateTime DateFounded { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
