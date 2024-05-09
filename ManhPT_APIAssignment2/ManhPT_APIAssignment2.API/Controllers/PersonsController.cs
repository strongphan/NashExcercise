using AutoMapper;
using ManhPT_APIAssignment2.API.DTOs;
using ManhPT_APIAssignment2.Model;
using ManhPT_APIAssignment2.Repository;
using ManhPT_APIAssignment2.Service.PersonService;
using Microsoft.AspNetCore.Mvc;

namespace ManhPT_APIAssignment2.API.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonsController(IPersonService service, IMapper mapper) : ControllerBase
    {
        private readonly IPersonService _service = service;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Get people with filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("person_filter")]
        [ActionName(nameof(GetAllAsync))]
        public async Task<IEnumerable<PersonDto>> GetAllAsync(FilterPersonDto filter)
        {
            var people = await _service.GetPeopleAsync(filter);
            var dtos = _mapper.Map<List<PersonDto>>(people);
            return dtos;
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var person = await _service.GetPersonByIdAsync(id);
            if (person == null)
            {
                throw new Exception($"Can't found person {id}");
            }
            else
            {
                var dto = _mapper.Map<PersonDto>(person);
                return Ok(dto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PersonCreateDto dto)
        {
            var person = _mapper.Map<Person>(dto);
            person.Id = Guid.NewGuid();
            var result = await _service.AddPersonAsync(person);
            if (result)
            {
                return CreatedAtAction(nameof(GetByIdAsync), new { id = person.Id }, person);
            }
            else
            {
                return StatusCode(500, "An error occurred while create task.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] PersonCreateDto dto)
        {
            var person = _mapper.Map<Person>(dto);
            person.Id = id;
            var result = await _service.UpdatePersonAsync(person);
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
            var result = await _service.DeletePersonAsync(Id);
            if (result)
            {
                return Ok($"Delete success: {Id}");
            }
            else
            {
                return StatusCode(500, "An error occurred while delete task.");
            }
        }
    }
}
