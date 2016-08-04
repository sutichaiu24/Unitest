using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        private IVCaculator cal;

        [SetUp]
        public void Init ()
        {
            cal = new IVCaculator();
        }
        [TestCase(100,5,100,10,500)]
        public void InvestmentCalculator_WithValidInvestmentParamter_ShouldreturnValidFinalResult(decimal startBalance,decimal interestRatePerYear ,decimal monthlyContribution ,int contributionPeriod )
        {
            //Arrange

            //Act
            var iResult = cal.InvestmentCalculator(startBalance, interestRatePerYear, monthlyContribution, contributionPeriod);

            //Assert
            Assert.AreEqual(100, iResult.FinalValue);

          
        }

    }
}
