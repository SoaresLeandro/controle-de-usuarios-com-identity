using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("{Controller}")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] CreateUsuarioDto usuarioDto)
        {
            throw new NotImplementedException();
        }
    }
}
