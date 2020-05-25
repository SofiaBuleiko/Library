using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace labka2.Models
{
    public class Reader
    {
        public Reader()
        {
            Issuingbooks = new List<IssuingBooks>();

        }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Студентський")]
        public int Studentid { get; set; }
        public int Id { get; set; }

        [Display(Name = "Видані книги")]
        public virtual ICollection<IssuingBooks> Issuingbooks { get; set; }
    }
}

