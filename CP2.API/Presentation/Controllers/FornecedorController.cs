using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Lista todos os fornecedores cadastrados.
        /// </summary>
        /// <returns>Lista de fornecedores</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os fornecedores", Description = "Este endpoint retorna uma lista completa de todos os fornecedores cadastrados.")]
        
       [ProducesResponseType(typeof(IEnumerable<FornecedorEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            try
            {

                var fornecedores = _applicationService.ObterTodosFornecedores();

                if (fornecedores is null)
                    return NoContent();

                return Ok(fornecedores);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível obter os dados.");
            }
        }

        /// <summary>
        /// Obtém um fornecedor pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor</param>
        /// <returns>Fornecedor encontrado</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um fornecedor pelo ID", Description = "Este endpoint retorna um fornecedor específico localizado pelo ID.")]
        [SwaggerResponse(200, "Lista de fornecedores carregada com sucesso", typeof(FornecedorEntity))]
        [SwaggerResponse(204, "Nenhum fornecedor encontrado")]
        [SwaggerResponse(404, "Falha ao localizar fornecedores")]
        [Produces(typeof(FornecedorEntity))]
        public IActionResult GetPorId(int id)
        {
            var fornecedor = _applicationService.ObterFornecedorPorId(id);

            if (fornecedor is not null)
                return Ok(fornecedor);

            return BadRequest("Não foi possível obter os dados do fornecedor informado.");
        }

        /// <summary>
        /// Adiciona um novo fornecedor.
        /// </summary>
        /// <param name="entity">Dados do fornecedor a ser adicionado</param>
        /// <returns>Fornecedor adicionado</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo fornecedor", Description = "Este endpoint adiciona um novo fornecedor ao banco de dados.")]
        [SwaggerResponse(200, "Novo fornecedor cadastrado com sucesso", typeof(FornecedorEntity))]
        [SwaggerResponse(404, "Falha ao cadastrar novo fornecedor")]
        [Produces(typeof(FornecedorEntity))]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var fornecedor = _applicationService.SalvarDadosFornecedor(entity);

                if (fornecedor is not null)
                    return Ok(fornecedor);

                return BadRequest("Não foi possível salvar os dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Edita os dados de um fornecedor.
        /// </summary>
        /// <param name="id">ID do fornecedor</param>
        /// <param name="entity">Dados atualizados do fornecedor</param>
        /// <returns>Fornecedor atualizado</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Edita os dados de um fornecedor", Description = "Este endpoint atualiza as informações de um fornecedor específico.")]
        [SwaggerResponse(200, "Cadastro atualizado com sucesso")]
        [SwaggerResponse(204, "Fornecedor não encontrado")]
        [SwaggerResponse(404, "Falha ao atualizar cadastro do fornecedor solicitado")]
        [Produces(typeof(FornecedorEntity))]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var fornecedor = _applicationService.EditarDadosFornecedor(id, entity);

                    return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        /// <summary>
        /// Deleta um fornecedor pelo ID.
        /// </summary>
        /// <param name="id">ID do fornecedor a ser deletado</param>
        /// <returns>Fornecedor deletado</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um fornecedor pelo ID", Description = "Este endpoint deleta um fornecedor específico pelo ID.")]
        [SwaggerResponse(200, "Cadastro deletado com sucesso")]
        [SwaggerResponse(204, "Fornecedor não encontrado")]
        [SwaggerResponse(404, "Falha ao deletar o Fornecedor solicitado")]
        [SwaggerResponse(500, "Internal Server Error")]
        [Produces(typeof(FornecedorEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var fornecedor = _applicationService.DeletarDadosFornecedor(id);

                return Ok(fornecedor);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível deletar os dados.");
            }
        }
    }
}
