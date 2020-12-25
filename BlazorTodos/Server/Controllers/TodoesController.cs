using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorTodos.Server.Data;

namespace BlazorTodos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoesController()
        {
            _context = new TodoContext();
        }

        // GET: api/Todoes
        [HttpGet]
        public IEnumerable<TodoViewModel> GetTodos()
        {
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var todos = _context.Todos.Include(i=> i.TodoCategory).ToList();

            var todosViewModel = new List<TodoViewModel>();
            foreach (var t in todos)
            {
                todosViewModel.Add(new TodoViewModel()
                {
                    Id = t.Id,
                    Active = t.Active,
                    TodoCategoryId = t.TodoCategoryId,
                    Complete = t.Complete,
                    Description = t.Description,
                    Category = t.TodoCategory?.Description
                });
            }

            return todosViewModel;
        }

        //// GET: api/Todoes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TodoViewModel>> GetTodo(int id)
        //{
        //    var todo = await _context.Todos.FindAsync(id);

        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    return todo;
        //}

        // PUT: api/Todoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, TodoViewModel todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
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

        // POST: api/Todoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoViewModel>> PostTodo(TodoViewModel todo)
        {
            _context.Todos.Add(new Todo
            {
                Active = todo.Active,
                TodoCategoryId = todo.TodoCategoryId,
                Complete = todo.Complete,
                Description = todo.Description
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostTodo", new { id = todo.Id }, todo);
        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TodoExists(int id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}
