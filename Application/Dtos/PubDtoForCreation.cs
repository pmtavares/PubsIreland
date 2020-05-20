using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dtos
{
    public class PubDtoForCreation
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionDetailed { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public DateTime DateFounded { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage ="Password invalid" )]
        public string Password { get; set; }
    }
}
