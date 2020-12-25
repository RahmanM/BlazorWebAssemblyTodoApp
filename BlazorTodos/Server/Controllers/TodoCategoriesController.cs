using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTodos.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoCategoriesController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoCategoriesController()
        {
            _context = new TodoContext();
        }

        // GET: api/TodoCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoCategory>>> GetTodoCategory()
        {
            return await _context.TodoCategories.ToListAsync();
        }

        // GET: api/TodoCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoCategory>> GetTodoCategory(int id)
        {
            var todoCategory = await _context.TodoCategories.FindAsync(id);

            if (todoCategory == null)
            {
                return NotFound();
            }

            return todoCategory;
        }

        // PUT: api/TodoCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoCategory(int id, TodoCategory todoCategory)
        {
            if (id != todoCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoCategory>> PostTodoCategory(TodoCategory todoCategory)
        {
            _context.TodoCategories.Add(todoCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoCategory", new { id = todoCategory.Id }, todoCategory);
        }

        // DELETE: api/TodoCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoCategory(int id)
        {
            var todoCategory = await _context.TodoCategories.FindAsync(id);
            if (todoCategory == null)
            {
                return NotFound();
            }

            _context.TodoCategories.Remove(todoCategory);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TodoCategoryExists(int id)
        {
            return _context.TodoCategories.Any(e => e.Id == id);
        }
    }
}
