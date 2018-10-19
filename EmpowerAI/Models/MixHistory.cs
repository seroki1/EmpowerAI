using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class MixHistory
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public string FileLocation { get; set; }

        public Submission Submission { get; set; }
    }
}
