using BLL.Interfaces;
using DAL.Interfaces;
using MODELS;

namespace BLL.Classes
{
    public class HosterBllManager : IHosterBllManager
    {
        private IHosterDalManager _hosterDalManager;

        public HosterBllManager(IHosterDalManager hosterDalManager)
        {
            _hosterDalManager = hosterDalManager;
        }


        public ICollection<Hoster> GetAll()
        {
            return _hosterDalManager.GetAll();
        }

        public Hoster? GetOne(string name)
        {
            return _hosterDalManager.GetOne(name);  
        }

        public void Add(Hoster hoster)
        {
            _hosterDalManager.Add(hoster);
        }

        public void Update(string name, Hoster input)
        {
            _hosterDalManager.Update(name, input);
        }

        public void Remove(string name)
        {
            _hosterDalManager.Remove(name);
        }
    }
}
