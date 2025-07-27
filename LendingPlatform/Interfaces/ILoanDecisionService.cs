using LendingPlatform.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingPlatform.Interfaces
{
    /// <summary>
    /// Interface for loan decision-making service.
    /// </summary>
    public interface ILoanDecisionService
    {
        LoanDecision DecideLoan(LoanApplicant applicant, Loan loan);
    }
}
