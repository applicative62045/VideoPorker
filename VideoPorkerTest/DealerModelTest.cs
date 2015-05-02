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
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Seven},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Eight},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
            };

            var fourofAKind = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Seven},
            };

            var fullHouse = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Seven},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Seven},
            };

            var flush = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Ten},
            };

            var straight = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Three},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Six},
            };

            var threeofAKind = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Seven},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Ace},
            };

            var twoPair = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Eight},
            };

            var OnePair = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Eight},
            };

            var highCards = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Eight},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Two},
            };

            var straightFlushRandomOrder = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Seven},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Eight},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
            };

            var straightFlushWeak = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Three},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ace},
            };

            Assert.IsTrue(Dealer.GetRole(straightFlush) == Role.StraightFlush);
            Assert.IsTrue(Dealer.GetRole(fourofAKind) == Role.FourofAKind);
            Assert.IsTrue(Dealer.GetRole(fullHouse) == Role.FullHouse);
            Assert.IsTrue(Dealer.GetRole(flush) == Role.Flush);
            Assert.IsTrue(Dealer.GetRole(straight) == Role.Straight);
            Assert.IsTrue(Dealer.GetRole(threeofAKind) == Role.ThreeofAKind);
            Assert.IsTrue(Dealer.GetRole(twoPair) == Role.TwoPair);
            Assert.IsTrue(Dealer.GetRole(OnePair) == Role.OnePair);
            Assert.IsTrue(Dealer.GetRole(highCards) == Role.HighCards);

            Assert.IsTrue(Dealer.GetRole(straightFlushRandomOrder) == Role.StraightFlush);
            Assert.IsTrue(Dealer.GetRole(straightFlushWeak) == Role.StraightFlush);
        }

        [TestMethod]
        public void Judge()
        {
            var straightFlush = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Seven},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Eight},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
            };

            var fourofAKind = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Seven},
            };

            var fullHouse = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Seven},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Seven},
            };

            var flush = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Ten},
            };

            var straight = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Three},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Six},
            };

            var threeofAKind = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Seven},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Ace},
            };

            var twoPair = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Eight},
            };

            var OnePair = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Nine},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Heart, Number = CardNumber.Eight},
            };

            var highCards = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ten},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Eight},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Dia, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Two},
            };

            Assert.IsTrue(Dealer.Judge(straightFlush, straightFlush) == Strength.Same);
            Assert.IsTrue(Dealer.Judge(straightFlush, fourofAKind) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, fullHouse) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, flush) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, threeofAKind) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, twoPair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, OnePair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(straightFlush, highCards) == Strength.Strong);

            Assert.IsTrue(Dealer.Judge(fourofAKind, straightFlush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(fourofAKind, fourofAKind) == Strength.Same);
            Assert.IsTrue(Dealer.Judge(fourofAKind, fullHouse) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, flush) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, threeofAKind) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, twoPair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, OnePair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fourofAKind, highCards) == Strength.Strong);

            Assert.IsTrue(Dealer.Judge(fullHouse, straightFlush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(fullHouse, fourofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(fullHouse, fullHouse) == Strength.Same);
            Assert.IsTrue(Dealer.Judge(fullHouse, flush) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fullHouse, threeofAKind) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fullHouse, twoPair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fullHouse, OnePair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(fullHouse, highCards) == Strength.Strong);

            Assert.IsTrue(Dealer.Judge(flush, straightFlush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(flush, fourofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(flush, fullHouse) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(flush, flush) == Strength.Same);
            Assert.IsTrue(Dealer.Judge(flush, threeofAKind) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(flush, twoPair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(flush, OnePair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(flush, highCards) == Strength.Strong);

            Assert.IsTrue(Dealer.Judge(threeofAKind, straightFlush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(threeofAKind, fourofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(threeofAKind, fullHouse) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(threeofAKind, flush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(threeofAKind, threeofAKind) == Strength.Same);
            Assert.IsTrue(Dealer.Judge(threeofAKind, twoPair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(threeofAKind, OnePair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(threeofAKind, highCards) == Strength.Strong);

            Assert.IsTrue(Dealer.Judge(twoPair, straightFlush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, fourofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, fullHouse) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, flush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, threeofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(twoPair, twoPair) == Strength.Same);
            Assert.IsTrue(Dealer.Judge(twoPair, OnePair) == Strength.Strong);
            Assert.IsTrue(Dealer.Judge(twoPair, highCards) == Strength.Strong);

            Assert.IsTrue(Dealer.Judge(OnePair, straightFlush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, fourofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, fullHouse) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, flush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, threeofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, twoPair) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(OnePair, OnePair) == Strength.Same);
            Assert.IsTrue(Dealer.Judge(OnePair, highCards) == Strength.Strong);

            Assert.IsTrue(Dealer.Judge(highCards, straightFlush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, fourofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, fullHouse) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, flush) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, threeofAKind) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, twoPair) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, OnePair) == Strength.Weak);
            Assert.IsTrue(Dealer.Judge(highCards, highCards) == Strength.Same);

            var weakStraightFlush = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Three},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Two},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Ace},
            };
            Assert.IsTrue(Dealer.Judge(straightFlush, weakStraightFlush) == Strength.Strong);

            var sixStraightFlush = new List<CardModel>()
            {
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Six},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Five},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Four},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Three},
                new CardModel() {Mark = CardMark.Club, Number = CardNumber.Two},
            };
            Assert.IsTrue(Dealer.Judge(sixStraightFlush, weakStraightFlush) == Strength.Strong);
            
            var sixStraighFlush2 = new List<CardModel>()
            {
                sixStraightFlush[1],
                sixStraightFlush[2],
                sixStraightFlush[3],
                sixStraightFlush[4],
                sixStraightFlush[0],
            };
            Assert.IsTrue(Dealer.Judge(sixStraightFlush, sixStraighFlush2) == Strength.Same);
            
            var onePair2 = new List<CardModel>()
            {
                OnePair[2],
                OnePair[3],
                OnePair[0],
                OnePair[1],
                new CardModel() {Mark = CardMark.Spade, Number = CardNumber.Jack},
            };
            Assert.IsTrue(Dealer.Judge(OnePair, onePair2) == Strength.Weak);
        }
    }
}
