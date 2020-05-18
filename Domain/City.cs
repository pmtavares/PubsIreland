using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="City's name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string County { get; set; }

        //public ICollection<Pub> Pubs { get; set; }
    }
}