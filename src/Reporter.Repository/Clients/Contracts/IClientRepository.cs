using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Repository.Clients.Contracts
{
    public interface IClientRepository
    {
        Task DeleteAsync(Guid clientId);

        Task<IList<Client>> GetAllAsync();

        Task<Client> GetAsync(Guid clientId);

        Task<IEnumerable<Client>> FindAsync();

        Task InsertAsync(Client client);

        Task UpdateAsync(Client client);
    }
}
