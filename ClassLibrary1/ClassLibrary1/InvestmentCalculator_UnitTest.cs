using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.VisualBasic;


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

        [TestCase(200, 100, 100, 12, 2181.72)]
        [TestCase(100, 5, 100, 12,1337.26)]
        public void InvestmentCalculator_WithValidInvestmentParamter_ShouldreturnValidFinalValue(decimal startBalance, decimal interestRatePerYear, decimal monthlyContribution, int contributionPeriod ,decimal FV)
        {
            //Arrange

            //Act
            var iResult = cal.InvestmentCalculator(startBalance, interestRatePerYear, monthlyContribution, contributionPeriod);

            //Assert
            Assert.AreEqual(FV, iResult.FinalValue);
        }
        [TestCase(-1,-1,-1,-1)]
        [TestCase(0,-1,0,0,0)]
        [TestCase(0,0,-1,0,0)]
        [TestCase(0,0,0,0,-1)]
        public void InvestmentCalculator_WithMinusValue_ShouldreturnProperException(decimal startBalance, decimal interestRatePerYear, decimal monthlyContribution, int contributionPeriod, decimal FV)
        {
            try
            {
                var iResult = cal.InvestmentCalculator(startBalance, interestRatePerYear, monthlyContribution, contributionPeriod);
                Assert.Fail();
            }
            catch(Exception e)
            {
                Assert.AreEqual("Param cannot be minus", e.Message);
                Assert.Pass();
            }
            
        }
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
       [Test]

    }
}
