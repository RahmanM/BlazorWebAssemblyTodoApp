using Microsoft.EntityFrameworkCore;

namespace BlazorTodos.Server.Data
{
    public class TodoContext : DbContext
    {
        public virtual DbSet<Todo> Todos { get; set; }

        public virtual DbSet<TodoCategory> TodoCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=Todos.db;");
        }
    }
}
