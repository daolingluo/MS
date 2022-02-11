using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2022.Model
{
    /// <summary>
    /// 班级信息表
    /// </summary>
    public class TeamInfo
    {
        /// <summary>
        /// 班级Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [Required]
        [StringLength(32)]
        public string TeamName { get; set; }

        /// <summary>
        /// 关联学生表，一对多关系
        /// </summary>
        public virtual ICollection<StudentInfo> StudentInfo { get; set; }

    }
}
