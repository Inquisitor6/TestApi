using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaEdenred.Model.Bl;
using PruebaEdenred.Model.Db;
using PruebaEdenred.Model.Dto;
using PruebaEdenred.Model.Interface;
using PruebaEdenred.Model.Util;
using System.Net;

namespace PruebaEdenred.Controllers
{

    /// <summary>
    /// Controlador que permite la administración de Clientes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientBl _clientBl;

        public ClientController(IClientBl clientBl)
        {
            _clientBl = clientBl;
        }

        /// <summary>
        /// Permite realizar la Creación de nuevos Clientes.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        /// <response code="200">Ejecución con éxito</response>
        /// <response code="400">Error en la Petición</response>
        /// <response code="500">Ocurrió un error interno</response>
        [HttpPost]
        [Route("CreateClient")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateClient(ClientManagementDto client)
        {
            ResultSet result = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _clientBl.CreateClient(client, ref result);
                if (result.IsError)
                {
                    return StatusCode(500);
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Permite recuperar un Cliente en base a su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Ejecución con éxito</response>
        /// <response code="404">Registro no Encontrado</response>
        /// <response code="500">Ocurrió un error interno</response>
        [HttpGet("GetClientById/{id}")]
        [ProducesResponseType(typeof(ClientRecordDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetClientById(int id)
        {
            ResultSet result = new();
            try
            {
                ClientRecordDto client = _clientBl.FindClientById(id, ref result);
                if (result.IsError)
                {
                    return StatusCode(500);
                }

                if (client is null)
                {
                    return NotFound();
                }
                return Ok(client);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Permite realizar la actualización de un registro de cliente, en base a su ID e información respectiva.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("UpdateClientById/{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateClientById(int id, [FromBody] ClientManagementDto clientUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ResultSet result = new();

                Client client = _clientBl.UpdateClient(id, clientUpdateDto, ref result);
                if (result.IsError)
                {
                    return StatusCode(500);
                }

                if (client is null)
                {
                    return NotFound(clientUpdateDto);
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
