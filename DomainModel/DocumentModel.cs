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



        public DocSenderModel DocSender { get; set; }
        public DocNameModel DocName { get; set; }

        public string Comments { get; set; }

        public Guid CreatorUserId { get; set; }

        public int TermExecutionDayCalulated
        {
            get
            {
                int calc = 0;
                if (IsCreatedFromDictionary)
                {
                    calc = DocName.TermExecutionDays;
                }
                else
                {
                    DateTime corrected ;
                    if (DomainUtilities.IsSaturday(ControlTermExecution))
                    {
                        corrected = DomainUtilities.CorrectSaturday(ControlTermExecution);
                    }
                    else if (DomainUtilities.IsSunday(ControlTermExecution))
                    {
                        corrected = DomainUtilities.CorrectSunday(ControlTermExecution);
                    }
                    else
                    {
                        corrected = ControlTermExecution;
                    }
                    var dif= corrected - DateAdmission;

                    calc = dif.Days;
                }
                return calc;
            }


        }

        /// <summary>
        /// вычисленная дата 
        /// </summary>
        public DateTime ControlTermExecutionCalculated
        {
            get
            {
                return ControlTermExecution.AddDays(TermExecutionDayCalulated);
            }
        }

        public bool IsCreatedFromDictionary
        {
            get { return DocName != null; }
        }
        public DocumentModel()
        {
            DocSender= new DocSenderModel();
            
        }

    }
}
