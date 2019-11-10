using CronParser.Entities;
using NUnit.Framework;
using Shouldly;

namespace Tests
{
    public class CronTests
    {
        private Cron _cronTestObject;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CronConstrutor_ValidParams_CorrectFields()
        {
            // Arrange
            _cronTestObject = new Cron("0", "0", "0", "0", "0");

            // Act, Assert
            this.ShouldSatisfyAllConditions(
                () => _cronTestObject.Minute.ShouldBe("0"),
                () => _cronTestObject.Hour.ShouldBe("0"),
                () => _cronTestObject.Month.ShouldBe("0"),
                () => _cronTestObject.DayOfMonth.ShouldBe("0"),
                () => _cronTestObject.DayOfWeek.ShouldBe("0"));
        }
    }
}