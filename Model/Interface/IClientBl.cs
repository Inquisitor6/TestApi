using PruebaEdenred.Model.Db;
using PruebaEdenred.Model.Dto;
using PruebaEdenred.Model.Util;

namespace PruebaEdenred.Model.Interface
{
    public interface IClientBl
    {
        public void CreateClient(ClientManagementDto client, ref ResultSet result);

        public ClientRecordDto FindClientById(int clientId, ref ResultSet result);

        public Client UpdateClient(int clientId, ClientManagementDto client, ref ResultSet result);
    }
}
