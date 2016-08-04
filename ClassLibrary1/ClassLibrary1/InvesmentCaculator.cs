using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ClassLibrary1
{
    public class IVCaculator
    {  
        public struct Result
        {
            public decimal FinalValue;
            public decimal CompoundInterestRate;
            public decimal TotalContributions;
            public decimal InterestEarnedOverTime;
            
        }
        public Result InvestmentCalculator(decimal startBalance,decimal interesRatePerYear,decimal monthlyContribution ,int contributionPeriod)
        {
            Result result;
            result.FinalValue = 5;
            result.CompoundInterestRate = 10;
            result.TotalContributions = 10;
            result.InterestEarnedOverTime = 10;

            return result; 
        }
        public decimal GetInterestRatePerYear()
        {
            return 0.5m ;
        }
    }
}
