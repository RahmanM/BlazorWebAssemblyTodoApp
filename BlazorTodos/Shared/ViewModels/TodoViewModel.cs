using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTodos.Server.Data
{
    public class TodoViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Description should be at least 5 characters!")]
        public string Description { get; set; }

        [Required]
        public int TodoCategoryId { get; set; }
        public string Category { get; set; }

        public bool Complete { get; set; }

        public bool Active { get; set; }

    }
}
