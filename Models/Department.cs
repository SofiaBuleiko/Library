using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace labka2.Models
{
    public class Department
    {
        public Department()
        {
            Lecturers = new List<Lecturer>();

        }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не може бути порожнім")]
        [Display(Name = "Сайт")]
        public string Site { get; set; }
        public int Id { get; set; }

        [Display(Name = "Викладачі")]
        public virtual ICollection<Lecturer> Lecturers { get; set; }
    }
}
