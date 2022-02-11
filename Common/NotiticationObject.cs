using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Common
{
    public class NotiticationObject : INotifyPropertyChanged, IDataErrorInfo
    {
        #region 数据验证
        public string this[string columnName]
        {
            get
            {
                var vc = new ValidationContext(this, null, null);
                vc.MemberName = columnName;
                var res = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().
                    GetProperty(columnName).GetValue(this, null), vc, res);
                if (res.Count > 0)
                {
                    return string.Join(Environment.NewLine, res.Select(r => r.ErrorMessage).ToArray());
                }
                return string.Empty;
            }
        }

        public string Error
        {
            get { return ""; }
        }

        /// <summary>
        /// 页面中是否所有控制数据验证正确
        /// </summary>
        public virtual bool IsValid { get; set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 发起通知
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public void RaisePropertyChanged(string propertyName)
        {
            //在属性改变不等于空的情况下才来监听
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
