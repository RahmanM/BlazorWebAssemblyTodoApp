using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorTodos.Server.Data
{
    public class TodoCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Category should be at least 3 characters")]
        public string Description { get; set; }

        public bool Active { get; set; }

    }
}
