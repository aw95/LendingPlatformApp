using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingPlatform.Entities
{
    /// <summary>
    ///     Entity for a loan.
    /// </summary>
    public class Loan
    {
        public decimal Amount { get; set; }
        public decimal AssetValue { get; set; }
        public virtual LoanApplicant Applicant { get; set; } = default!;
        public virtual LoanDecision Decision { get; set; } = default!; 
    }
}
