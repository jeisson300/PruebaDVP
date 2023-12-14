using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaDVP.Model;
using PruebaTecnicaDVP.Model.DTO;
using PruebaTecnicaDVP.Repository.IRepository;

namespace PruebaTecnicaDVP.Controllers
{
    [ApiController]
    [Route("controller")]
    public class Controller : ControllerBase
    {
        private readonly IPersona _personaService;
        private readonly IUsuario _usuarioService;
        private readonly IMapper _mapper;
        private readonly ITipoIdentificacion _tiService;


        public Controller(IUsuario usuario, IPersona persona, IMapper mapper, ITipoIdentificacion ti)
        {
            _personaService = persona;
            _usuarioService = usuario;
            _mapper = mapper;
            _tiService = ti;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePersona([FromBody] PersonaDTO personaDTO)
        {
            ResponseDTO response = _personaService.ValidateCredentials(personaDTO.Email, personaDTO.Password);
            if (response.Status)
            {
                TipoIdentificacion ti = await _tiService.GetAsync(x => x.Id == personaDTO.TipoIdentificacion);
                Persona persona = _mapper.Map<Persona>(personaDTO);
                Usuarios usuario = _mapper.Map<Usuarios>(personaDTO);
                string identificador = "A" + DateTime.Now.ToString("yyyymmdd").ToString()+ DateTime.Now.Millisecond.ToString();
                persona.Identificador = identificador;
                persona.IdentificacionTipoIdentificacion = $"{personaDTO.NumeroIdentificacion} - {ti.Descripcion}";
                persona.NombreCompleto = $"{personaDTO.Nombre}  -  {personaDTO.Apellidos}";
                usuario.Identificador = identificador;
                await _personaService.CreateAsync(persona);
                await _usuarioService.CreateAsync(usuario);
            }
            else
            {
                return BadRequest(new { status = response.Status, message = response.Message });
            }
            return Ok(new { status = response.Status, message = response.Message });
        }

        [HttpPost()]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuarioDTO)
        {
            Usuarios usuario = await _usuarioService.GetAsync(x => x.Usuario.Equals(usuarioDTO.Usuario) && x.Password.Equals(usuarioDTO.Password));
            if (usuario == null)
            {
                return NotFound(new { message = "Credenciales incorrectas", status = false });
            }
            return Ok(new { message = usuario, status = true });
        }

        [HttpGet()]
        public async Task<IActionResult> GetTI()
        {
            return Ok( new { data = await _tiService.GetAllAsync() });
        }
    }
}
