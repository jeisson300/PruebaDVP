using PruebaTecnicaDVP.DB;
using PruebaTecnicaDVP.Model;
using PruebaTecnicaDVP.Repository.IRepository;

namespace PruebaTecnicaDVP.Repository
{
    public class TipoIdentificacionRepository: Repository<TipoIdentificacion>,  ITipoIdentificacion
    {
        public TipoIdentificacionRepository(TodoContext db): base(db)
        {
            
        }
    }
}
