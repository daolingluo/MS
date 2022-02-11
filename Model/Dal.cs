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

        /// <summary>
        ///  多条件查询学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <param name="teamName"></param>
        /// <param name="UpOrNext"></param>
        /// <returns></returns>
        public List<StudentInfo> GetQueryStudents(StudentInfo student, string teamName, int PresentPage,string UpOrNext=null)
        {
            IQueryable<StudentInfo> students;
            List<StudentInfo> result = new List<StudentInfo>();

            //同时查询学生姓名和班级
            if (!string.IsNullOrEmpty(student.Name) && !string.IsNullOrEmpty(teamName))
            {
                students = entity.StudentInfo.Where(x => x.Name == student.Name && x.TeamName == teamName);
                result = students.AsNoTracking().ToList();
            }
            //查询学生的姓名
            else if (!string.IsNullOrEmpty(student.Name))
            {
                students = entity.StudentInfo.Where(x => x.Name == student.Name);
                result = students.AsNoTracking().ToList();
            }
            //查询学生的班级
            else if (!string.IsNullOrEmpty(teamName))
            {
                students = entity.StudentInfo.Where(x => x.TeamName == teamName);
                result = students.AsNoTracking().ToList();
            }
            //查询所有的学生信息
            else
            {
                result = entity.StudentInfo.AsNoTracking().ToList();
            }
            if (UpOrNext=="Up")
            {
                result = result.Skip((PresentPage-1) *5).Take(5).ToList();
            }
            if (UpOrNext=="Next")
            {
                result = result.Skip((PresentPage-1) * 5).Take(5).ToList();
            }
            return result.Take(5).ToList();
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        public int GetPages()
        {
            var pages = entity.StudentInfo.Count()/5+1;
            return pages;
        }

        //下拉列表的内容
        public List<TeamInfo> TeamList()
        {
            var TeamName = entity.TeamInfo.GroupBy(d => d.TeamName)
                                         .Select(d => d.FirstOrDefault())
                                        .ToList();
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
        /// 添加班级
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int AddTeam(TeamInfo team)
        {
            var temp = entity.TeamInfo.Where(x => x.TeamName == team.TeamName);
            //不存在则添加
            if (temp.Count() == 0)
            {
                entity.TeamInfo.Add(team);
                if (entity.SaveChanges() > 0)
                    return team.Id;
            }
            return -1;
        }

        /// <summary>
        /// 根据id获取学生实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentInfo GetStudentById(int id)
        {
            var student = entity.StudentInfo.Where(x => x.Id == id);
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
            if (s != null)
            {
                entity.StudentInfo.Remove(s);
                return entity.SaveChanges();
            }
            return -1;
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

