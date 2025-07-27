using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LendingPlatform.Entities
{
    /// <summary>
    /// Entity for a loan applicant.
    /// Currently only the credit score is stored, however a dedicated entity allows for capturing further info for an applicant.
    /// </summary>
    public class LoanApplicant
    {
        public int CreditScore { get; set; }
    }
}
