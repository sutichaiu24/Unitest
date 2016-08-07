using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        private IVCaculator cal;

        [SetUp]
        public void Init()
        {
            cal = new IVCaculator();
        }

        #region InvestmentCaculator
        [TestCase(200, 100, 100, 12, 2181.72)]
        [TestCase(100, 5, 100, 12, 1337.26)]
        public void InvestmentCalculator_WithValidInvestmentParamter_ShouldreturnValidFinalValue(decimal startBalance, decimal interestRatePerYear, decimal monthlyContribution, int contributionPeriod, decimal FV)
        {
            //Arrange

            //Act
            var iResult = cal.InvestmentCalculator(startBalance, interestRatePerYear, monthlyContribution, contributionPeriod);

            //Assert
            Assert.AreEqual(FV, iResult.FinalValue);
        }

        [TestCase(-1, -1, -1, -1)]
        [TestCase(0, -1, -1, 0)]
        [TestCase(-1, 0, 0, 0)]
        public void InvestmentCalculator_WithMinusInterestAndContribution_ShouldnotReturnFinalValueAsMinusAndThrowExpection(decimal startBalance, decimal interestRatePerYear, decimal monthlyContribution, int contributionPeriod)
        {
            //Arrange

            //Act
            try
            {
                var iResult = cal.InvestmentCalculator(startBalance, interestRatePerYear, monthlyContribution, contributionPeriod);
                Assert.IsFalse(iResult.FinalValue < 0, "FV cannot be Minus");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The Input cannot be Negative", ex.Message);

            }
            //Assert
        }

        [TestCase(int.MaxValue)]
        public void InvesmentCalculator_WithDecminalMaxtoPrincipleAndInterestRate_ShouldreturnWanringException(decimal startBalance)
        {
            //Arrange
            var interestRatePerYear = decimal.MaxValue;
            var monthlyContribution = decimal.MaxValue;
            var contributionPeriod = int.MaxValue;


            //Act
            try
            {
                var iResult = cal.InvestmentCalculator(startBalance, interestRatePerYear, monthlyContribution, contributionPeriod);

            }
            catch (System.OverflowException ex)
            {
                Assert.AreNotEqual("Value was either too large or too small for a Decimal", ex.Message);
            }

        }

        // Total = [ Compound interest for principal ] + [ Future value of a series ] 
        // Future value of a series = PMT * (((1 + r/n)^nt - 1) / (r/n))
        [Test]
        public void InvesmentCalculator_WithZeroInterestRate_ShouldreturnPrincipleCombineWithInterestWithoutZerodivisionException()
        {
            //Arrange
            var interestRatePerYear = 0;
            var startBalance = 100;
            var monthlyContribution = 100;
            var contributionPeriod = 12;

            //Act
            try
            {
                var iResult = cal.InvestmentCalculator(startBalance, interestRatePerYear, monthlyContribution, contributionPeriod);
                Assert.AreEqual(1200, iResult.FinalValue);
            }
            catch (DivideByZeroException e)
            {
                Debug.Write(e.Message);
                Assert.Fail();
            }
            //Assert
           
        }
        #endregion

        #region GetInterestRatePerYear
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(50)]
        public void GetInterestRatePerYear_WithPositiveValue_ShouldReturnValidInterestRatePerYear(decimal IRP)
        {
            //Arrange
            var startBalance = 1;
            var interRatePerYear = IRP;
            var monthlyContribution = 1;
            var contributionPeriod = 5;

            //Act
            var iResult = cal.InvestmentCalculator(startBalance, IRP, monthlyContribution, contributionPeriod);
            var interestRatePerYear = cal.GetInterestRatePerYear();

            //Assert
            Assert.AreEqual(IRP, interestRatePerYear);

        }
        #endregion
    }
}
