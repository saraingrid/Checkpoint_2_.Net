using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
