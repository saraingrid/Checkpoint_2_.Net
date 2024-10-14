using CP2.API.Application.Dtos;
using CP2.API.Application.Interfaces;
using CP2.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

[Route("api/[controller]")]
[ApiController]
public class VendedorController : ControllerBase
{
    private readonly IVendedorApplicationService _applicationService;

    public VendedorController(IVendedorApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    /// <summary>
    /// Lista todos os vendedores cadastrados.
    /// </summary>
    /// <returns>Lista de vendedores</returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Lista todos os vendedores", Description = "Este endpoint retorna uma lista completa de todos os vendedores cadastrados.")]
    [SwaggerResponse(200, "Lista de vendedores carregada com sucesso", typeof(VendedorEntity))]
    [SwaggerResponse(204, "Nenhum vendedor encontrado")]
    [SwaggerResponse(404, "Falha ao localizar vendedores")]
    [Produces(typeof(VendedorEntity))]
    public IActionResult Get()
    {
        try
        {
            var vendedores = _applicationService.ObterTodosVendedores();

            if (vendedores is null)
                return NoContent();

            return Ok(vendedores);
        }
        catch (Exception)
        {
            return BadRequest("Não foi possível obter os dados.");
        }
    }

    /// <summary>
    /// Obtém um vendedor pelo ID.
    /// </summary>
    /// <param name="id">ID do vendedor</param>
    /// <returns>Vendedor encontrado</returns>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém um vendedor pelo ID", Description = "Este endpoint retorna um vendedor específico pelo ID.")]
    [SwaggerResponse(200, "Vendedor encontrado com sucesso")]
    [SwaggerResponse(204, "Vendedor não encontrado")]
    [SwaggerResponse(404, "Falha em obter o vendedor solicitado")]
    [Produces(typeof(VendedorEntity))]
    public IActionResult GetPorId(int id)
    {
        var vendedor = _applicationService.ObterVendedorPorId(id);

        if (vendedor is not null)
            return Ok(vendedor);

        return BadRequest("Não foi possível obter os dados do vendedor informado.");
    }

    /// <summary>
    /// Adiciona um novo vendedor.
    /// </summary>
    /// <param name="entity">Dados do vendedor a ser adicionado</param>
    /// <returns>Vendedor adicionado</returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Adiciona um novo vendedor", Description = "Este endpoint adiciona um novo vendedor ao sistema.")]
    [SwaggerResponse(200, "Vendedor cadastrado com sucesso")]
    [SwaggerResponse(404, "Falha ao cadastrar novo vendedor")]
    [Produces(typeof(VendedorEntity))]
    public IActionResult Post([FromBody] VendedorDto entity)
    {
        try
        {
            var vendedor = _applicationService.SalvarDadosVendedor(entity);

            if (vendedor is not null)
                return Ok(vendedor);

            return BadRequest("Não foi possível salvar os dados do vendedor.");
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
    /// Edita os dados de um vendedor.
    /// </summary>
    /// <param name="id">ID do vendedor</param>
    /// <param name="entity">Dados atualizados do vendedor</param>
    /// <returns>Vendedor atualizado</returns>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Edita os dados de um vendedor", Description = "Este endpoint atualiza as informações de um vendedor específico.")]
    [SwaggerResponse(200, "Cadastro atualizado com sucesso")]
    [SwaggerResponse(204, "Vendedor não encontrado")]
    [SwaggerResponse(404, "Falha ao atualizar cadastro do vendedor solicitado")]
    [Produces(typeof(VendedorEntity))]
    public IActionResult Put(int id, [FromBody] VendedorDto entity)
    {
        try
        {
            var vendedor = _applicationService.EditarDadosVendedor(id, entity);

            return Ok(vendedor);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Deleta um vendedor pelo ID.
    /// </summary>
    /// <param name="id">ID do vendedor a ser deletado</param>
    /// <returns>Vendedor deletado</returns>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deleta um vendedor pelo ID", Description = "Este endpoint deleta um vendedor específico pelo seu identificador.")]
    [SwaggerResponse(200, "Cadastro deletado com sucesso")]
    [SwaggerResponse(204, "Vendedor não encontrado")]
    [SwaggerResponse(404, "Falha ao deletar o vendedor solicitado")]
    [SwaggerResponse(500, "Internal Server Error")]
    [Produces(typeof(VendedorEntity))]
    public IActionResult Delete(int id)
    {
        try
        {
            var vendedor = _applicationService.DeletarDadosVendedor(id);

            return Ok(vendedor);
        }
        catch (Exception)
        {
            return BadRequest("Não foi possível deletar os dados.");
        }
    }
}
