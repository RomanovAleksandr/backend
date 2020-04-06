﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNotes.Data.Interfaces;
using System.IO;
using MyNotes.Data.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace MyNotes.Data.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesRepositories _notesRepositories;

        public NotesController(INotesRepositories notesRepositories)
        {
            _notesRepositories = notesRepositories;
        }

        [HttpGet]
        [Route("notes/list")]
        public ViewResult List()
        {
            var note = _notesRepositories.GetAll();
            return View(note);
        }


        [HttpPost]
        [Route("note/add")]
        public IActionResult Add()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();
                _notesRepositories.Add(new Note { message = body });
            }
            return Ok();
        }
    }
}