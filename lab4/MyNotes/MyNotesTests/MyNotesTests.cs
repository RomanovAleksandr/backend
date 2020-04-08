using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotes.Data.Repositories;
using System.Collections.Generic;
using MyNotes.Data.Models;
using System.Linq;
using System.IO;
using System.Text;

namespace MyNotesTests
{
    [TestClass]
    public class NotesRepositoryTest
    {
        NotesRepository notesRepository;
        string storagePath = "../../../Notes.txt";

        [TestInitialize]
        public void Initalize()
        {
            NotesRepository.SetStoragePath(storagePath);
            notesRepository = new NotesRepository();
        }

        private void ClearNotesFile()
        {
            File.WriteAllText(storagePath, string.Empty);
        }

        [TestMethod]
        public void GetNotesFromEmptyFile()
        {
            ClearNotesFile();
            List<Note> notesList = (List<Note>)notesRepository.GetAll();
            Assert.IsFalse(notesList.Any());
        }

        [TestMethod]
        public void AddNoteAndGetAll()
        {
            ClearNotesFile();
            string message = "some text";
            notesRepository.Add(new Note { message = message });
            List<Note> notesList = (List<Note>)notesRepository.GetAll();
            Assert.IsTrue(notesList.Any());
            Assert.AreEqual(notesList[0].message, message);
        }
    }
}
