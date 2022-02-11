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
        public string TeamName { get; set; }
    }
}
