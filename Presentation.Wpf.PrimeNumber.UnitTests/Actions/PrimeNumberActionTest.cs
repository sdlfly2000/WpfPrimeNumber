using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.Wpf.PrimeNumber.Actions;

namespace Presentation.Wpf.PrimeNumber.UnitTests.Actions
{
    [TestClass]
    public class PrimeNumberActionTest
    {
        private PrimeNumberAction _action;

        [TestInitialize]
        public void TestInitialize()
        {
            _action = new PrimeNumberAction();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void PrimeNumberAction_GIVEN_A_prime_number_WHEN_IsPrimeNumber_THEN_true_return()
        {
            // Arrange
            var primeNumber = 17;

            // Act
            var result = _action.IsPrimeNumber(primeNumber);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void PrimeNumberAction_GIVEN_A_prime_number_WHEN_IsPrimeNumberImproved_THEN_true_return()
        {
            // Arrange
            var primeNumber = 17;

            // Act
            var result = _action.IsPrimeNumberImproved(primeNumber);

            // Assert
            Assert.IsTrue(result);
        }
    }


}
