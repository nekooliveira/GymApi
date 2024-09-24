using GymProject1.Models;
using Microsoft.Identity.Client;

namespace GymProject1.Services
{
    public class ClientService
    {
        private readonly GymContext _context;
        public ClientService(GymContext context)
        {
            _context = context;
        }


        public List<Client> ListClients()
        {
            return _context.Clients.ToList();
        }

        public Client SearchPerId(int id)
        {
            return _context.Clients.Find(id);

        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
        public void ChangeClient(int id, Client clientChanges)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
            {
                client.Name = clientChanges.Name;
                client.User = clientChanges.User;
                client.Password = clientChanges.Password;
                _context.SaveChanges();
            }
        }

        public void DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }


        public Client Authenticate(string user, string password)
        {
            return _context.Clients.FirstOrDefault(c => c.User == user && c.Password == password);
        }





    }
}


