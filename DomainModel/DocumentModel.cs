namespace DomainModel
{
    using System;

    public class DocumentModel
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public int DocNumber { get; set; }
        
        /// <summary>
        /// дата приема
        /// </summary>
        public DateTime DateAdmission { get; set; }
        
        /// <summary>
        /// срок исполнения
        /// </summary>
        public DateTime TermExecution { get; set; }

        /// <summary> 
        /// контрольная дата исполнения
        /// </summary>
        public DateTime ControlTermExecution { get; set; }

        public string SenderName { get; set; }

        public DocSenderModel DocSender   { get; set; }
        public DocNameModel DocName { get; set; }

        public string Comments { get; set; }

    }
}
