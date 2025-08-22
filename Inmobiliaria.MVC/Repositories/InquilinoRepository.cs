using Inmobiliaria.MVC.Data;
using Inmobiliaria.MVC.Models;

namespace Inmobiliaria.MVC.Repositories
{
    public class InquilinoRepository : EfRepository<Inquilino>, IInquilinoRepository
    {
        public InquilinoRepository(InmobiliariaContext ctx) : base(ctx) { }
    }
}
