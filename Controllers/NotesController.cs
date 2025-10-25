using Microsoft.AspNetCore.Mvc;
using NoteApp.Models;
using NoteApp.Services;

namespace NoteApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly NoteService _noteService;

        public NotesController(NoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            var notes = _noteService.GetAll();
	    ViewData["NotesCount"] = notes.Count;
            return View(notes);
        }

        public IActionResult Details(string id)
        {
            var note = _noteService.GetById(id);
            if (note == null)
                return NotFound();

            return View(note);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _noteService.Create(note);
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        public IActionResult Edit(string id)
        {
            var note = _noteService.GetById(id);
            if (note == null)
                return NotFound();

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Note updatedNote)
        {
            if (id != updatedNote.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _noteService.Update(id, updatedNote);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedNote);
        }

        public IActionResult Delete(string id)
        {
            var note = _noteService.GetById(id);
            if (note == null)
                return NotFound();

            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _noteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

