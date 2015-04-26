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
    }
}
