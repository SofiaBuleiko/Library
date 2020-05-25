using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace labka2.Models
{
    public class PublishingHouse
    {
        public PublishingHouse()
        {
            Books = new List<Book>();

        }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Місто")]
        public string City { get; set; }
        public int Id { get; set; }



        public virtual ICollection<Book> Books { get; set; }

    }
}