using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace labka2.Models
{
    public class Book
    {
        public Book()
        {
            Issuingbooks = new List<IssuingBooks>();
            Authorship = new List<Authorships>();
        }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Рік")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "К-сть сторінок")]
        public int Pages { get; set; }
        public int Id { get; set; }
        [Display(Name = "Видавництво")]
        public int PublishingHouseId { get; set; }
        [Display(Name = "Видавництво")]
        public virtual PublishingHouse PublishingHouse { get; set; }
        [Display(Name = "Видача книг")]
        public virtual ICollection<IssuingBooks> Issuingbooks { get; set; }
        [Display(Name = "Автори")]
        public virtual ICollection<Authorships> Authorship { get; set; }
    }
}