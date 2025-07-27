using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingPlatform.Entities
{
    /// <summary>
    /// Entity for a loan decision.
    /// If this application did not make an immediate decision on the loan, IsApproved could be a nullable field.
    /// </summary>
    public class LoanDecision
    {
        public bool IsApproved { get; set; }
        public string? Reason { get; set; }

    }
}
