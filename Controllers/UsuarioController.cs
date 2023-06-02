using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("{Controller}")]
    public class UsuarioController : ControllerBase
    {
        UserManager<Usuario> _userManager;
        //UsuarioDbContext _context;
        IMapper _mapper;

        public UsuarioController(UserManager<Usuario> userManager, UsuarioDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            //_context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioDto.Password);

            return resultado.Succeeded ? Ok() : throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }
}
