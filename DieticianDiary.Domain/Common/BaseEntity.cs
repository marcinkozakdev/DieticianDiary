﻿using System.Xml.Serialization;

namespace DieticianDiary.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
    }
}
