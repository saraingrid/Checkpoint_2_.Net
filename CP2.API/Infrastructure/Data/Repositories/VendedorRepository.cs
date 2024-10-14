using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            try
            {
                var vendedor = _context.Vendedor.Find(id);
                if (vendedor is not null)
                {
                    _context.Remove(vendedor);
                    _context.SaveChanges();

                    return vendedor;
                }

                //Gera um exceção para informar que não foi possível localizar o vendedor no banco
                throw new Exception("Não foi possível localizar o vendedor pelo id informado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public VendedorEntity? EditarDados(VendedorEntity entity)
        {
            try
            {
                var vendedor = _context.Vendedor.Find(entity.Id);

                if (vendedor is not null)
                {
                    vendedor.Nome = entity.Nome;
                    vendedor.Telefone = entity.Telefone;
                    vendedor.Email = entity.Email;
                    vendedor.DataContratacao = entity.DataContratacao;
                    vendedor.DataNascimento = entity.DataNascimento;
                    vendedor.Endereco = entity.Endereco;
                    vendedor.ComissaoPercentual = entity.ComissaoPercentual;
                    vendedor.MetaMensal = entity.MetaMensal;
                    vendedor.CriadoEm = entity.CriadoEm;

                    _context.Update(vendedor);
                    _context.SaveChanges();

                    return vendedor;
                }

                //Gera um exceção para informar que não foi possível localizar o vendedor no banco
                throw new Exception("Não foi possível localizar o vendedor pelo id informado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public VendedorEntity? ObterPorId(int id)
        {

            var vendedor = _context.Vendedor.Find(id);

            if (vendedor is not null)
            {
                return vendedor;
            }
            return null;
        }

        public IEnumerable<VendedorEntity>? ObterTodos()
        {
            var vendedores = _context.Vendedor.ToList();

            if (vendedores.Any())
                return vendedores;

            return null;
        }

        public VendedorEntity SalvarDados(VendedorEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível salvar o vendedor informado.");
            }
        }
    }
}
