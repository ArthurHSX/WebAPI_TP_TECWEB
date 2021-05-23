using WebAPI.Models;
using Dominio.Entidades;
using Dominio.Interfaces;
using Servico.Validadores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : Controller
    {
        private IServicoBase<Sessao> _baseUserService;

        public SessaoController(IServicoBase<Sessao> baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost]
        public ActionResult<ResponseCreateSessao> Create([FromBody] CreateModeloSessao sessao)
        {
            if (sessao == null)
            {

                return NotFound();
            }

            var resultado = new ResponseCreateSessao()
            {
                Guid = (Guid)_baseUserService.Add<CreateModeloSessao, SessaoModelo, SessaoValidator>(sessao).Guid
            };


            return resultado;            
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateModeloUsuario user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<UpdateModeloUsuario, UsuarioModelo, SessaoValidator>(user));
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
            return Execute(() => _baseUserService.Get<SessaoModelo>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById<SessaoModelo>(id));
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
