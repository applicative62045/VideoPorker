using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoPoker.Model;

namespace VideoPorkerTest
{
    /// <summary>
    /// CardModelTest の概要の説明
    /// </summary>
    [TestClass]
    public class CardModelTest
    {
        [TestMethod]
        public void NotEqualOperator()
        {
            CardModel card1 = new CardModel() { Mark = CardMark.Club, Number = CardNumber.Ace };
            CardModel card2 = new CardModel() { Mark = CardMark.Club, Number = CardNumber.Two };

            Assert.IsTrue(card1 != card2);
        }
    }
}
