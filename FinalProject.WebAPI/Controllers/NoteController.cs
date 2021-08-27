using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProject.Models;
using FinalProject.Services;
using Microsoft.AspNet.Identity;

namespace FinalProject.WebAPI.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        public IHttpActionResult Get()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }
        public IHttpActionResult Post(NoteCreate note)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var service = CreateNoteService();
    
        if (!service.CreateNote(note))
           return InternalServerError();
           return Ok();
        }
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }

        public IHttpActionResult Get(int id)
        {
        	    NoteService noteService = CreateNoteService();
        	    var note = noteService.GetNoteById(id);
        	    return Ok(note);
        }

        public IHttpActionResult Put(GameEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateNoteService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }

    }
}


