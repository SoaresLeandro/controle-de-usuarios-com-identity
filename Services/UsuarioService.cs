using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private IMapper _mapper;

        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task Cadastrar(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioDto.Password);

            if(!resultado.Succeeded) throw new ApplicationException("Falha ao cadastrar usuário!");
        }

        public async Task Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if(!resultado.Succeeded) throw new ApplicationException("Usuário não autenticado!");
        }
    }
}
