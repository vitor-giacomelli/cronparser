using CronParser.Entities;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using static CronParser.Program;

namespace Tests
{
    public class CronTests
    {
        private Cron _cronTestObject;
        private CronValidator _cronValidator;
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

        private static IEnumerable<TestCaseData> CronValidator_ValidMinuteDataSource()
        {
            return new[]
            {
                new TestCaseData("0", "0", "0", "0", "0"),
                new TestCaseData("*", "0", "0", "0", "0"),
                new TestCaseData("?", "0", "0", "0", "0")
            };
        }

        [TestCaseSource(nameof(CronValidator_ValidMinuteDataSource))]
        public void CronValidator_ValidMinute_IsValidTrue(
            string minute, 
            string hour, 
            string dayOfMonth, 
            string month, 
            string dayOfWeek)
        {
            // Arrange
            string[] cronValues = new string[5];
            cronValues[0] = minute;
            cronValues[1] = hour;
            cronValues[2] = dayOfMonth;
            cronValues[3] = month;
            cronValues[4] = dayOfWeek;

            // Act
            _cronValidator = new CronValidator(cronValues);

            // Assert
            _cronValidator.IsValid.ShouldBeTrue();
        }

        private static IEnumerable<TestCaseData> CronValidator_InvalidMinuteDataSource()
        {
            return new[]
            {
                new TestCaseData("A", "0", "0", "0", "0"),
                new TestCaseData("-", "0", "0", "0", "0"),
                new TestCaseData("BOAT", "0", "0", "0", "0")
            };
        }

        [TestCaseSource(nameof(CronValidator_InvalidMinuteDataSource))]
        public void CronValidator_InvalidMinute_IsValidFalse(
            string minute,
            string hour,
            string dayOfMonth,
            string month,
            string dayOfWeek)
        {
            // Arrange
            string[] cronValues = new string[5];
            cronValues[0] = minute;
            cronValues[1] = hour;
            cronValues[2] = dayOfMonth;
            cronValues[3] = month;
            cronValues[4] = dayOfWeek;

            // Act
            _cronValidator = new CronValidator(cronValues);

            //Assert
            _cronValidator.IsValid.ShouldBeFalse();
        }
    }
}