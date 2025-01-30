using MODELS;

namespace DAL.Interfaces
{
    public interface IHosterDalManager
    {
        ICollection<Hoster> GetAll();
        Hoster? GetOne(string name);
        void Add(Hoster hoster);
        public void Update(string name, Hoster input);
        void Remove(string name);
    }
}
