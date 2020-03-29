using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanks.Tests
{
    [TestClass]
    public class RemoveExtraBlanks
    {
        [TestMethod]
        public void Remove_duplicate_spaces_and_tabs_in_empty_string()
        {
            string str = "";
            string expectedStr = "";
            string res = Program.RemoveExtraBlanks(str);
            Assert.AreEqual(expectedStr, res);
        }

        [TestMethod]
        public void Remove_duplicate_spaces_and_tabs()
        {
            string str = "\t ������    �  \t\t  ��������� � ���������� ";
            string expectedStr = "������ � ��������� � ����������";
            string res = Program.RemoveExtraBlanks(str);
            Assert.AreEqual(expectedStr, res);
        }
    }
}
