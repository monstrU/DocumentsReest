﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class DocNameModel
    {
        public int DocNameId { get; set; }

        public string Name { get; set; }

        public int TermExecutionDays { get; set; }
    }
}
