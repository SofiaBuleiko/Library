using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace labka2.Models
{
    public class Authorships
    {
        [Display(Name = "Книга")]
        public int BookId { get; set; }
        [Display(Name = "Автор")]
        public int LecturerId { get; set; }
        public int Id { get; set; }
        [Display(Name = "Книга")]
        public virtual Book Book { get; set; }
        [Display(Name = "Автор")]
        public virtual Lecturer Lecturer { get; set; }
    }
}