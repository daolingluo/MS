﻿using demo.Common;
using Demo2022.Common;
using Demo2022.Model;
using Demo2022.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            try
            {
                UpdateStudent view = new UpdateStudent();
                StudentInfo student = new StudentInfo();
                student.Name = CurrentStudent.Name;
                student.Age = CurrentStudent.Age;
                student.Gender = CurrentStudent.Gender;
                student.TeamName = CurrentStudent.TeamName;
                student.Id = CurrentStudent.Id;
                bll.EditStudent(student);
                ToClose = true;
            }
            catch (Exception)
            {
                ToClose = (MessageBox.Show("修改失败，是否重新修改", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes);
            }
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
