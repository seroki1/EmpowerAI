using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class SubmissionDma
    {
        public long Id { get; set; }
        public int SubmissionId { get; set; }
        public int Dmaid { get; set; }

        public Dma Dma { get; set; }
        public Submission Submission { get; set; }
    }
}
