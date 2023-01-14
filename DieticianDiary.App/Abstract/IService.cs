namespace DieticianDiary.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetAllItems(T patient);
        int GetLastId();
        T GetItemById (int id);
        int AddItem(T patient);
        int UpdateItem(T patient);
        void RemoveItem(T patient);
    }
}
