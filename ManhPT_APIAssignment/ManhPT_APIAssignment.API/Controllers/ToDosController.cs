using AutoMapper;
using ManhPT_APIAssignment.API.Dtos;
using ManhPT_APIAssignment.Model;
using ManhPT_APIAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT_APIAssignment.API.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDosController(IToDoService service, IMapper mapper) : ControllerBase
    {
        private readonly IToDoService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IEnumerable<ToDoDto>> GetAllAsync()
        {
            var toDoList = await _service.GetListToDoAsync();
            var dtos = _mapper.Map<List<ToDoDto>>(toDoList);
            return dtos;
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var toDo = await _service.GetToDoByIdAsync(id);
            if (toDo == null)
            {
                return StatusCode(404, "Not Found");
            }
            else
            {
                var dto = _mapper.Map<ToDoDto>(toDo);
                return Ok(dto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ToDoCreateDto dto)
        {
            var toDo = _mapper.Map<ToDo>(dto);
            toDo.Id = Guid.NewGuid();
            var result = await _service.CreateToDoAsync(toDo);
            if (result)
            {
                return CreatedAtAction(nameof(GetByIdAsync), new { id = toDo.Id }, toDo);
            }
            else
            {
                return StatusCode(500, "An error occurred while create task.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ToDoCreateDto dto)
        {
            var toDo = _mapper.Map<ToDo>(dto);
            toDo.Id = id;
            var result = await _service.UpdateToDoAsync(toDo);
            if (result)
            {
                return Ok("Update success");
            }
            else
            {
                return StatusCode(500, "An error occurred while update task.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var result = await _service.DeleteToDoAsync(Id);
            if (result)
            {
                return Ok($"Delete success: {Id}");
            }
            else
            {
                return StatusCode(500, "An error occurred while delete task.");
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulkAsync([FromBody] List<ToDoCreateDto> dtos)
        {
            if (dtos == null || !dtos.Any())
            {
                return BadRequest("No tasks provided.");
            }

            var toDos = _mapper.Map<List<ToDo>>(dtos);
            foreach (var toDo in toDos)
            {
                toDo.Id = Guid.NewGuid(); // Ensure each task has a unique ID
            }

            var result = await _service.CreateToDoBulkAsync(toDos);
            if (result)
            {
                return Ok("Bulk insert successful.");
            }
            else
            {
                return StatusCode(500, "An error occurred while inserting tasks.");
            }
        }

        [HttpDelete("bulk")]
        public async Task<IActionResult> DeleteBulkAsync([FromBody] List<Guid> ids)
        {
            if (ids == null || !ids.Any())
            {
                return BadRequest("No task IDs provided.");
            }

            var result = await _service.DeleteToDoBulkAsync(ids);
            if (result)
            {
                return Ok("Bulk delete successful.");
            }
            else
            {
                return StatusCode(500, "An error occurred while deleting tasks.");
            }
        }
    }
}
