using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    CatName = model.Name

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(
                        e =>
                        new CategoryListItem
                        {
                            CatId = e.CatId,
                            Name = e.CatName
                        });
                return query.ToArray();
            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CatId == id);
                return new CategoryDetail()
                {
                    CatId = entity.CatId,
                    Name = entity.CatName,
                    Notes = entity.Note
                            .Select(e => new NoteListItem()
                            {
                                NoteId = e.Note.NoteId,
                                Title = e.Note.Title,
                                CreateUtc = e.Note.CreatedUtc

                            }).ToList()

                };

            }
        }

    }
}
