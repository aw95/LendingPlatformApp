using LendingPlatform.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingPlatform.Interfaces
{
    /// <summary>
    /// Interface for loan validation service.
    /// </summary>
    public interface ILoanValidationService
    {
        (bool isValid, string message) ValidateLoan(LoanApplicant applicant, Loan loan);
    }
}
