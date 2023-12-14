
using PruebaTecnicaDVP.Model;
using PruebaTecnicaDVP.Model.DTO;

namespace PruebaTecnicaDVP.Repository.IRepository
{
    public interface  IPersona: IRepository<Persona>
    {
        ResponseDTO ValidateCredentials(string email, string password); 
    }
}
