using DieticianDiary.App.Abstract;
using DieticianDiary.Domain.Common;

namespace DieticianDiary.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Patients { get; set; }
        public BaseService()
        {
            Patients = new List<T>();
        }

        public int GetLastId()
        {
            int lastId;
            if (Patients.Any())
                lastId = Patients.OrderBy(p => p.Id).LastOrDefault().Id;  
            else lastId = 0;
            return lastId;
        }

        public int AddPatient(T patient)
        {
            Patients.Add(patient);
            return patient.Id;
        }

        public List<T> GetAllPatients(T patient)
        {
            return Patients;
        }

        public int GetPatient(T patient)
        {
            var entity = Patients.FirstOrDefault(p => p.Id == patient.Id);
            return entity.Id;
        }

        public void RemovePatient(T patient)
        {
            Patients.Remove(patient);
        }

        public int UpdatePatient(T patient)
        {
            var entity = Patients.FirstOrDefault(p => p.Id == patient.Id);

            if (entity != null)
                entity = patient;

            return entity.Id;
        }
    }
}
