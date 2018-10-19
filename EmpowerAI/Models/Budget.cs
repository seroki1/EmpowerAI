using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class Budget
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int Dmaid { get; set; }
        public int Percentage { get; set; }
        public decimal DollarValue { get; set; }

        public Dma Dma { get; set; }
        public Submission Submission { get; set; }
    }
}
