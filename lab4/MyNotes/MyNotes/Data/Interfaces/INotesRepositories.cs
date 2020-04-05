﻿using MyNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.Data.Interfaces
{
    public interface INotesRepositories
    {
        IEnumerable<Note> GetAll();
        void Add(Note note);
    }
}
