using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VideoPoker.Model
{
    /// <summary>
    /// 山札モデル
    /// </summary>
    /// <remarks>
    /// 山札はゲーム内で一つしか存在してはいけないのでシングルトンパターンを適用。
    /// </remarks>
    [DataContract]
    public class DeckModel : SerializableModel
    {
        [IgnoreDataMember]
        private ObservableCollection<CardModel> _CardModels;
        [DataMember]
        public ObservableCollection<CardModel> CardModels { get { return _CardModels; } set { _CardModels = value; RaisePropertyChanged("CardModels"); } }

        [IgnoreDataMember]
        private static DeckModel _Singleton = Deserialize<DeckModel>() ?? new DeckModel();
        [IgnoreDataMember]
        public static DeckModel Current { get { return _Singleton; } }

        private DeckModel()
        {
            Init();
        }

        ~DeckModel()
        {
            // インスタンスが解放される場合に設定を保存(シングルトンなのでアプリケーションの終了時)
            Serialize();
        }

        private void Init()
        {
            // 山札生成
            // ランダム値を予めペアにしたカードを生成し、ソートする
            int key;
            Random random =  new Random();
            Dictionary<int, CardModel> shuffle = new Dictionary<int, CardModel>();
            foreach (CardMark mark in Enum.GetValues(typeof(CardMark))) {
                foreach (CardNumber number in Enum.GetValues(typeof(CardNumber))) {
                    do {
                        key = random.Next(52);
                    } while(shuffle.ContainsKey(key));
                    shuffle.Add(key, new CardModel() { Mark = mark, Number = number });
                }
            }
            CardModels = new ObservableCollection<CardModel>(shuffle.OrderBy(v => v.Key).Select(v => v.Value));
        }

        public void Reset()
        {
            Init();
        }
    }
}
