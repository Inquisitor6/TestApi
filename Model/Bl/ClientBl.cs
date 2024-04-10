using PruebaEdenred.Model.Dao;
using PruebaEdenred.Model.Db;
using PruebaEdenred.Model.Dto;
using PruebaEdenred.Model.Interface;
using PruebaEdenred.Model.Util;

namespace PruebaEdenred.Model.Bl
{
    public class ClientBl : IClientBl
    {
        private readonly ILogger<ClientBl> _logger;
        private readonly IClientDao _clientDao;
        
        public ClientBl(IClientDao clientDao , ILogger<ClientBl> logger)
        {
            _clientDao = clientDao;
            _logger = logger;
        }

        public void CreateClient(ClientManagementDto client, ref ResultSet result)
        {
            _clientDao.CreateClient(client, ref result);
            if (result.IsError)
            {
                _logger.LogError(result.Error, "Error al intentar crear Cliente");
            }
        }

        public ClientRecordDto FindClientById(int clientId, ref ResultSet result)
        {
            ClientRecordDto obj = _clientDao.FindClientById(clientId, ref result);
            if (result.IsError)
            {
                _logger.LogError(result.Error, "Error al intentar Buscar Cliente");
            }
            return obj;
        }

        public Client UpdateClient(int clientId, ClientManagementDto client, ref ResultSet result)
        {

            Client obj = _clientDao.UpdateClient(clientId, client, ref result);
            if (result.IsError)
            {
                _logger.LogError(result.Error, "Error al intentar Actualizar Cliente");
            }
            return obj;
        }
    }
}
