using MODELS;

namespace BLL.Interfaces
{
    public interface IHosterBllManager
    {
        ICollection<Hoster> GetAll();
        Hoster? GetOne(string name);
        void Add(Hoster hoster);
        public void Update(string name, Hoster input);
        void Remove(string name);
    }
}
