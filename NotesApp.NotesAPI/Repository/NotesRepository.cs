using Microsoft.EntityFrameworkCore;
using NotesApp.Data.Models;
using NotesApp.NotesAPI.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApp.NotesAPI.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesContext dbContext;

        public NotesRepository(NotesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task  CreateAsync(Note note)
        {
            this.dbContext.Notes.Add(note);
            await this.dbContext.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var note = await  GetNoteById(id);
            this.dbContext.Remove(note);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Note> GetNoteById(int id)
        {
            var note = await this.dbContext.Notes.FindAsync(id);

            return note;
        }

        public async Task<IEnumerable<Note>> GetNotesByUserId(string id)
        {
            IEnumerable<Note> notes =  await this.dbContext.Notes.Where(x => x.UserId == id).ToListAsync();

            return notes;
        }

        public IEnumerable<Note> Search(string searchText, string id)
        {
            IEnumerable<Note> result = Enumerable.Empty<Note>();

            if (!string.IsNullOrEmpty(searchText))
            {
                result = this.dbContext.Notes.Where(n => n.Title.Contains(searchText) && n.UserId == id);
            }

            return result;
        }

        public async Task UpdateAsync(Note note)
        {
            this.dbContext.Entry(note).State = EntityState.Modified;
            await this.dbContext.SaveChangesAsync();
        } 
    }
}
