using System;
using System.Collections.Generic;
using Cast.Business.Repositories;
using Cast.Business.Services;
using Cast.Model;
using Cast.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET: api/<CursoController>
        [HttpGet]
        public IActionResult Get()
        {            
            return new OkObjectResult(_cursoService.GetAll());
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return new OkObjectResult(_cursoService.GetById(id));
        }

        // POST api/<CursoController>
        [HttpPost]
        public IActionResult Post([FromBody] CursoDTO curso)
        {
            return new OkObjectResult(_cursoService.Save(curso));
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CursoDTO curso)
        {
            return new OkObjectResult(_cursoService.Update(curso));
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return new OkObjectResult(_cursoService.Delete(id));            
        }
    }
}
