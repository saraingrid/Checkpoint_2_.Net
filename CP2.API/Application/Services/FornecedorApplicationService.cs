using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        FornecedorEntity? IFornecedorApplicationService.DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        FornecedorEntity? IFornecedorApplicationService.EditarDadosFornecedor(int id, FornecedorDto entity)
        {
            var fornecedor = new FornecedorEntity
            {
                Id = id,
                CNPJ = entity.CNPJ,
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                Email = entity.Email,
                Endereco = entity.Endereco,
                CriadoEm = entity.CriadoEm,
            };
            return _repository.EditarDados(fornecedor);
        }

        FornecedorEntity? IFornecedorApplicationService.ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }
        FornecedorEntity? IFornecedorApplicationService.SalvarDadosFornecedor(FornecedorDto entity)
        {
            var fornecedor = new FornecedorEntity
            {
                
                CNPJ = entity.CNPJ,
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                Email = entity.Email,
                Endereco = entity.Endereco,
                CriadoEm = entity.CriadoEm,
            };
            return _repository.SalvarDados(fornecedor);
        }
    }
}
