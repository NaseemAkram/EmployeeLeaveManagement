namespace EmployeeLeaveManagement.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        ICollection<T> FindAll();
        T FindById(int id);

        bool Create(T entry);

        bool Update(T entry);

        bool Delete(T entry);

        bool Save();

        bool IsExist(int id);

    }
}
