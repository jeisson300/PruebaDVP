using AutoMapper;
using PruebaTecnicaDVP.Model;
using PruebaTecnicaDVP.Model.DTO;

namespace PruebaTecnicaDVP
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            CreateMap<Persona, PersonaDTO>();
            CreateMap<PersonaDTO, Persona>();
            CreateMap<Usuarios, PersonaDTO>();
            CreateMap<PersonaDTO, Usuarios>();
        }
    }
}
