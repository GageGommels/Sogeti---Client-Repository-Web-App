
namespace Sogeti_Client_Data_Repository.Models
{
    public class Client
    {
        public string clientId;
        public string clientName;
        public string description;

        public Client() {  }

        public Client(string clientId,  string clientName, string description)
        {
            this.clientId = clientId;
            this.clientName = clientName;
            this.description = description;
        }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }

    }
}