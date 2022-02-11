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
        /// 多条件查询学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<StudentInfo> GetQueryStudents(StudentInfo student, string teamInfo,int PresentPage,string UpOrNext=null)
        {
            return dal.GetQueryStudents(student, teamInfo, PresentPage,UpOrNext);
        }

        //下拉列表的内容
        public List<TeamInfo> TeamList()
        {
            return dal.TeamList();
        }

        internal int GetPages()
        {
            return dal.GetPages();
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
        /// 添加班级
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddTeam(TeamInfo team)
        {
            return dal.AddTeam(team);
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

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int EditStudent(StudentInfo student)
        {
            return dal.EditStudent(student);
        }

    }
}
