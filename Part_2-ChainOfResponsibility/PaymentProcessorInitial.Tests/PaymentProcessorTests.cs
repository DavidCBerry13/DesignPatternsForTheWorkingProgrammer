using PaymentProcessorInitial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentsProcessor.Tests
{
    public class PaymentProcessorTests
    {

        [Fact]
        public void TestSuccessfulCreditCardPayment()
        {
            //Arrange
            IPaymentsDao paymentsDao = new PaymentsDao();
            ICreditCardProcessor creditCardProcessor = new CreditCardProcessor();
            IEftProcessor eftProcessor = new EftProcessor();
            PaymentProcessor paymentProcessor =
                new PaymentProcessor(creditCardProcessor, eftProcessor, paymentsDao);

            CreditCardPaymentData creditCardPayment = new CreditCardPaymentData()
            {
                CreditCardNumber = SampleData.CARD_NUMBER_ONE,
                ExpirationDate = "10/2019",
                Cvv = "755",
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                BillingZipCode = "60067",
                CardholderName = "John Doe",
                PaymentType = PaymentType.CREDIT_CARD,
                Amount = 100.00m
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(creditCardPayment);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(10, result.ReferenceNumber);
        }


        [Fact]
        public void TestFailingCreditCardPayment()
        {
            //Arrange
            IPaymentsDao paymentsDao = new PaymentsDao();
            ICreditCardProcessor creditCardProcessor = new CreditCardProcessor();
            IEftProcessor eftProcessor = new EftProcessor();
            PaymentProcessor paymentProcessor =
                new PaymentProcessor(creditCardProcessor, eftProcessor, paymentsDao);

            CreditCardPaymentData creditCardPayment = new CreditCardPaymentData()
            {
                CreditCardNumber = SampleData.CARD_NUMBER_ONE,
                ExpirationDate = "10/2019",
                Cvv = "755",
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                BillingZipCode = "60067",
                CardholderName = "John Doe",
                PaymentType = PaymentType.CREDIT_CARD,
                Amount = 10000.00m
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(creditCardPayment);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(15, result.ReferenceNumber);
        }



        [Fact]
        public void TestSuccessfulEftPayment()
        {
            //Arrange
            IPaymentsDao paymentsDao = new PaymentsDao();
            ICreditCardProcessor creditCardProcessor = new CreditCardProcessor();
            IEftProcessor eftProcessor = new EftProcessor();
            PaymentProcessor paymentProcessor =
                new PaymentProcessor(creditCardProcessor, eftProcessor, paymentsDao);

            EftPaymentData eftPaymentData = new EftPaymentData()
            {
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                PaymentType = PaymentType.EFT,
                Amount = 100.00m,
                RoutingNumber = SampleData.BANK_ROUTING_ONE,
                BankAccountNumber = SampleData.BANK_ACCOUNT_ONE,
                AccountType = BankAccountType.CHECKING
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(eftPaymentData);

            // Assert
            Assert.True(result.Success);
            Assert.Equal(20, result.ReferenceNumber);
        }


        [Fact]
        public void TestFailingEftPayment()
        {
            //Arrange
            IPaymentsDao paymentsDao = new PaymentsDao();
            ICreditCardProcessor creditCardProcessor = new CreditCardProcessor();
            IEftProcessor eftProcessor = new EftProcessor();
            PaymentProcessor paymentProcessor =
                new PaymentProcessor(creditCardProcessor, eftProcessor, paymentsDao);

            EftPaymentData eftPaymentData = new EftPaymentData()
            {
                CustomerAccountNumber = "00012345",
                PaymentDate = DateTime.Today,
                PaymentType = PaymentType.EFT,
                Amount = 100.00m,
                RoutingNumber = SampleData.BANK_ROUTING_ONE,
                BankAccountNumber = SampleData.BANK_ACCOUNT_TWO,
                AccountType = BankAccountType.CHECKING
            };

            // Act
            PaymentResult result = paymentProcessor.ProcessPayment(eftPaymentData);

            // Assert
            Assert.False(result.Success);
            Assert.Equal(25, result.ReferenceNumber);
        }


    }
}

