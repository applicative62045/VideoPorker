using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VideoPoker.Model
{
    public enum CardNumber { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };   // 順序をカードの強さとする
    public enum CardMark { Spade, Heart, Dia, Club };

    /// <summary>
    /// カードモデル
    /// </summary>
    /// <remarks>
    /// 基本的なビデオポーカーで使用するカード定義を表したクラス。
    /// 等価演算や並び替えが出来るように IEquatable, IComparable, IComparerのジェネリック版を実装。
    /// 比較演算が出来るように各演算子をオーバーロード。
    /// </remarks>
    [DataContract]
    public class CardModel : BaseModel, IEquatable<CardModel>, IComparable<CardModel>, IComparer<CardModel>
    {
        [IgnoreDataMember]
        private CardMark _Mark;
        [DataMember]
        public CardMark Mark { get { return _Mark; } set { _Mark = value; RaisePropertyChanged("Mark"); } }

        [IgnoreDataMember]
        private CardNumber _Number;
        [DataMember]
        public CardNumber Number { get { return _Number; } set { _Number = value; RaisePropertyChanged("Number"); } }

        public override int GetHashCode()
        {
            return _Number.GetHashCode() << 4 | _Mark.GetHashCode();
        }

        #region 等価演算
        public static bool operator==(CardModel lhs, CardModel rhs)
        {
            // 値比較を行うように実装
            if (lhs as object == null && rhs as object == null) return true;
            else if (lhs as object == null && rhs as object != null) return false;
            else if (lhs as object != null && rhs as object == null) return false;
            else if (lhs.GetHashCode() != rhs.GetHashCode()) return false;
            else return lhs.Mark == rhs.Mark && lhs.Number == rhs.Number;
        }

        public static bool operator!=(CardModel lhs, CardModel rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            if (obj is CardModel)
                return this == obj as CardModel;
            else
                return false;
        }

        public bool Equals(CardModel other)
        {
            return this == other;
        }
        #endregion

        #region 比較演算
        public static bool operator>(CardModel lhs, CardModel rhs)
        {
            // 数値、マークの順で比較する、大小関係は列挙体の並び順に準ずる
            return lhs.Number > rhs.Number ? true : lhs.Number != rhs.Number ? false : lhs.Mark > rhs.Mark;
        }

        public static bool operator<(CardModel lhs, CardModel rhs)
        {
            return !(lhs > rhs);
        }

        public int Compare(CardModel x, CardModel y)
        {
            // 数値、マークの順で列挙体の並び順とする
            int cmp = x.Number.CompareTo(y.Number);
            if (cmp == 0) cmp = x.Mark.CompareTo(y.Mark);
            return cmp;
        }

        public int CompareTo(CardModel other)
        {
            return this.Compare(this, other);
        }
        #endregion

        public override string ToString()
        {
            return string.Format("[{0},{1}]", Mark, Number);
        }
    }
}
