using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        UserManager<Usuario> _userManager;
        IMapper _mapper;

        public CadastroService(UserManager<Usuario> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Cadastrar(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioDto.Password);

            if(!resultado.Succeeded) throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }
}
