using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }
        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        VendedorEntity? IVendedorApplicationService.EditarDadosVendedor(int id, VendedorDto entity)
        {
            var vendedor = new VendedorEntity
            {
                Id = id,
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                Email = entity.Email,
                DataContratacao = entity.DataContratacao,
                DataNascimento = entity.DataNascimento,
                Endereco = entity.Endereco,
                ComissaoPercentual = entity.ComissaoPercentual,
                MetaMensal = entity.MetaMensal,
                CriadoEm = entity.CriadoEm,
            };
            return _repository.EditarDados(vendedor);
        }

        IEnumerable<VendedorEntity>? IVendedorApplicationService.ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        VendedorEntity? IVendedorApplicationService.ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        VendedorEntity? IVendedorApplicationService.SalvarDadosVendedor(VendedorDto entity)
        {
            var vendedor = new VendedorEntity
            {
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                Email = entity.Email,
                DataContratacao = entity.DataContratacao,
                DataNascimento = entity.DataNascimento,
                Endereco = entity.Endereco,
                ComissaoPercentual = entity.ComissaoPercentual,
                MetaMensal = entity.MetaMensal,
                CriadoEm = entity.CriadoEm,
            };
            return _repository.SalvarDados(vendedor);
        }
    }
}
