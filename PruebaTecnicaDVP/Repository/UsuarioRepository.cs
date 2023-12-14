using Microsoft.EntityFrameworkCore;
using PruebaTecnicaDVP.DB;
using PruebaTecnicaDVP.Model;
using PruebaTecnicaDVP.Repository.IRepository;
using System.Linq.Expressions;

namespace PruebaTecnicaDVP.Repository
{
    public class UsuarioRepository: Repository<Usuarios>, IUsuario
    {
    
        public UsuarioRepository(TodoContext db):base(db)
        {
    
        }

    }
}
