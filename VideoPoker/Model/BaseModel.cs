using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Input;

namespace VideoPoker.Model
{
    /// <summary>
    /// モデル抽象
    /// </summary>
    /// <remarks>
    /// 全てのモデルの基底クラス。
    /// MMVMの為に、通知機構基盤とコマンド作成機能を有する。
    /// </remarks>
    [DataContract]
    public abstract class BaseModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged impliments
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
