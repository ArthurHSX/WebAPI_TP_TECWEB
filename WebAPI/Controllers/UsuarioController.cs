using WebAPI.Models;
using Dominio.Entidades;
using Dominio.Interfaces;
using Servico.Validadores;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IServicoBase<Usuario> _baseUserService;

        public UsuarioController(IServicoBase<Usuario> baseUserService)
        {
            _baseUserService = baseUserService;
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

        [HttpPost]
        public IActionResult Create([FromBody] CreateModeloUsuario user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<CreateModeloUsuario, UsuarioModelo, UsuarioValidator>(user).ID);
        }

        [HttpPost("CreateSessao/")]
        public async Task<ActionResult<ResponseCreateSessao>> CreateSessao([FromBody] CreateModeloUsuario usuarioSessao)
        {            
            if (string.IsNullOrEmpty(usuarioSessao.Login))
                return NotFound();

            var listaUsuarios = _baseUserService.Get<UsuarioModelo>().ToList();

            var usuario = listaUsuarios.Where(x => x.Login == usuarioSessao.Login && x.Excluido == false).FirstOrDefault();

            if (usuario == null)
                return NotFound();

            if (usuario.Senha != usuarioSessao.Senha)
                return Unauthorized();

            CreateModeloSessao sessao = new CreateModeloSessao()
            {
                IdUsuario = usuario.ID,
                DtCriacao = DateTime.Now
            };

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:50606/api/sessao");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.PostAsJsonAsync("/api/sessao", sessao);

                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }                                                    
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateModeloUsuario user)
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
        

        //[HttpGet("Login/login={login}&&senha={senha}")]
        //public IActionResult GetByEmail(string login,string senha)
        //{
        //    if (string.IsNullOrEmpty(login))
        //        return NotFound();

        //    var result = _baseUserService.Get<UsuarioModelo>();

        //    result.Contains(x => x.Login == login)
            
            
        //    return Execute(() => _baseUserService.GetByNome<UsuarioModelo>(login));
        //}

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
