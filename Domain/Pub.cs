using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Pub
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(4000)]
        public string DescriptionDetailed { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }

        public DateTime DateFounded { get; set; }
        public DateTime DateAdded { get; set; }

        public string Username {get; set;}

        public DateTime LastActive { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
