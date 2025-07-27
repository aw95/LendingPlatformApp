using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingPlatform.Entities
{
    /// <summary>
    /// Enum representing the status of a loan application.
    /// More statuses can be added in the future as needed.
    /// </summary>
    public enum LoanStatus
    {
        approved,
        declined
    }
}
