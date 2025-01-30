using DAL.Interfaces;
using MODELS;

namespace DAL.Classes
{
    public class HosterDalManager : IHosterDalManager
    {
        private List<Hoster> _hosters;

        public HosterDalManager()
        {
            _hosters = new List<Hoster>();
        }

        public ICollection<Hoster> GetAll()
        {
            return _hosters;
        }

        public Hoster? GetOne(string name)
        {
            return _hosters.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public void Add(Hoster hoster)
        {
            var isExistingHoster = GetOne(hoster.Name) != null;
            if (isExistingHoster)
                throw new Exception("Hoster déjà existant");

            _hosters.Add(hoster);
        }

        public void Update(string name, Hoster input)
        {
            var hosterToUpdate = GetOne(name);
            if (hosterToUpdate == null)
                throw new Exception("Hoster inexistant");

            hosterToUpdate.Name = input.Name;
            hosterToUpdate.ServerImap = input.ServerImap;
            hosterToUpdate.PortIMAP = input.PortIMAP;
            hosterToUpdate.ServerSMTP = input.ServerSMTP;
            hosterToUpdate.PortSMTP = input.PortSMTP;
        }

        public void Remove(string name)
        {
            var index = _hosters.ToList().FindIndex(x => x.Name.ToLower() == name.ToLower());
            if (index == -1)
                throw new Exception("L'index n'existe pas.");
            
            _hosters.RemoveAt(index);
        }
    }
}
