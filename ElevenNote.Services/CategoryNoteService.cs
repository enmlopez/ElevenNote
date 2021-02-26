﻿using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryNoteService
    {
        private readonly Guid _userId;

        public CategoryNoteService(Guid UserId)
        {
            _userId = UserId;
        }

        public bool CreateCategoryNote (CategoryNoteCreate model)
        {
            var entity = new CategoryNote()
            {
                CategoryId = model.CategoryId,
                NoteId = model.NoteId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CategoryNotes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategoryNote(int noteId, int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CategoryNotes.SingleOrDefault(e => e.CategoryId == categoryId && e.NoteId == noteId);

                if (entity != null)
                {
                    ctx.CategoryNotes.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
    }
}
