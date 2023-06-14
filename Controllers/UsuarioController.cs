using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("{Controller}")]
    public class UsuarioController : ControllerBase
    {
        UsuarioService _usuarioService;      

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] CreateUsuarioDto usuarioDto)
        {
            await _usuarioService.Cadastrar(usuarioDto);

            return Ok("Usuário Cadastrado com sucesso!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            await _usuarioService.Login(dto);

            return Ok("Usuário Autenticado!");
        }
    }
}
