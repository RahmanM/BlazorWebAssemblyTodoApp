using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodos.Server.Data
{
    public class Todo
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int TodoCategoryId { get; set; }
        public TodoCategory TodoCategory { get; set; }

        public bool Complete { get; set; }

        public bool Active { get; set; }

    }
}
