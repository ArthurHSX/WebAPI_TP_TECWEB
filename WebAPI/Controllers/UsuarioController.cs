using WebAPI.Models;
using Dominio.Entidades;
using Dominio.Interfaces;
using Servico.Validadores;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IServicoBase<Usuario> _baseUserService;

        public UsuarioController(IServicoBase<Usuario> baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateModeloUsuario user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<CreateModeloUsuario, UsuarioModelo, UsuarioValidator>(user).ID);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateModeloUsuario user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<UpdateModeloUsuario, UsuarioModelo, UsuarioValidator>(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUserService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.Get<UsuarioModelo>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById<UsuarioModelo>(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
