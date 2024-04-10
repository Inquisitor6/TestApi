using PruebaEdenred.Model.Db;
using PruebaEdenred.Model.Dto;
using PruebaEdenred.Model.Util;

namespace PruebaEdenred.Model.Interface
{
    public interface IClientDao
    {
        void CreateClient(ClientManagementDto client, ref ResultSet result);
        ClientRecordDto FindClientById(int clientId, ref ResultSet result);
        Client UpdateClient(int clientId, ClientManagementDto client, ref ResultSet result);
    }
}
