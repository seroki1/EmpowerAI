using System;
using System.Collections.Generic;

namespace EmpowerAI.Models
{
    public partial class CompanyInfo
    {
        public CompanyInfo()
        {
            Submission = new HashSet<Submission>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string BillAddress { get; set; }
        public string BillAddress2 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillZip { get; set; }

        public ICollection<Submission> Submission { get; set; }
        public ICollection<User> User { get; set; }
    }
}
