﻿using Microsoft.AspNetCore.Mvc;
using Ticket_Reservation_system.Models;
using Ticket_Reservation_system.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ticket_Reservation_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService) {
            this.studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return studentService.Get();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = studentService.Get(id);

            if(student == null)
            {
                return NotFound($"Student with id = {id} not found");
            };

            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            studentService.Create(student);

            return CreatedAtAction(nameof(Get), new {id = student.Id}, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var excistingStudent = studentService.Get(id);

            if (excistingStudent == null)
            {
                return NotFound($"Student with id = {id} not found");
            };

            studentService.Update(id, student);

            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = studentService.Get(id);

            if (student == null)
            {
                return NotFound($"Student with id = {id} not found");
            };

            studentService.Remove(student.Id);

            return Ok($"Student with Id = {id} deleted");
        }
    }
}
