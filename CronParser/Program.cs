using CronParser.Entities;
using System;

namespace CronParser
{
    public class Program
    {
        private static string[] _valueList;
        private static string _minuteField;
        private static string _hourField;
        private static string _dayOfMonthField;
        private static string _monthField;
        private static string _dayOfWeekField;

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Cron string");
            _valueList = new string[5];
            var cronString = Console.ReadLine();
            ValidateCronString(cronString);
            try
            {
                Console.WriteLine(_minuteField.Length == 1 ? string.Format("Minute {0,15:#,##0}", Convert.ToInt32(_minuteField)) : string.Format("Minute {0,16:#,##0}", Convert.ToInt32(_minuteField)));
                int hourField = 0;
                bool isSimpleHourField = int.TryParse(_hourField, out hourField);

                if (isSimpleHourField)
                    Console.WriteLine("Hour {0,17:#,##0}", _hourField);
                else
                {
                    if (_hourField == ("?") || _hourField == "*")
                    {
                        Console.Write("Hour {0,17:#,##0}", 1);
                        PrintFieldWithStartAndEnd(1, 24);
                    }
                    else
                    {
                        var hourFieldList = _hourField.Split('-');
                        int hourFieldStart = Convert.ToInt32(hourFieldList[0]);
                        int hourFieldEnd = Convert.ToInt32(hourFieldList[1]);
                        Console.Write("Hour {0,17:#,##0}", hourFieldStart);
                        PrintFieldWithStartAndEnd(hourFieldStart, hourFieldEnd);
                    }
                }

                if (_dayOfMonthField == ("?") || _dayOfMonthField == "*")
                {
                    Console.Write("Day of Month {0,9:#,##0}", 1);
                    PrintFieldWithStartAndEnd(1, 31);
                }
                else
                {
                    var dayOfMonthField = _dayOfMonthField.Split('-');
                    int dayOfMonthFieldStart = Convert.ToInt32(dayOfMonthField[0]);
                    int dayOfMonthFieldEnd = Convert.ToInt32(dayOfMonthField[1]);
                    Console.Write("Day of Month {0,9:#,##0}", dayOfMonthFieldStart);
                    PrintFieldWithStartAndEnd(dayOfMonthFieldStart, dayOfMonthFieldEnd);
                }

                if (_monthField == ("?") || _monthField == "*")
                {
                    Console.Write("Month {0,16:#,##0}", 1);
                    PrintFieldWithStartAndEnd(1, 12);
                }
                else
                {
                    var monthField = _monthField.Split('-');
                    int monthFieldStart = Convert.ToInt32(monthField[0]);
                    int monthFieldEnd = Convert.ToInt32(monthField[1]);
                    Console.Write("Month {0,16:#,##0}", monthFieldStart);
                    PrintFieldWithStartAndEnd(monthFieldStart, monthFieldEnd);
                }

                if (_dayOfWeekField == ("?") || _dayOfWeekField == "*")
                {
                    Console.Write("Day of Week {0,9:#,##0}", 0);
                    PrintFieldWithStartAndEnd(0, 6);
                }
                else
                {
                    var dayOfWeekField = _dayOfWeekField.Split(',');
                    Console.Write("Day of Week {0,9:#,##0}", string.Empty);
                    for (int i = 0; i < dayOfWeekField.Length; i++)
                    {
                        PrintDayOfWeek(dayOfWeekField[i]);
                    }
                    BreakLine();
                }
                Console.ReadKey();
            }
            catch (Exception){}
        }

        private static void PrintDayOfWeek(string dayOfWeekField)
        {
            switch (dayOfWeekField.ToLower())
            {
                case "monday":
                case "mon":
                    Console.Write($"{1} ");
                    break;
                case "tuesday":
                case "tue":
                    Console.Write($"{2} ");
                    break;
                case "wednesday":
                case "wed":
                    Console.Write($"{3} ");
                    break;
                case "thursday":
                case "thu":
                    Console.Write($"{4} ");
                    break;
                case "friday":
                case "fri":
                    Console.Write($"{5} ");
                    break;
                case "saturday":
                case "sat":
                    Console.Write($"{6} ");
                    break;
                case "sunday":
                case "sun":
                    Console.Write($"{0} ");
                    break;
                default:
                    break;
            }
        }

        private static void BreakLine()
        {
            Console.Write("\n");
        }

        private static void PrintFieldWithStartAndEnd(int fieldStart, int fieldEnd)
        {
            for (int i = fieldStart + 1; i <= fieldEnd; i++)
            {
                Console.Write($" {i}");
            }
            BreakLine();
        }

        private static void ValidateCronString(string cronString)
        {
            try
            {
                var valueList = cronString.Split(' ');
                CronValidator cron = new CronValidator();
                if (valueList.Length != 5)
                {
                    cron.IsValid = false;
                    throw new InvalidCastException();
                }
                else
                {
                    cron = new CronValidator(valueList);
                    if (cron.IsValid = false)
                        throw new InvalidOperationException();

                    _valueList = valueList;
                    _minuteField = _valueList[0];
                    _hourField = _valueList[1];
                    _dayOfMonthField = _valueList[2];
                    _monthField = _valueList[3];
                    _dayOfWeekField = _valueList[4];
                }

            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid Cron. Please run application again");
                Console.ReadKey();
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid Cron lenght. Please enter five values separated by a single space.");
                Console.ReadKey();
            }
        }

        public class CronValidator
        {
            public bool IsValid { get; set; }
            public Cron CronValues{ get; set; }
            public int MinuteField { get; set; }

            public CronValidator()
            {

            }
            public CronValidator(string[] values)
            {
                CronValues = new Cron(values[0], values[1], values[2], values[3], values[4]);
                ValidateMinuteField();
                ValidateHourField();
                ValidateDayOfMonthField();
                ValidateMonthField();
                ValidateDayOfWeekField();
            }

            public void ValidateMinuteField()
            {
                try
                {
                    if (CronValues.Minute == "*" || CronValues.Minute == "?")
                        IsValid = true;
                    else
                    {
                        int minuteField = 0;
                        IsValid = int.TryParse(CronValues.Minute, out minuteField);
                        MinuteField = minuteField;
                    }

                    if (!IsValid)
                        throw new Exception("Invalid minute");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }

            }
            public void ValidateHourField()
            {
                
            }
            public void ValidateDayOfMonthField()
            {
                
            }
            public void ValidateMonthField()
            {
                
            }
            public void ValidateDayOfWeekField()
            {
                
            }
        }
    }
}
