using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2022.Model
{
    public class TeamInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string TeamName { get; set; }

        public virtual ICollection<StudentInfo> StudentInfo { get; set; }

    }
}
