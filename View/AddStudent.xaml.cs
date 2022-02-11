using Demo2022.Model;
using Demo2022.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Demo2022.View
{
    // <summary>
    /// AddStudent.xaml 的交互逻辑
    /// </summary>
    public partial class AddStudent : Window
    {
        private ViewModel.Demo2022ViewModel viewModel;
        public AddStudent(ObservableCollection<StudentInfo> StudentList)
        {
            InitializeComponent();
            this.DataContext = new Demo2022ViewModel();
            //刷新表格
            viewModel = DataContext as ViewModel.Demo2022ViewModel;
            this.viewModel.StudentList = StudentList;
        }
    }
}
