namespace BookingHotel_MVC.Service
{
    public interface IService<T1,T2> where T1:class
    {
        List<T1> GetAll();
        T1 GetById(int id);
        int Insert(T1 item);
        int Update(T2 id, T1 item);
        int Delete(T2 id);
    }
}
