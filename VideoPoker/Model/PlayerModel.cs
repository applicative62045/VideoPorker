using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Input;

namespace VideoPoker.Model
{
    /// <summary>
    /// プレイヤーモデル
    /// </summary>
    [DataContract]
    public class PlayerModel : SerializableModel
    {
        [IgnoreDataMember]
        private ObservableCollection<CardModel> _CardModels;
        [DataMember]
        public ObservableCollection<CardModel> CardModels { get { return _CardModels; } set { _CardModels = value; RaisePropertyChanged("CardModels"); } }

        [IgnoreDataMember]
        private ObservableCollection<bool> _Holds;
        [DataMember]
        public ObservableCollection<bool> Holds { get { return _Holds; } set { _Holds = value; RaisePropertyChanged("Holds"); } }

        [IgnoreDataMember]
        private int _ChangeCount;
        [DataMember]
        public int ChangeCount { get { return _ChangeCount; } set { _ChangeCount = value; RaisePropertyChanged("ChangeCount"); } }


        public PlayerModel()
        {
            Init();
        }
        
        private void Init()
        {
            CardModels = new ObservableCollection<CardModel>(){ null, null, null, null, null };
            Holds = new ObservableCollection<bool>() { false, false, false, false, false };
            ChangeCount = 0;
        }

        public void Reset()
        {
            Init();
        }

        public void Change(int index, CardModel card, bool init = false)
        {
            CardModels[index] = card;
            RaisePropertyChanged("CardModels");
            if(!init) ChangeCount++;
        }
    }
}
