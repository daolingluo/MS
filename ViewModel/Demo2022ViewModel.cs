using demo.Common;
using Demo2022.Model;
using Demo2022.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Demo2022.ViewModel
{
    public class Demo2022ViewModel : NotiticationObject
    {
        Bll bll = null;
        public Demo2022ViewModel()
        {
            bll= new Bll();
          Student= new StudentInfo();
            //datagrid数据
            StudentList = FormatUtil<StudentInfo>.GetObservableCollection(bll.GetStudents());
            //用于绑定和更新检索的内容
            QueryStudent = new StudentInfo();
            //班级下拉列表内容
            this.QueryTeamList = bll.TeamList();
        }
        private StudentInfo student;
        public StudentInfo Student
        {
            get
            {
                return student;
            }

            set
            {
                student = value;
                this.RaisePropertyChanged("Student");
            }
        }

        private ObservableCollection<StudentInfo> studentList;
        public ObservableCollection<StudentInfo> StudentList
        {
            get
            {
                return studentList;
            }
            set
            {
                studentList = value;
                this.RaisePropertyChanged("StudentList");
            }
        }

        private StudentInfo queryStudent;
        public StudentInfo QueryStudent
        {
            get
            {
                return queryStudent;
            }

            set
            {
                queryStudent = value;
                this.RaisePropertyChanged("QueryStudent");
            }
        }

        private TeamInfo queryTeamInfo;        
        public TeamInfo QueryTeamInfo
        {
            get
            {
                return queryTeamInfo;
            }

            set
            {
                queryTeamInfo = value;
                this.RaisePropertyChanged("QueryTeamInfo");
            }
        }

        private List<TeamInfo> queryTeamList;
        public List<TeamInfo> QueryTeamList
        {
            get
            {
                return queryTeamList;
            }

            set
            {
                queryTeamList = value;
                this.RaisePropertyChanged("QueryTeamList");
            }
        }

        private ICommand queryCommand;
        /// <summary>
        /// 查询按键的检索命令
        /// </summary>
        public ICommand QueryCommand
        {
            get
            {
                return new RelayCommand(() => QueryStudentList());
            }

            set
            {
                queryCommand = value;
            }
        }

        private BaseCommand addCommand;
        /// <summary>
        /// 显示学生添加的窗口
        /// </summary>
        public BaseCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new BaseCommand(new Action<object>(o =>
                    {
                        AddStudent add = new AddStudent(StudentList);
                        //AddStudent add = new AddStudent();
                        add.Show();
                    }));
                }
                return addCommand;
            }
        }


        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<AddStudent>((AddST) => AddStudents(AddST));
            }

            set
            {
                saveCommand = value;
            }
        }


        private void AddStudents(AddStudent view)
        {
            if (ValidationFields(view))
            {
                student.Name = view.Student_Name.Text;
                Student.Age = int.Parse(view.Student_Age.Text);
                Student.Gender = view.Student_Gender.Text;
                Student.TeamId = int.Parse(view.Student_Team.Text);
                var responseId = bll.Add(Student);
                if (responseId > 0)
                {
                    var students = bll.GetStudentById(responseId);
                    StudentList.Add(students);
                    MessageBox.Show("添加成功");
                    view.Close();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
        }

        private bool ValidationFields(AddStudent win)
        {
            if (string.IsNullOrWhiteSpace(win.Student_Name.Text))
            {
                MessageBox.Show("学生姓名不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(win.Student_Age.Text))
            {
                MessageBox.Show("学生年龄不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(win.Student_Gender.Text))
            {
                MessageBox.Show("学生性别不能为空！");
                return false;
            }
            if (string.IsNullOrWhiteSpace(win.Student_Team.Text))
            {
                MessageBox.Show("学生班级不能为空！");
                return false;
            }
            return true;
        }


        private RelayCommand<StudentInfo> deleteCommand;
        /// <summary>
        /// 删除学生的命令
        /// </summary>
        public RelayCommand<StudentInfo> DeleteCommand
        {
            get
            {
                if (null == deleteCommand)
                {
                    deleteCommand = new RelayCommand<StudentInfo>((student) => DeleteStudents(student));
                }
                return deleteCommand;
            }
        }
        private void DeleteStudents(StudentInfo student)
        {
            {
                MessageBoxResult confirmToDel = MessageBox.Show("确定要删除所选行吗？", "提示",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirmToDel == MessageBoxResult.Yes)
                {
                    var response = bll.DeleteStudent(student.Id);
                    if (response > 0)
                    {
                        MessageBox.Show("删除成功！");
                        StudentList = FormatUtil<StudentInfo>.GetObservableCollection(bll.GetStudents());
                    }
                }
            }
        }

        private void QueryStudentList()
        {
            StudentList = FormatUtil<StudentInfo>.GetObservableCollection(bll.GetQueryStudents(QueryStudent,QueryTeamInfo));
        }  
    }
}
