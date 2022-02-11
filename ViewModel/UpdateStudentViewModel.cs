using demo.Common;
using Demo2022.Common;
using Demo2022.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo2022.ViewModel
{
    public class UpdateStudentViewModel : NotiticationObject
    {
        public UpdateStudentViewModel()
        {
            SavaCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            StudentInfo student = new StudentInfo();
            student.Name = CurrentStudent.Name;
            student.Age = CurrentStudent.Age;
            student.Gender = CurrentStudent.Gender;
            student.TeamId = CurrentStudent.TeamId;
            student.Id = CurrentStudent.Id;
            bll.EditStudent(student);
            ToClose = true;

        }

        private StudentInfo _currentStudent;

        public StudentInfo CurrentStudent
        {
            get
            {
                return _currentStudent;
            }
            set
            {
                _currentStudent = value;
                this.RaisePropertyChanged("CurrentStudent");
            }
        }

        private bool toClose = false;
        /// <summary>
        /// 是否要关闭窗口
        /// </summary>
        public bool ToClose
        {
            get
            {
                return toClose;
            }
            set
            {
                toClose = value;
                //if (toClose)               
                this.RaisePropertyChanged("ToClose");
            }
        }

        public Bll bll { get; set; }

        public ICommand SavaCommand { get; set; }
    }
}
