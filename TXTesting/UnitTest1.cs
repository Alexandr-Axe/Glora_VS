using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TXT;

namespace TXTesting
{
    [TestClass]
    public class TXTesting
    {
        IsText IT;
        public TXTesting()
        {
            IT = new IsText();
        }
        [TestMethod]
        public void IsTextEmpty()
        {
            string s = MainWindow.TextRTB;
            bool result = IT.ProhlizeTextIsTrueFalse(s);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsTextFound()
        {
            string a = MainWindow.TextRTB;
            string b = NajitText.textVOkne;
            bool result = IT.TextNalezenTrueFalse(a, b);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsTimeAdded()
        {
            string a = MainWindow.TextRTB;
            string b = MainWindow.NewRTB;
            bool result = IT.CasPridanTrueFalse(a, b);
            Assert.IsTrue(result);
        }
    }
}
