using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VideoPoker.Model
{
    public enum Role { HighCards, OnePair, TwoPair, ThreeofAKind, Straight, Flush, FullHouse, FourofAKind, StraightFlush };
    public enum Strength { Strong, Same, Weak };
        
    /// <summary>
    /// ディーラー
    /// </summary>
    /// <remarks>
    /// ディーラーは１名である為、シングルトンパターンを適用
    /// </remarks>
    [DataContract]
    public class DealerModel : SerializableModel
    {
        [IgnoreDataMember]
        private DeckModel _Deck;
        [IgnoreDataMember]
        public DeckModel Deck { get { return _Deck; } set { _Deck = value; RaisePropertyChanged("Deck"); } }

        [IgnoreDataMember]
        private string _Player1Result;
        [DataMember]
        public string Player1Result { get { return _Player1Result; } set { _Player1Result = value; RaisePropertyChanged("Player1Result"); } }
        [IgnoreDataMember]
        private string _Player2Result;
        [DataMember]
        public string Player2Result { get { return _Player2Result; } set { _Player2Result = value; RaisePropertyChanged("Player2Result"); } }

        [IgnoreDataMember]
        public bool IsGameset { get { return Player1Result != null; } }

        [IgnoreDataMember]
        private static DealerModel _Singletone = Deserialize<DealerModel>() ?? new DealerModel();
        [IgnoreDataMember]
        public static DealerModel Current { get { return _Singletone; } }
        

        public DealerModel()
        {
            Init();
        }

        ~DealerModel()
        {
            Serialize();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Deck = DeckModel.Current;
        }

        private void Init()
        {
            Deck = DeckModel.Current;
        }

        public void Reset()
        {
            Deck.Reset();
            Player1Result = null;
            Player2Result = null;
        }

        public CardModel Pass()
        {
            // 山札をからカードを１枚渡す
            var card = Deck.CardModels.First();
            Deck.CardModels.Remove(card);
            return card;
        }

        public IEnumerable<CardModel> Pass(int count)
        {
            // 山札からカードをn枚渡す
            var cards = Deck.CardModels.Take(count).ToList();
            foreach (var v in cards) Deck.CardModels.Remove(v);
            return cards;
        }

        public Role GetRole(IEnumerable<CardModel> cards)
        {
            Role result = Role.HighCards;

            var numbers = cards.Select(v => v.Number);
            var marks = cards.Select(v => v.Mark);
            var groups = numbers.GroupBy(v => v);  
            var isSameMark = marks.Distinct().Count() == 1;     // 全て同じマークかの特徴を表す
            var groupsCount = groups.Count();                   // 同じ数がいくつ存在するかの特徴を表す

            switch(groupsCount) {
                case 5:// StraightFlush or Straight or Flush or HighCards
                    var straightNums = numbers.Select(v => v == CardNumber.Ace && numbers.Contains(CardNumber.Two) ? -1 : (int)v);
                    if (straightNums.Sum() == Enumerable.Range(straightNums.Min(), 5).Sum()) {
                        // 連続している
                        if(isSameMark) 
                            result = Role.StraightFlush;
                        else 
                            result = Role.Straight;
                    } else if(isSameMark) {
                        result = Role.Flush;
                    } else {
                        result = Role.HighCards;
                    }
                    break;

                case 4: // OnePair
                    result = Role.OnePair;
                    break;
                case 3: // ThreeofAKind or TwoPair
                    if(groups.Select(v => v.Count()).Max() == 3)
                        result = Role.ThreeofAKind;
                    else
                        result = Role.TwoPair;
                    break;
                case 2: // FourofAKind or FullHouse
                    if(groups.Select(v => v.Count()).Max() == 4)
                        result = Role.FourofAKind;
                    else
                        result = Role.FullHouse;
                    break;
            }
            return result;
        }

        public Strength Judge(IEnumerable<CardModel> lhs, IEnumerable<CardModel> rhs)
        {
            var rolel = GetRole(lhs);
            var roler = GetRole(rhs);
            return Judge(lhs, rolel, rhs, roler);
        }

        public Strength Judge(IEnumerable<CardModel> lhs, Role rolel, IEnumerable<CardModel> rhs, Role roler)
        {
            Strength result;

            if (rolel > roler) {
                result = Strength.Strong;
            } else if (rolel == roler) {
                switch (rolel) {
                    case Role.StraightFlush:
                    case Role.Straight:
                        // 最大の値で比較する、ただし [Five, Four, Three, Two, Ace] の組み合わせはAceが入っているが最弱とする
                        var numbersl = lhs.Select(v => v.Number);
                        var numbersr = rhs.Select(v => v.Number);
                        Func<CardNumber, IEnumerable<CardNumber>, int> toNativeNumber =
                            (x, xs) => x == CardNumber.Ace && xs.Contains(CardNumber.Two) ? -1 : (int)x;
                        var maxl = lhs.Select(v => v.Number).Select(v => toNativeNumber(v, numbersl)).Max();
                        var maxr = rhs.Select(v => v.Number).Select(v => toNativeNumber(v, numbersr)).Max();
                        if (maxl > maxr)
                            result = Strength.Strong;
                        else if (maxl == maxr)
                            result = Strength.Same;
                        else
                            result = Strength.Weak;
                        break;
                    default:
                        // 数字の組を降順並び替え、その数字を射影
                        var ls = lhs.GroupBy(v => v).OrderBy(v => v.Count()).OrderByDescending(v => v.Key).Select(v => v.First());
                        var rs = rhs.GroupBy(v => v).OrderBy(v => v.Count()).OrderByDescending(v => v.Key).Select(v => v.First()).ToArray();
                        // カードが異なった以降をインデックスを付加して取得
                        var differents = ls.Select((v, i) => new { Index = i, Card = v }).SkipWhile(v => v.Card == rs[v.Index]);

                        if (!differents.Any()) {
                            result = Strength.Same;
                        } else {
                            var cmpTarget = differents.First();
                            if (cmpTarget.Card > rs[cmpTarget.Index])
                                result = Strength.Strong;
                            else
                                result = Strength.Weak;
                        }
                        break;
                }
            } else {
                result = Strength.Weak;
            }
            return result;
        }
    }
}
