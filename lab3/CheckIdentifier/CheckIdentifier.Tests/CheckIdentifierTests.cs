using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifier.Tests
{
    [TestClass]
    public class CheckIdentifier
    {
        [TestMethod]
        public void Empty_identifier()
        {
            bool res = Program.Check("");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Identifier_begin_with_number()
        {
            bool res = Program.Check("1abc");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Identifier_with_incorect_char()
        {
            bool res = Program.Check("abc.d");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Correct_identifier()
        {
            bool res = Program.Check("ab12cd2");
            Assert.IsTrue(res);
        }
    }
}
