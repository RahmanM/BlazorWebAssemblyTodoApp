using System.Collections.Generic;

namespace BlazorTodos.Server.Data
{
    public class TodoCategory
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public List<Todo> Todos { get; set; }

    }
}
