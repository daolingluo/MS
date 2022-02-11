using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Common
{
    //这是类型参数约束，where表名了对类型变量T的约束关系。
    //where T：FormatUtil表示类型变量是继承于FormatUtil的，
    //或者是FormatUtil本身。where T: new()指明了创建T的实例应该使用的构造函数。
    //.NET支持的类型参数约束
    //where T: new()  T必须要有一个无参构造函数
    /// <summary>
    /// 工具类，转化
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FormatUtil<T> where T : class, new()
    {
        public static ObservableCollection<T> GetObservableCollection(List<T> tList)
        {
            return new ObservableCollection<T>(tList);
        }
    }
}
