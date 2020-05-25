using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace labka2.Models
{
    public class Lecturer
    {
        public Lecturer()
        {
            Authorship = new List<Authorships>();

        }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Звання")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Аудиторія")]
        public int Audience { get; set; }
        public int Id { get; set; }

        [Display(Name = "Кафедра")]
        public int DepartmentId { get; set; }
        [Display(Name = "Кафедра")]
        public virtual Department department { get; set; }
        [Display(Name = "Автори")]
        public virtual ICollection<Authorships> Authorship { get; set; }

    }
}