using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator.Models;

namespace Translator.Tests
{
    [TestClass]
    public class TranslatorTests

    {
        Translator.Models.Dictionary dictionary = new Dictionary("../../../../Translator/Models/Dictionary.txt");

        [TestMethod]
        public void FindEngToRus()
        {
            string translated = dictionary.findTranslation("hello");
            Assert.AreEqual("привет", translated);
        }

        [TestMethod]
        public void FindRusToEng()
        {
            string translated = dictionary.findTranslation("привет");
            Assert.AreEqual("hello", translated);
        }

        [TestMethod]
        public void FindUndefinedWord()
        {
            string translated = dictionary.findTranslation("undefined");
            Assert.AreEqual(null, translated);
        }
    }
}
