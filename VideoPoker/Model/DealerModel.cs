using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VideoPoker.Model
{
    /// <summary>
    /// ディーラー
    /// </summary>
    /// <remarks>
    /// ディーラーは１名である為、シングルトンパターンを適用
    /// </remarks>
    [DataContract]
    public class DealerModel : SerializableModel
    {
        public enum Role { HighCards, OnePair, TwoPair, ThreeofAKind, Straight, Flush, FullHouse, FourofAKind, StraightFlush };
        public enum Strength { Strong, Same, Weak};
        
        [IgnoreDataMember]
        private DeckModel _Deck;
        [IgnoreDataMember]
        public DeckModel Deck { get { return _Deck; } set { _Deck = value; RaisePropertyChanged("Deck"); } }

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
                    var straightNums = numbers.Select(v => v == CardModel.CardNumber.Ace && numbers.Contains(CardModel.CardNumber.Two) ? -1 : (int)v);
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
            throw new NotImplementedException();
            Strength result;
            var rolel = GetRole(lhs);
            var roler = GetRole(rhs);

            if (rolel > roler) {
                result = Strength.Strong;
            } else if (rolel == roler) {
                CardModel.CardNumber numberl;
                CardModel.CardNumber numberr;

                switch (rolel) {
                    case Role.StraightFlush:
                    case Role.Straight:
                        break;
                }
            } else {
                result = Strength.Weak;
            }
        }
    }
}
