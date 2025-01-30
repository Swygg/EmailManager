namespace MODELS
{
    public class Hoster
    {
        public Hoster(string name, string serverImap, int portImap, string serverSMTP, int portSMTP)
        {
            Name = name;
            ServerImap = serverImap;
            PortIMAP = portImap;
            ServerSMTP = serverSMTP;
            PortSMTP = portSMTP;
        }

        public string Name { get; set; } = null;
        public string ServerImap { get; set; } = null!; //Server IMAP
        public int PortIMAP; 
        public string ServerSMTP { get; set; } = null!; //Server SMTP
        public int PortSMTP; 
    }
}
