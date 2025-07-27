using LendingPlatform.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingPlatform.Interfaces
{
    /// <summary>
    /// Interface for report service that logs loan decisions and displays reports.
    /// </summary>
    public interface IReportService
    {
        void LogLoanDecision(Loan loan, LoanDecision decision);
        void ShowReport();
    }
}
