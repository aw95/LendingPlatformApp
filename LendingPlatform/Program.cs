using LendingPlatform.Entities;
using LendingPlatform.Interfaces;
using LendingPlatform.Services;

/// <summary>
/// Main program for the lending platform application.  
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        ILoanValidationService loanValidationService = new LoanValidationService();
        ILoanDecisionService loanDecisionService = new LoanDecisionService(loanValidationService);
        IReportService reportService = new ReportingService();

        bool continueApp = true;

        while (continueApp)
        {
            // User inputs
            decimal loanAmount = GetValidDecimalInput("Enter Loan Amount (in GBP): ");
            decimal assetValue = GetValidDecimalInput("Enter Asset Value (in GBP): ");
            int creditScore = GetValidIntInput("Enter Credit Score (1-999): ");

            LoanApplicant applicant = new LoanApplicant
            {
                CreditScore = creditScore
            };

            Loan loan = new Loan
            {
                Amount = loanAmount,
                AssetValue = assetValue
            };

            // Decide loan status
            LoanDecision decision = loanDecisionService.DecideLoan(applicant, loan);

            // Get the status text based on decision
            var statusText = decision.IsApproved ? LoanStatus.approved : LoanStatus.declined;

            Console.WriteLine($"Your application has been {statusText}: {decision.Reason}");

            // Log the decision
            reportService.LogLoanDecision(loan, decision);

            // Ask if the user wants to enter another application
            Console.WriteLine("Do you want to enter another loan application? (y/n): ");
            string? input = Console.ReadLine();
            continueApp = input?.ToLower() == "y";
        }

        // Show summary report
        reportService.ShowReport();
    }

    // Helper method for validating and parsing decimal input
    static decimal GetValidDecimalInput(string prompt)
    {
        decimal result;
        string? input;
        while (true)
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
            if (decimal.TryParse(input, out result) && result > 0)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number greater than 0.");
            }
        }
    }

    // Helper method for validating and parsing integer input
    static int GetValidIntInput(string prompt)
    {
        int result;
        string? input;
        while (true)
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
            if (int.TryParse(input, out result) && result >= 1 && result <= 999)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid credit score between 1 and 999.");
            }
        }
    }
}
