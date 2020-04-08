using MyNotes.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNotes.Data.Models;
using System.IO;

namespace MyNotes.Data.Repositories
{
    public class NotesRepository : INotesRepositories
    {
        static string storagePath;
        public static void SetStoragePath(string path)
        {
            storagePath = path;
        }

        public IEnumerable<Note> GetAll()
        {
            StreamReader notesReader = new StreamReader(storagePath);
            List<Note> notesList = new List<Note>();

            string line;
            while ((line = notesReader.ReadLine()) != null)
            {
                notesList.Add(new Note { message = line });
            }

            notesReader.Close();

            return notesList;
        }

        public void Add(Note note)
        {
            StreamWriter notesWriter = new StreamWriter(storagePath, true);
            notesWriter.WriteLine(note.message);
            notesWriter.Close();
        }
    }
}
