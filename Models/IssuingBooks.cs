using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace labka2.Models
{
    public class IssuingBooks
    {
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Книга")]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Читач")]
        public int ReaderId { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Дата видачі")]
        public DateTime DateofIssue { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Даа повернення")]
        public DateTime DateofReturn { get; set; }
        [Display(Name = "Книга")]
        public virtual Book Book { get; set; }
        [Display(Name = "Читач")]
        public virtual Reader Reader { get; set; }
    }
}