using Microsoft.Identity.Client;
using PruebaTecnicaDVP.DB;
using PruebaTecnicaDVP.Model;
using PruebaTecnicaDVP.Model.DTO;
using PruebaTecnicaDVP.Repository.IRepository;

namespace PruebaTecnicaDVP.Repository
{
    public class PersonaRepository : Repository<Persona>, IPersona
    {
        private readonly IUtil _util;

        public PersonaRepository(TodoContext db, IUtil util) : base(db)
        {

            _util = util;

        }

        public ResponseDTO ValidateCredentials(string email, string password)
        {
            string message = "";
            bool status = true;
            try
            {
                if (!_util.ValidateFormatPassword(password))
                {
                    throw new Exception("El password no tiene el formato valido, debe tener un tamaño entre 8 y 16 caracteres, por lo menos un numero y uno de los siguientes caracteres especiales [#$%&.*] ");
                }
                if (!_util.ValidateFormatEmail(email))
                {
                    throw new Exception("formato del email es invalido");
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = false;
            }

            return new ResponseDTO { Message = message, Status = status };
        }
    }
}
