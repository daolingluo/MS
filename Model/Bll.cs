using demo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2022.Model
{
    public class Bll
    {
        Dal dal = new Dal();

        /// <summary>
        /// 获取所有的学生信息
        /// </summary>
        /// <returns></returns>
        public List<StudentInfo> GetStudents()
        {
            return dal.GetStudents();
        }

        /// <summary>
        /// 多条件查询学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<StudentInfo> GetQueryStudents(StudentInfo student,TeamInfo teamInfo)
        {
            return dal.GetQueryStudents(student,teamInfo);
        }

        //下拉列表的内容
        public List<TeamInfo> TeamList()
        {
           return dal.TeamList();
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int Add(StudentInfo student)
        {
            return dal.Add(student);
        }

        /// <summary>
        /// 根据id获取学生实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentInfo GetStudentById(int id)
        {
            return dal.GetStudentById(id);
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteStudent(int id)
        {
            return dal.DeleteStudent(id);
        }

    }
}
