using LendingPlatform.Entities;
using LendingPlatform.Services;
using Xunit;

namespace LendingPlatform.Tests
{
    /// <summary>
    ///     xUnit tests for the LoanValidationService.
    ///     Added two quick tests, if I had more time I would have added more tests for the other acceptance criteria.
    /// </summary>
    public class LoanValidationServiceTests
    {
        private readonly LoanValidationService _loanValidationService;

        public LoanValidationServiceTests()
        {
            _loanValidationService = new LoanValidationService();
        }

        // Test 1: Loan amount is less than £100,000
        [Fact]
        public void ValidateLoan_LoanAmountBelow100000_ReturnsInvalidMessage()
        {
            var applicant = new LoanApplicant { CreditScore = 800 };
            var loan = new Loan { Amount = 50000, AssetValue = 200000 };

            var result = _loanValidationService.ValidateLoan(applicant, loan);

            Assert.False(result.isValid);
            Assert.Equal("Loan amount is not within the acceptance range.", result.message);
        }

        // Test 2: Loan amount is greater than £1.5 million
        [Fact]
        public void ValidateLoan_LoanAmountAbove1500000_ReturnsInvalidMessage()
        {
            var applicant = new LoanApplicant { CreditScore = 800 };
            var loan = new Loan { Amount = 2000000, AssetValue = 2500000 };

            var result = _loanValidationService.ValidateLoan(applicant, loan);

            Assert.False(result.isValid);
            Assert.Equal("Loan amount is not within the acceptance range.", result.message);
        }
    }
}
