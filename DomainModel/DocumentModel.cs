using System.Net.NetworkInformation;

namespace DomainModel
{
    using System;

    public class DocumentModel
    {
        public int DocumentId { get; set; }

        public int DocNumber { get; set; }

        public DateTime Created { get; set; }

        /// <summary>
        /// название документа 
        /// </summary>
        public string Name { get; set; }

        public string NameCalculated
        {
            get
            {
                string name;
                name = IsCreatedFromDictionary ? DocName.Name : Name;
                return name;
            }
        }
        /// <summary>
        /// дата приема
        /// </summary>
        public DateTime DateAdmission { get; set; }

        /// <summary>
        /// срок исполнения
        /// </summary>
        public Nullable<int> TermExecution { get; set; }

        public int TermExecutionCalculated
        {
            get
            {
                int exec = IsCreatedFromDictionary ? DocName.TermExecutionDays : TermExecution.GetValueOrDefault();
                return exec;
            }
        } 
        
        public DocSenderModel DocSender { get; set; }
        public DocNameModel DocName { get; set; }

        public string Comments { get; set; }

        public Guid CreatorUserId { get; set; }



        /// <summary>
        /// вычисленная контрольная дата  исполнения
        /// </summary>
        public DateTime ControlTermExecutionCalculated
        {
            get
            {

                DateTime corrected = DateAdmission.AddDays(TermExecutionCalculated);

                if (DomainUtilities.IsSaturday(corrected))
                {
                    corrected = DomainUtilities.CorrectSaturday(corrected);
                }
                else if (DomainUtilities.IsSunday(corrected))
                {
                    corrected = DomainUtilities.CorrectSunday(corrected);
                }
                return corrected;
            }
        }

        public bool IsCreatedFromDictionary
        {
            get { return DocName != null; }
        }
        public DocumentModel()
        {
            DocSender = new DocSenderModel();

        }

    }
}
