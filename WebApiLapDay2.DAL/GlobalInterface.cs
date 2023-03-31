namespace WebApiLapDay2.DAL
{
    public interface GlobalInterface<T> where T : class
    {
        List<T> GetAll();
        T? GetByID(int id);
        void Remove(T asd);
        void Update();

        void add(T asd);
        void Save();

    }
}