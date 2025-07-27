using LendingPlatform.Entities;
using LendingPlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingPlatform.Services
{
    /// <summary>
    /// Class for making loan decisions based on validation results.
    /// </summary>
    public class LoanDecisionService : ILoanDecisionService
    {
        private readonly ILoanValidationService _loanValidationService;

        public LoanDecisionService(ILoanValidationService loanValidationService)
        {
            _loanValidationService = loanValidationService;
        }

        public LoanDecision DecideLoan(LoanApplicant applicant, Loan loan)
        {
            var decision = new LoanDecision();

            // Validate the loan using the validation service
            var (isValid, message) = _loanValidationService.ValidateLoan(applicant, loan);

            decision.IsApproved = isValid;
            decision.Reason = message;            

            return decision;
        }
    }

}
