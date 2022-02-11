using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2022.Model
{
    /// <summary>
    /// 学生信息表
    /// </summary>
    public class StudentInfo
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 学生性别
        /// </summary>
        [Required]
        public string Gender { get; set; }

        /// <summary>
        /// 学生班级
        /// </summary>
        [StringLength(32)]
        public string TeamName { get; set; }

        /// <summary>
        /// 关联班级表，一对一关系
        /// </summary>
        public virtual TeamInfo TeamInfo { get; set; }
    }
}
