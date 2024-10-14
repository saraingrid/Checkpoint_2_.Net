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

        public FornecedorEntity? DeletarDados(int id)
        {
            try 
            {
                var fornecedor = _context.Fornecedor.Find(id);
                if (fornecedor is not null)
                {
                    _context.Remove(fornecedor);
                    _context.SaveChanges();

                    return fornecedor;
                }

                //Gera um excecão para informar que nao foi possivel localizar o fornecedor no banco
                throw new Exception("Não foi possivel localizar o fornecedor pelo id informado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public FornecedorEntity? EditarDados(FornecedorEntity entity)
        {
            try
            {
                var fornecedor = _context.Fornecedor.Find(entity.Id);

                if (fornecedor is not null)
                {
                    fornecedor.CNPJ = entity.CNPJ;
                    fornecedor.Nome = entity.Nome;
                    fornecedor.Telefone = entity.Telefone;
                    fornecedor.Email = entity.Email;
                    fornecedor.Endereco = entity.Endereco;
                    fornecedor.CriadoEm = entity.CriadoEm;

                    _context.Update(fornecedor);
                    _context.SaveChanges();

                    return fornecedor;
                }

                //Gera um excecão para informar que nao foi possivel localizar o fornecedor no banco
                throw new Exception("Não foi possivel localizar o fornecedor pelo id informado.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public FornecedorEntity? ObterPorId(int id)
        {

            var fornecedor = _context.Fornecedor.Find(id);

            if (fornecedor is not null)
            {
                return fornecedor;
            }
            return null;

        }

        IEnumerable<FornecedorEntity>? IFornecedorRepository.ObterTodos()
        {
            var fornecedores = _context.Fornecedor.ToList();

            if (fornecedores.Any())
                return fornecedores;
            return null;
        }

        public FornecedorEntity SalvarDados(FornecedorEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel salvar o fornecedor informado.");
            }

        }
    }
}
