using Microsoft.AspNetCore.Mvc;
namespace FirstC_.Controllers;
    public class TodoController : ControllerBase
    {
        public static List<TodoItem> TodoItems = new List<TodoItem>();
        [HttpPost("/api/todo")]
        public IActionResult Create([FromBody] TodoItemDto todoDto)
        {
            try
            {
                var todo = new TodoItem
                {
                    Id = TodoItems.Count + 1,
                    Title = todoDto.Title,
                    Description = todoDto.Description,
                    IsCompleted = todoDto.IsCompleted
                };

                TodoItems.Add(todo);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/api/todo/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var todo = TodoItems.FirstOrDefault(x => x.Id == id);
                if (todo == null)
                {
                    return NotFound();
                }
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/api/todo/{id}")]
        public IActionResult Update(int id, [FromBody] TodoItemDto todoDto)
        {
            try
            {
                var existingTodo = TodoItems.FirstOrDefault(x => x.Id == id);
                if (existingTodo == null)
                {
                    return NotFound();
                }
                existingTodo.Title = todoDto.Title;
                existingTodo.Description = todoDto.Description;
                existingTodo.IsCompleted = todoDto.IsCompleted;

                return Ok("Todo item updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/api/todo/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var todo = TodoItems.FirstOrDefault(x => x.Id == id);
                if (todo == null)
                {
                    return NotFound();
                }
                TodoItems.Remove(todo);
                return Ok("Todo item deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    public class TodoItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    } 
    public class TodoItem
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

