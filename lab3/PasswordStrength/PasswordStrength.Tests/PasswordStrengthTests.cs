using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrength.Tests
{
    [TestClass]
    public class PasswordStrengt
    {
        [TestMethod]
        public void Strength_by_length()
        {
            int res = Program.StrengthByLength("abd12");
            Assert.AreEqual(20, res);

            res = Program.StrengthByLength("");
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void Strength_by_digits_count()
        {
            int res = Program.StrengthByDigitsCount("abd12");
            Assert.AreEqual(8, res);

            res = Program.StrengthByDigitsCount("abdcf");
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void Strength_by_upper_chars_count()
        {
            int res = Program.StrengthByUpperCharsCount("ABaa");
            Assert.AreEqual(4, res);

            res = Program.StrengthByUpperCharsCount("abdcf");
            Assert.AreEqual(10, res);
        }

        [TestMethod]
        public void Strength_by_lower_chars_count()
        {
            int res = Program.StrengthByLowerCharsCount("Aaa");
            Assert.AreEqual(2, res);

            res = Program.StrengthByLowerCharsCount("ABC");
            Assert.AreEqual(6, res);
        }

        [TestMethod]
        public void Strengt_iI_only_char()
        {
            int res = Program.StrengthIfOnlyChar("Aaa");
            Assert.AreEqual(-3, res);

            res = Program.StrengthIfOnlyChar("ab2");
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void Strengt_iI_only_digits()
        {
            int res = Program.StrengthIfOnlyDigits("12");
            Assert.AreEqual(-2, res);

            res = Program.StrengthIfOnlyDigits("ab2");
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void Strength_by_repeated_chars()
        {
            int res = Program.StrengthByRepeatedChars("aabccd");
            Assert.AreEqual(-4, res);

            res = Program.StrengthByRepeatedChars("ab2");
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void Strength_password()
        {
            int res = Program.CalcPasswordStrength("1");
            Assert.AreEqual(11, res);

            res = Program.CalcPasswordStrength("a");
            Assert.AreEqual(5, res);

            res = Program.CalcPasswordStrength("ab2dsrf3");
            Assert.AreEqual(60, res);
        }
    }
}
