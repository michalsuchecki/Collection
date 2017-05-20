using Collection.Services;
using Xunit;


namespace Collection.Tests
{
    public class CurrencyProviderTests
    {
        [Fact]
        public void When_changing_currecy_from_USD_to_PLN_it_should_return_correct_value()
        {
            var provider = new FakeCurrencyProvider();

            var value = provider.GetCurrency("USD", "PLN");

            Assert.Equal(3.813, value);
        }

        [Fact]
        public void When_changing_currecy_from_PLN_to_USD_it_should_return_correct_value()
        {
            var provider = new FakeCurrencyProvider();

            var value = provider.GetCurrency("PLN", "USD");

            Assert.Equal(1/3.813, value);
        }

        /*
                         { "USD", 3.813 },
                { "EUR", 4.216 },
                { "PLN", 1.0 }
             */

        [Fact]
        public void When_changing_currecy_from_EUR_to_USD_it_should_return_correct_value()
        {
            var provider = new FakeCurrencyProvider();

            var value = provider.GetCurrency("EUR", "USD");

            Assert.Equal(4.216 / 3.813, value);
        }

        [Fact]
        public void When_changing_currecy_from_USD_to_EUR_it_should_return_correct_value()
        {
            var provider = new FakeCurrencyProvider();

            var value = provider.GetCurrency("USD", "EUR");

            Assert.Equal(3.813 / 4.216, value);
        }
    }
}
