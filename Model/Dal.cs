using demo.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo2022.Model
{
    public class Dal
    {
        Demo2022Entity entity = new Demo2022Entity();

        public List<StudentInfo> GetStudents()
        {
            var Students = from u in entity.StudentInfo
                           select u;
            //AsNoTracking() 无变动跟踪，提高EF查询性能
            //只能用于查询，不能用于其他赋值的操作，只做查询 ，不用做修改时可以用
            return Students.ToList();
        }

        /// <summary>
        /// 多条件查询学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<StudentInfo> GetQueryStudents(StudentInfo student, TeamInfo teamInfo)
        {
            IQueryable<StudentInfo> students;
            if (teamInfo == null)
            {
                MessageBox.Show("班级传参失败！");
                teamInfo = new TeamInfo();
            }
            //同时查询学生姓名和班级
            if (!string.IsNullOrEmpty(student.Name) && !string.IsNullOrEmpty(teamInfo.TeamName))
            {
                //var Team_Id = from a in entity.TeamInfo
                //              where a.TeamName == teamInfo.TeamName
                //              select a;
                //var b = Team_Id.First();

                students = from u in entity.StudentInfo
                           where u.Name == student.Name && u.TeamName == teamInfo.TeamName
                           select u;
                return students.AsNoTracking().ToList();
            }
            //查询学生的姓名
            else if (!string.IsNullOrEmpty(student.Name))
            {
                students = from u in entity.StudentInfo
                           where u.Name == student.Name
                           select u;
                return students.AsNoTracking().ToList();
            }
            //查询学生的班级
            else if (!string.IsNullOrEmpty(teamInfo.TeamName))
            {
                //var Team_Id = from a in entity.TeamInfo
                //              where a.TeamName == teamInfo.TeamName
                //              select a;
                //var b = Team_Id.First();

                students = from u in entity.StudentInfo
                               //from t in entity.TeamInfo
                           where u.TeamName == teamInfo.TeamName
                           select u;
                return students.AsNoTracking().ToList();
            }
            //查询所有的学生信息
            else
            {
                students = from u in entity.StudentInfo
                           select u;
                return students.AsNoTracking().ToList();
            }
        }

        //下拉列表的内容
        public List<TeamInfo> TeamList()
        {
            //List<TeamInfo> QueryTeamList = new List<TeamInfo>()
            //{

            //    new TeamInfo { TeamName = "1班" ,Id=1},
            //    new TeamInfo { TeamName = "2班" ,Id=2},
            //    new TeamInfo { TeamName = "3班", Id = 3 },
            //    new TeamInfo { TeamName = "4班", Id = 4 },
            //};
            //return QueryTeamList;
            var TeamName = from u in entity.TeamInfo
                           select u;
            List<TeamInfo> QueryTeamList = new List<TeamInfo>()
            {
                new TeamInfo { TeamName = "", Id = -1 },
            };
            foreach (var item in TeamName)
            {
                QueryTeamList.Add(item);
            }
            return QueryTeamList;
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int Add(StudentInfo student)
        {
            entity.StudentInfo.Add(student);
            if (entity.SaveChanges() > 0)
                return student.Id;
            else
                return 0;
        }

        /// <summary>
        /// 根据id获取学生实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentInfo GetStudentById(int id)
        {
            var student = from u in entity.StudentInfo
                          where u.Id == id
                          select u;
            return student.AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteStudent(int id)
        {
            StudentInfo s = entity.StudentInfo.Find(id);
            entity.StudentInfo.Remove(s);
            return entity.SaveChanges();
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int EditStudent(StudentInfo student)
        {
            var st = entity.StudentInfo.Find(student.Id);
            var entry = entity.Entry(st);
            entry.CurrentValues.SetValues(student);
            entry.Property(p => p.Id).IsModified = false;
            return entity.SaveChanges();
        }
    }
}

