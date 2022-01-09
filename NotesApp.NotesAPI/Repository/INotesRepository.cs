using NotesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApp.NotesAPI.Repository
{
    public interface INotesRepository
    {
        Task CreateAsync(Note note);

        Task<Note> GetNoteById(int id);

        Task<IEnumerable<Note>> GetNotesByUserId(string id);

        Task DeleteAsync(int id);

        Task UpdateAsync(Note note);

        IEnumerable<Note> Search(string searchText, string id);
    }
}
