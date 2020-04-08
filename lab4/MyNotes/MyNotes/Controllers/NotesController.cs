using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNotes.Data.Interfaces;
using System.IO;
using MyNotes.Data.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MyNotes.Data.Repositories;
using System.Text;

namespace MyNotes.Data.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepositories _notesRepository;

        public NotesController(INotesRepositories notesRepository)
        {
            _notesRepository = notesRepository;
            NotesRepository.SetStoragePath("Storage/Notes.txt");
        }

        [HttpGet]
        [Route("notes/list")]
        public ViewResult List()
        {
            var note = _notesRepository.GetAll();
            return View(note);
        }

        [HttpPost]
        [Route("note/add")]
        public async Task<OkResult> AddAsync()
        {
            string body = await new StreamReader(Request.Body, Encoding.UTF8).ReadToEndAsync();
            Note note = new Note() { message = body };
            _notesRepository.Add(note);
            return Ok();
        }
    }
}
