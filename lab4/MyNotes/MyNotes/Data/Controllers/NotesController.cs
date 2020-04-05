using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNotes.Data.Interfaces;

namespace MyNotes.Data.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepositories _notesRepositories;

        public NotesController(INotesRepositories notesRepositories)
        {
            _notesRepositories = notesRepositories;
        }
    }
}
