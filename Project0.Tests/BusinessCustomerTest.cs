using Project0.BusinessLogic;
using Xunit;

namespace Project0.Tests
{
    public class BusinessCustomerTest
    {
        [Fact]
        public void TestBusinessCustomerFirstNameNotEmpty()
        {
            BusinessCustomer customer = new BusinessCustomer();

            Assert.Throws<BusinessCustomerException>(() => customer.FirstName = "");
        }

        [Fact]
        public void TestBusinessCustomerLastNameNotEmpty()
        {
            BusinessCustomer customer = new BusinessCustomer();

            Assert.Throws<BusinessCustomerException>(() => customer.LastName = "");
        }

        [Theory]
        [InlineData("Neil El abbadi Janifer Allain Milo Thanos Marika Paulson")]
        [InlineData("Kris Raiskin Margaux Marchand Welby Pedreira")]
        [InlineData("Perry Ziesenhenne Jack Panasyuk Fifi Nichols-fonseca")]
        public void TestBusinessCustomerFirstNameTooLong(string firstName)
        {
            BusinessCustomer customer = new BusinessCustomer();

            Assert.Throws<BusinessCustomerException>(() => customer.FirstName = firstName);
        }

        [Theory]
        [InlineData("alfred jeffrey john mcalister friedrick caleb von showman the fourth")]
        [InlineData("Chadwick Lauritsen Sacha Ardolino Antonius Noremberg Mair Barberis")]
        [InlineData("Bud Topulos Nadiya Belcher Henderson Nennig Filia Marx")]
        public void TestBusinessCustomerLastNameTooLong(string lastName)
        {
            BusinessCustomer customer = new BusinessCustomer();

            Assert.Throws<BusinessCustomerException>(() => customer.LastName = lastName);
        }

        [Theory]
        [InlineData("Lazar!")]
        [InlineData("Me.ta")]
        [InlineData("#Chadwick")]
        public void TestBusinessCustomerFirstNameNotAlphabetical(string firstName)
        {
            BusinessCustomer customer = new BusinessCustomer();

            Assert.Throws<BusinessCustomerException>(() => customer.FirstName = firstName);
        }

        [Theory]
        [InlineData("mcgreggery!")]
        [InlineData("Milito3")]
        [InlineData("2Pfarrer")]
        public void TestBusinessCustomerLastNameNotAlphabetical(string lastName)
        {
            BusinessCustomer customer = new BusinessCustomer();

            Assert.Throws<BusinessCustomerException>(() => customer.LastName = lastName);
        }

        [Theory]
        [InlineData("jeff", "Jeff")]
        [InlineData("mAcY", "Macy")]
        [InlineData("BOB", "Bob")]
        [InlineData("fLORA", "Flora")]
        [InlineData("jowEl", "Jowel")]
        public void TestBusinessCustomerFirstNameCapitalized(string firstName, string expected)
        {
            BusinessCustomer customer = new BusinessCustomer();
            customer.FirstName = firstName;

            Assert.Equal(expected, customer.FirstName);
        }

        [Theory]
        [InlineData("mackenzie", "Mackenzie")]
        [InlineData("Shneider", "Shneider")]
        [InlineData("GLOBA", "Globa")]
        [InlineData("mcGreggEry", "Mcgreggery")]
        public void TestBusinessCustomerLastNameCapitalized(string lastName, string expected)
        {
            BusinessCustomer customer = new BusinessCustomer();
            customer.LastName = lastName;

            Assert.Equal(expected, customer.LastName);
        }
    }
}
