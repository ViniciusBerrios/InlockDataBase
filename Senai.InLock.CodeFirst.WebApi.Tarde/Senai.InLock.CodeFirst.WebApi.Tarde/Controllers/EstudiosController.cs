using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.CodeFirst.WebApi.Tarde.Context;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListarEstudios()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("estudiosComJogos")]
        public IActionResult BuscarEstudiosComJogos()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.Include(x => x.Jogos).ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    ctx.Estudios.Add(estudio);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}