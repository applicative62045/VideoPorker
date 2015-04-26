using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoPoker.Model;
using System.Collections.Generic;

namespace VideoPorkerTest
{
    [TestClass]
    public class DealerModelTest
    {
        private DealerModel Dealer;

        [TestInitialize]
        public void Initialize()
        {
            Dealer = DealerModel.Current;
        }

        [TestMethod]
        public void GetRole()
        {
            var straightFlush = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Seven},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Eight},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
            };

            var fourofAKind = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Seven},
            };

            var fullHouse = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Seven},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Seven},
            };

            var flush = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Ten},
            };

            var straight = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Three},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Six},
            };

            var threeofAKind = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Seven},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Ace},
            };

            var twoPair = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Eight},
            };

            var OnePair = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Eight},
            };

            var highCards = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Eight},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Two},
            };

            var straightFlushRandomOrder = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Seven},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Eight},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
            };

            var straightFlushWeak = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Three},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ace},
            };

            Assert.IsTrue(Dealer.GetRole(straightFlush) == DealerModel.Role.StraightFlush);
            Assert.IsTrue(Dealer.GetRole(fourofAKind) == DealerModel.Role.FourofAKind);
            Assert.IsTrue(Dealer.GetRole(fullHouse) == DealerModel.Role.FullHouse);
            Assert.IsTrue(Dealer.GetRole(flush) == DealerModel.Role.Flush);
            Assert.IsTrue(Dealer.GetRole(straight) == DealerModel.Role.Straight);
            Assert.IsTrue(Dealer.GetRole(threeofAKind) == DealerModel.Role.ThreeofAKind);
            Assert.IsTrue(Dealer.GetRole(twoPair) == DealerModel.Role.TwoPair);
            Assert.IsTrue(Dealer.GetRole(OnePair) == DealerModel.Role.OnePair);
            Assert.IsTrue(Dealer.GetRole(highCards) == DealerModel.Role.HighCards);

            Assert.IsTrue(Dealer.GetRole(straightFlushRandomOrder) == DealerModel.Role.StraightFlush);
            Assert.IsTrue(Dealer.GetRole(straightFlushWeak) == DealerModel.Role.StraightFlush);
        }

        [TestMethod]
        public void Judge()
        {
            var straightFlush = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Seven},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Eight},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
            };

            var fourofAKind = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Seven},
            };

            var fullHouse = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Seven},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Seven},
            };

            var flush = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Ten},
            };

            var straight = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Three},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Six},
            };

            var threeofAKind = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Seven},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Ace},
            };

            var twoPair = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Eight},
            };

            var OnePair = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Nine},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Heart, Number = CardModel.CardNumber.Eight},
            };

            var highCards = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ten},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Eight},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Dia, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Two},
            };

            Assert.IsTrue(Dealer.Judge(straightFlush, straightFlush) == DealerModel.Strength.Same);
            Assert.IsTrue(Dealer.Judge(straightFlush, fourofAKind) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, fullHouse) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, flush) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, threeofAKind) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, twoPair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, OnePair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, highCards) == DealerModel.Strength.Strong);

            Assert.IsTrue(Dealer.Judge(fourofAKind, straightFlush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(fourofAKind, fourofAKind) == DealerModel.Strength.Same);
            Assert.IsTrue(Dealer.Judge(fourofAKind, fullHouse) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, flush) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, threeofAKind) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, twoPair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, OnePair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, highCards) == DealerModel.Strength.Strong);

            Assert.IsTrue(Dealer.Judge(fullHouse, straightFlush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(fullHouse, fourofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(fullHouse, fullHouse) == DealerModel.Strength.Same);
            Assert.IsTrue(Dealer.Judge(fullHouse, flush) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fullHouse, threeofAKind) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fullHouse, twoPair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fullHouse, OnePair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fullHouse, highCards) == DealerModel.Strength.Strong);

            Assert.IsTrue(Dealer.Judge(flush, straightFlush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(flush, fourofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(flush, fullHouse) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(flush, flush) == DealerModel.Strength.Same);
            Assert.IsTrue(Dealer.Judge(flush, threeofAKind) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(flush, twoPair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(flush, OnePair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(flush, highCards) == DealerModel.Strength.Strong);

            Assert.IsTrue(Dealer.Judge(threeofAKind, straightFlush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(threeofAKind, fourofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(threeofAKind, fullHouse) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(threeofAKind, flush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(threeofAKind, threeofAKind) == DealerModel.Strength.Same);
            Assert.IsTrue(Dealer.Judge(threeofAKind, twoPair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(threeofAKind, OnePair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(threeofAKind, highCards) == DealerModel.Strength.Strong);

            Assert.IsTrue(Dealer.Judge(twoPair, straightFlush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, fourofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, fullHouse) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, flush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, threeofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, twoPair) == DealerModel.Strength.Same);
            Assert.IsTrue(Dealer.Judge(twoPair, OnePair) == DealerModel.Strength.Strong);
            Assert.IsTrue(Dealer.Judge(twoPair, highCards) == DealerModel.Strength.Strong);

            Assert.IsTrue(Dealer.Judge(OnePair, straightFlush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, fourofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, fullHouse) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, flush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, threeofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, twoPair) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, OnePair) == DealerModel.Strength.Same);
            Assert.IsTrue(Dealer.Judge(OnePair, highCards) == DealerModel.Strength.Strong);

            Assert.IsTrue(Dealer.Judge(highCards, straightFlush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, fourofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, fullHouse) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, flush) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, threeofAKind) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, twoPair) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, OnePair) == DealerModel.Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, highCards) == DealerModel.Strength.Same);

            var weakStraightFlush = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Three},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Two},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Ace},
            };
            Assert.IsTrue(Dealer.Judge(straightFlush, weakStraightFlush) == DealerModel.Strength.Strong);

            var sixStraightFlush = new List<CardModel>()
            {
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Six},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Five},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Four},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Three},
                new CardModel() {Mark = CardModel.CardMark.Club, Number = CardModel.CardNumber.Two},
            };
            Assert.IsTrue(Dealer.Judge(sixStraightFlush, weakStraightFlush) == DealerModel.Strength.Strong);
            
            var sixStraighFlush2 = new List<CardModel>()
            {
                sixStraightFlush[1],
                sixStraightFlush[2],
                sixStraightFlush[3],
                sixStraightFlush[4],
                sixStraightFlush[0],
            };
            Assert.IsTrue(Dealer.Judge(sixStraightFlush, sixStraighFlush2) == DealerModel.Strength.Same);
            
            var onePair2 = new List<CardModel>()
            {
                OnePair[2],
                OnePair[3],
                OnePair[0],
                OnePair[1],
                new CardModel() {Mark = CardModel.CardMark.Spade, Number = CardModel.CardNumber.Jack},
            };
            Assert.IsTrue(Dealer.Judge(OnePair, onePair2) == DealerModel.Strength.Weak);
        }
    }
}
