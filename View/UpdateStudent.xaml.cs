using Demo2022.ViewModel;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// UpdateStudent.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateStudent : Window
    {
        public UpdateStudent()
        {
            InitializeComponent();
            this.DataContext = new UpdateStudentViewModel();
        }
    }
}
