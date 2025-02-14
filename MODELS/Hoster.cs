namespace MODELS
{
    public class Hoster
    {
        public Hoster(string name, string serverImap, int portImap, string serverSMTP, int portSMTP)
        {
            Name = name;
            ServerIMAP = serverImap;
            PortIMAP = portImap;
            ServerSMTP = serverSMTP;
            PortSMTP = portSMTP;
        }

        public string Name { get; set; } = null!;
        public string ServerIMAP { get; set; } = null!;
        public int PortIMAP; 
        public string ServerSMTP { get; set; } = null!;
        public int PortSMTP; 
    }
}
