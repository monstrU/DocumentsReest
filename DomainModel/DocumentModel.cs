namespace DomainModel
{
    using System;

    public class DocumentModel
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public int DocNumber { get; set; }
        public DateTime DateAdmission { get; set; }
    }
}
