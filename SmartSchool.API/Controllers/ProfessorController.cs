using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }
        [HttpGet("ById/{id}")]
        public IActionResult ById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return BadRequest("Professor Não encontrado");
            }

            return Ok(professor);

        }

        [HttpGet("byname")]
        public IActionResult byname(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }
            return Ok(professor);
        }
        [HttpPost]
        public IActionResult Post(Professor professor)
        {

            _context.Add(professor);
            _context.SaveChanges();

            return Ok(professor);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(Professor professor, int id)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPut("{id}")]
        public IActionResult Put(Professor professor, int id)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);

            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _context.Remove(prof);
            _context.SaveChanges();
            return Ok(prof);
        }

    }
}
