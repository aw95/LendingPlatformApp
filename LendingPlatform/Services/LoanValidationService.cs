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
    /// Class for validating loan applications.
    /// For a production version, the logic in this class could be refactored 
    /// into their own classes (a class for loan amount validation, a class for 
    /// LTV validation etc.). This would help with maintainability & scailability.
    /// Using the refactored classes, it would be easier to strip out the loan amount, 
    /// ltv, and credit score values into constants, also for easier maintainability & scailability. 
    /// </summary>
    public class LoanValidationService : ILoanValidationService
    {
        public (bool isValid, string message) ValidateLoan(LoanApplicant applicant, Loan loan)
        {
            if (loan.Amount < 100000 || loan.Amount > 1500000)
                return (false, "Loan amount is not within the acceptance range.");

            // Calculate Loan-to-Value (LTV) ratio
            decimal ltv = (loan.Amount / loan.AssetValue) * 100;

            if (ltv >= 90)
                return (false, "Loan-to-Value (LTV) is greater than or equal to 90%.");

            if (loan.Amount >= 1000000)
            {
                if (ltv > 60)
                    return (false, "For loans greater than or equal to £1 million, LTV must be 60% or less.");

                if (applicant.CreditScore < 950)
                    return (false, "For loans greater than or equal to £1 million, credit score must be greater than or equal to 950.");
            }
            else
            {
                if (ltv < 60 && applicant.CreditScore < 750)
                    return (false, "For LTV less than 60%, credit score must be greater than or equal to 750.");

                else if (ltv >= 60 && ltv < 80 && applicant.CreditScore < 800)
                    return (false, "For LTV less than 80%, credit score must be greater than or equal to 800.");

                else if (ltv >= 80 && ltv < 90 && applicant.CreditScore < 900)
                    return (false, "For LTV less than 90%, credit score must be greater than or equal to 900.");
            }

            return (true, "All acceptance criteria is met.");
        }
    }

}
