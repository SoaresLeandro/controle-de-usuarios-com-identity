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
        CadastroService _cadastroService;      

        public UsuarioController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] CreateUsuarioDto usuarioDto)
        {
            await _cadastroService.Cadastrar(usuarioDto);

            return Ok("Usuário Cadastrado com sucesso!");
        }
    }
}
