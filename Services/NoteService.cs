using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NoteApp.Models;

namespace NoteApp.Services
{
    public class NoteService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteService(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _notes = database.GetCollection<Note>("Notes");
        }

        public List<Note> GetAll() => _notes.Find(_ => true).ToList();
        public Note GetById(string id) => _notes.Find(n => n.Id == id).FirstOrDefault();
        public void Create(Note note)
        {
            note.CreatedAt = DateTime.Now;
            _notes.InsertOne(note);
        }
        public void Update(string id, Note updatedNote) =>
            _notes.ReplaceOne(note => note.Id == id, updatedNote);
        public void Delete(string id) =>
            _notes.DeleteOne(note => note.Id == id);
    }
}

