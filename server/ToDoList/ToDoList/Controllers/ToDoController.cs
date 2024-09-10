using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController: ControllerBase
    {
        private readonly ToDoService _toDoService;
        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> GetAll() => Ok(_toDoService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> Get(int id)
        {
            var item = _toDoService.Get(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ToDoItem> Create(ToDoItem item)
        {
            var createdItem = _toDoService.Add(item);
            return CreatedAtAction(nameof(Get), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ToDoItem item)
        {
            if (id != item.Id) return BadRequest();
            _toDoService.Update(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _toDoService.Remove(id);
            return NoContent();
        }
    }
}
