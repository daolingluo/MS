using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2022.Model
{
    public class StudentInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [StringLength(32)]
        public string TeamName { get; set; }

        public virtual TeamInfo TeamInfo { get; set; }
    }
}
