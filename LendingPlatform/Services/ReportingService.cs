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
    /// Class for logging/showing data for reports on loan decisions.
    /// The reports are shown once the user has finished applying for loans.
    /// For a production version of the app, this would be replaced with a different solution 
    /// to generate the reports at any time, and handle large datasets (e.g. some examples: a seperate 
    /// microservice for reporting stats, background services to retrieve data, stored procedures etc.)
    /// </summary>
    public class ReportingService : IReportService
    {
        private int _totalApplicants = 0;
        private int _approvedLoans = 0;
        private decimal _totalLoanAmount = 0;
        private decimal _totalLTV = 0;

        public void LogLoanDecision(Loan loan, LoanDecision decision)
        {
            _totalApplicants++;
            if (decision.IsApproved)
            {
                // If approved, update the report data
                _approvedLoans++;
                _totalLoanAmount += loan.Amount;
                _totalLTV += (loan.Amount / loan.AssetValue) * 100;
            }
        }

        public void ShowReport()
        {
            // Check if there are any approved loans to avoid division by zero
            decimal meanLTV = _approvedLoans > 0 ? _totalLTV / _approvedLoans : 0;

            Console.WriteLine($"Total Applicants: {_totalApplicants}");
            Console.WriteLine($"Approved Loans: {_approvedLoans}");
            Console.WriteLine($"Total Loan Value: {_totalLoanAmount:C}");
            Console.WriteLine($"Mean LTV: {meanLTV:F2}%");
        }
    }

}
