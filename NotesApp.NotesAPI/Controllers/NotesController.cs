using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotesApp.Data.Models;
using NotesApp.NotesAPI.Repository;

namespace NotesApp.NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly INotesRepository notesRepository;

        public NotesController(INotesRepository notesRepository, 
                                ILogger<NotesController> logger)
        {
            this.notesRepository = notesRepository;
            this.logger = logger;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Note>> Create(Note note)
        { 
            await this.notesRepository.CreateAsync(note);

            
            return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var note = await this.notesRepository.GetNoteById(id);

            if (note == null)
            {
                return NotFound();
            }

            await this.notesRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{searchedText}/{id}")]
        public IEnumerable<Note> Search(string id, string searchedText = null)
        {
            IEnumerable<Note> result =  this.notesRepository.Search(searchedText, id); 

            return result;
        } 

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Note>> GetNoteById(int id)
        {
            var note =  await this.notesRepository.GetNoteById(id);

            if (note == null)
            {
                this.logger.LogWarning($"No result found for id - {id}."); 
                return NotFound();
            }

            return note;
        }

        [HttpGet("GetAllNotesforUser/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Note>>> GetNoteByUserId(string id)
        {
            var note = await this.notesRepository.GetNotesByUserId(id);

            if (note == null)
            {
                this.logger.LogWarning($"No result found for id - {id}.");
                return NotFound();
            }

            return note.ToList();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutNote(long id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            await this.notesRepository.UpdateAsync(note);

            return NoContent();
        }
    }
}
