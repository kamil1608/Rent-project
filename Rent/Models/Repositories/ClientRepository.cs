using Rent.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent.Models.Repositories
{
    public class ClientRepository
    {
        public List<Client> GetClients(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clients.Where(x => x.UserId == userId).ToList();
            }
        }
    }
}