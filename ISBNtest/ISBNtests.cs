using Moq;
using Xunit;
using Projekt.Control;
using Projekt.Interfaces;

namespace ISBNtest
{
    public class ISBNtests
    {
        // -------------------------------------------------------------------------
        // - Testar: Validate
        // - Retunerar: True
        // Detta test testar metoden: Validate och Retunerar: True då vi testar den med en Giltig ett ISBN nummer
        [Fact]
        public void Validate_ValidISBN_ReturnsTrue()
        {
            string validIsbn = "9783161484100";
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(validIsbn);
            Assert.True(isValid);
        }

        // -------------------------------------------------------------------------
        // - Testar: Validate
        // - Retunerar: False
        // Detta test testar metoden Validate och retunerar False då vi testar en ett ogitligt ISBN nummber.
        [Fact]
        public void Validate_InvalidISBN_ReturnsFalse()
        {
            string invalidIsbn = "1234567890123";
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(invalidIsbn);
            Assert.False(isValid);
        }

        // -------------------------------------------------------------------------
        // - Testar:
        // - Retunerar:
        // 
        [Fact]
        public void IsValidISBN_EmptyISBN_ReturnsFalse()
        {
            string emptyISBN = string.Empty;
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(emptyISBN);
            Assert.False(isValid);
        }

        // -------------------------------------------------------------------------
        // - Testar:
        // - Retunerar:
        //
        [Fact]
        public void IsValidISBN_NullISBN_ReturnsFalse()
        {
            string nullIsbn = null;
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(nullIsbn);
            Assert.False(isValid);
        }

        // -------------------------------------------------------------------------
        // - Testar:
        // - Retunerar:
        //
        [Fact]
        public void IsValidISBN_TooShortISBN_ReturnsFalse()
        {
            string tooShortISBN = "1234";
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(tooShortISBN);
            Assert.False(isValid);
        }

        // -------------------------------------------------------------------------
        // - Testar:
        // - Retunerar:
        //
        [Fact]
        public void IsValidISBN_TooLongISBN_ReturnsFalse()
        {
            string tooLongISBN = "1234567890123456";
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(tooLongISBN);
            Assert.False(isValid);
        }

        // -------------------------------------------------------------------------
        // - Testar:
        // - Retunerar:
        //
        [Fact]
        public void IsValidISBN_InvalidCheckDigit_ReturnsFalse()
        {
            string invalidCheckDigitIsbn = "9783161484101";
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(invalidCheckDigitIsbn);
            Assert.False(isValid);
        }


        // -------------------------------------------------------------------------
        // - Testar:
        // - Retunerar:
        //
        [Fact]
        public void IsValidISBN_NonNumericInput_ReturnsFalse()
        {
            string nonNumericIsbn = "hello";
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(nonNumericIsbn);
            Assert.False(isValid);
        }

        // ---------------------------------------------------------------------------------------------------------------------------------
        // - - - - - - - - - - Theory Tests - - - - - - - - - -

        [Theory]
        [InlineData("1234567890123")]
        [InlineData("9783161484102")]
        public void IsValidISBN_InvalidISBN_ReturnsFalse2(string isbn)
        {
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(isbn);
            Assert.False(isValid);
        }

        // ---------------------------------------------------------------------------------------------------------------------------------
        // - - - - - - - - - -  Mocking  - - - - - - - - - -

        [Fact]
        public void IsValidISBN_Mock_ReturnsFalse()
        {
            string InvalidISBN = "1234567891234";
            var Mock_Validation = new Mock<InterfaceISBN>();
            Mock_Validation.Setup(x => x.IsValidISBN(InvalidISBN)).Returns(false);
            InterfaceISBN validator = Mock_Validation.Object;

            bool isValid = validator.IsValidISBN(InvalidISBN);
            Assert.False(isValid);
        }

        [Fact]
        public void GetBookInfo_ValidISBN_ReturnsAuthorAndTitle()
        {
            string ValidISBN = "9783161484100";
            string expectedAuthor = "Test Name";
            string expectedTitle = "Book Test";

            var Mock_DB = new Mock<IDatabase>();
            Mock_DB.Setup(d => d.ReturnAuthor(ValidISBN)).Returns(expectedAuthor);
            Mock_DB.Setup(d => d.ReturnTitle(ValidISBN)).Returns(expectedTitle);

            var DB = Mock_DB.Object;
            string author = DB.ReturnAuthor(ValidISBN);
            string title = DB.ReturnTitle(ValidISBN);

            Assert.Equal(expectedAuthor, author);
            Assert.Equal(expectedTitle, title);
        }

        // --------------------------------------------------------------------------------
        // # # # # # # # # # # # # # # # # # New Tests # # # # # # # # # # # # # # # # #
        // --------------------------------------------------------------------------------

        // Decimal Input
        // Negativ Input
        // Website Mock

        // -------------------------------------------------------------------------
        // - Testar: IsValidISBN
        // - Retunerar: False
        // IsValidISBN testas med en decimal input (bad input) 
        [Fact]
        public void IsValidISBN_DecimalInput_ReturnsFalse()
        {
            string decimalISBN = "9783161484.100";
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(decimalISBN);
            Assert.False(isValid);
        }

        // -------------------------------------------------------------------------
        // - Testar: IsValidISBN
        // - Retunerar: False
        // IsValidISBN testas med en negativ input för att säkerställa att det hanteras korrekt.
        // Alltså att den retunerar False
        [Fact]
        public void IsValidISBN_NegativeInput_ReturnsFalse()
        {
            string negativeISBN = "-9783161484100";
            InterfaceISBN validator = new ISBNValidator();
            bool isValid = validator.IsValidISBN(negativeISBN);
            Assert.False(isValid);
        }

        // -------------------------------------------------------------------------
        // - Testar: IsValidISBN
        // - Retunerar:

        [Fact]
        public void GetBookAuthor_ValidISBN_ReturnsAuthor()
        {
            string ValidISBN = "9783161484100";
            string expectedAuthor = "Test Author";

            var FakeWebsite = new Mock<IWebsite>();
            FakeWebsite.Setup(w => w.GetBookAuthor(ValidISBN)).Returns(expectedAuthor);

            var Website = FakeWebsite.Object;
            string author = Website.GetBookAuthor(ValidISBN);

            Assert.Equal(expectedAuthor, author);
        }

        [Fact]
        public void GetBookTitle_ValidISBN_ReturnsTitle()
        {
            string ValidISBN = "9783161484100";
            string expectedTitle = "Test Title";

            var FakeWebsite = new Mock<IWebsite>();
            FakeWebsite.Setup(w => w.GetBookTitle(ValidISBN)).Returns(expectedTitle);

            var Website = FakeWebsite.Object;
            string title = Website.GetBookTitle(ValidISBN);

            Assert.Equal(expectedTitle, title);
        }

    }
}