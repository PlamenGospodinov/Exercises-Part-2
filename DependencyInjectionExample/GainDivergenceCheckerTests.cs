using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    [TestFixture]
    public class GainDivergenceCheckerTests
    {
        [Test]
        [TestCase(100, 100, 100, 100, true)]
        [TestCase(100, 200, 100, 200, true)]
        [TestCase(50, 100, 50, 100, true)]
        [TestCase(50, 100, 50, 50, false)]
        [TestCase(100, 100, 50, 50, false)]
        public void HasDivergence_ReturnsCorrectResult(decimal accounterSales,decimal accounterReturned,
            decimal frSales,decimal frReturned,bool expectedResult )
        {
            IAccounter accounter = new TestableAccounter()
            {
                SalesSum = accounterSales,
                SumOfReturnedTickets = accounterReturned
            };

            IFiscalRegistrator fr = new TestableFr()
            {
                SalesSum = frSales,
                SumOfReturnedTickets = frReturned
            };
            var checker = new GainDivergenceChecker(accounter, fr);
            bool result = checker.HasDivergence();

            Assert.AreEqual(expectedResult, result);
        }


    }

    public class TestableAccounter : IAccounter
    {
        public decimal SalesSum { get; set; }
        public decimal SumOfReturnedTickets { get; set; }
        public decimal GetSalesSum()
        {
            return SalesSum;
        }

        public decimal GetSumOfReturnedTickets()
        {
            return SumOfReturnedTickets;
        }
    }

    public class TestableFr : IFiscalRegistrator
    {
        public decimal SalesSum { get; set; }
        public decimal SumOfReturnedTickets { get; set; }
        public decimal GetSalesSum()
        {
            return SalesSum;
        }

        public decimal GetSumOfReturnedTickets()
        {
            return SumOfReturnedTickets;
        }
    }
}
