using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class PubDto
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionDetailed { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public string ImagePath { get; set; }

        public DateTime DateFounded { get; set; }

        public DateTime DateAdded { get; set; }

        public string Username { get; set; }
    }
}
