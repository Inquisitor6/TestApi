using PruebaEdenred.Data;
using PruebaEdenred.Model.Bl;
using PruebaEdenred.Model.Db;
using PruebaEdenred.Model.Dto;
using PruebaEdenred.Model.Interface;
using PruebaEdenred.Model.Util;

namespace PruebaEdenred.Model.Dao
{
    public class ClientDao : IClientDao
    {
        private readonly DbContextSqlite _context;

        public ClientDao(DbContextSqlite context)
        {
            _context = context;
        }

        public void CreateClient(ClientManagementDto client, ref ResultSet result)
        {
            try
            {
                Client clientDb = new()
                {
                    Nombre = client.Nombre,
                    Apellido = client.Apellido,
                    Email = client.Email,
                    Password = client.Password,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = null
                };

                _context.client.Add(clientDb);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
            }
        }

        public ClientRecordDto FindClientById(int clientId, ref ResultSet result)
        {
            try
            {
                Client clientInDb = _context.client.FirstOrDefault(x => x.Id == clientId);
                if (clientInDb is null)
                    return null;

                ClientRecordDto clientRecord = new ClientRecordDto()
                {
                    Id = clientInDb.Id,
                    Nombre = clientInDb.Nombre,
                    Apellido = clientInDb.Apellido,
                    Email = clientInDb.Email,
                    Password = clientInDb.Password,
                    FechaCreacion = clientInDb.FechaCreacion,
                    FechaActualizacion = clientInDb.FechaActualizacion
                };
                return clientRecord;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
                return null;
            }
        }

        public Client UpdateClient(int clientId, ClientManagementDto client, ref ResultSet result)
        {
            try
            {
                var clientInDb = _context.client.FirstOrDefault(c => c.Id == clientId);
                if (clientInDb is null)
                    return clientInDb;

                clientInDb.Nombre = client.Nombre;
                clientInDb.Apellido = client.Apellido;
                clientInDb.Email = client.Email;
                clientInDb.Password = client.Password;
                clientInDb.FechaActualizacion = DateTime.Now;
                _context.SaveChanges();
                return clientInDb;
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
                return null;
            }
        }
    }
}
