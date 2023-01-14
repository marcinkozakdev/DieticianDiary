using System.Xml.Serialization;

namespace DieticianDiary.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        public int Id { get; set; }
    }
}
