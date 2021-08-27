using FinalProject.Data;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class NoteService
    {
        private readonly Guid _userId;	
        public NoteService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateNote(NoteCreate model)
        {
            var entity = new Note()
            {
                OwnerId = _userId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };
	
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                  .Notes
                  .Where(e => e.OwnerId == _userId)
                  .Select(
                        e => new GameListItem
                        {
                             NoteId = e.NoteId,
                             Title = e.Title,
                             CreatedUtc = e.CreatedUtc
                         }
                   );
                   return query.ToArray();
            }
        }

        public GameDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
            var entity = ctx
                .Notes
                .Single(e => e.NoteId == id && e.OwnerId == _userId);
	             return
            new GameDetail
                {
                    NoteId = entity.NoteId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public bool UpdateNote(GameEdit model)
	    {
	        using(var ctx = new ApplicationDbContext())
	        {
	            var entity = ctx
                 .Notes
	             .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);
	
                entity.Title = model.Title;
	            entity.Content = model.Content;
	            entity.ModifiedUtc = DateTimeOffset.UtcNow;
	
	            return ctx.SaveChanges() == 1;
	        }
        }

        public bool DeleteNote(int noteId)
	    {
	        using (var ctx = new ApplicationDbContext())
	        {
	            var entity = ctx
                 .Notes
	             .Single(e => e.NoteId == noteId && e.OwnerId == _userId);
	             ctx.Notes.Remove(entity);	
                 return ctx.SaveChanges() == 1;
            }
        }      
    }
}


