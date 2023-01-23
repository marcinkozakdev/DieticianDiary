namespace DieticianDiary.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetAllItems(T items);
        int GetLastId();
        T GetItemById (int id);
        int AddItem(T item);
        int UpdateItem(T item);
        void RemoveItem(T item);
    }
}
