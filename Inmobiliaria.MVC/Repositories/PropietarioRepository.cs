using Inmobiliaria.MVC.Data;
using Inmobiliaria.MVC.Models;

namespace Inmobiliaria.MVC.Repositories
{
    public class PropietarioRepository : EfRepository<Propietario>, IPropietarioRepository
    {
        public PropietarioRepository(InmobiliariaContext ctx) : base(ctx) { }
    }
}
