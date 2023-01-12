namespace DieticianDiary.App.Abstract
{
    public interface IService<T>
    {
        List<T> Patients { get; set; }
        List<T> GetAllPatients(T patient);
        int AddPatient(T patient);
        int UpdatePatient(T patient);
        void RemovePatient(T patient);
    }
}
