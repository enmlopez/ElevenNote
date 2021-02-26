using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryService _categoryService = new CategoryService();

        [HttpPost]
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_categoryService.CreateCategory(category))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return Ok(category);
        }

        //[Http]
    }
}
