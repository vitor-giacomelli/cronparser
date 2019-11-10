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
            Console.WriteLine(_minuteField.Length == 1? string.Format("Minute {0,15:#,##0}", _minuteField) : string.Format("Minute {0,16:#,##0}", _minuteField));
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
            
            
            Console.ReadKey();
        }

        private static void PrintFieldWithStartAndEnd(int fieldStart, int fieldEnd)
        {
            for (int i = fieldStart + 1; i <= fieldEnd; i++)
            {
                Console.Write($" {i}");
            }
            Console.Write("\n");
        }

        private static void ValidateCronString(string cronString)
        {
            try
            {
                var valueList = cronString.Split(' ');
                if (valueList.Length != 5)
                {
                    throw new InvalidCastException();
                }
                else
                {
                    _valueList = valueList;
                    _minuteField = _valueList[0];
                    _hourField = _valueList[1];
                    _dayOfMonthField = _valueList[2];
                    _monthField = _valueList[3];
                    _dayOfWeekField = _valueList[4];
                }

            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid Cron lenght. Please enter five values separated by a single space.");
                Console.ReadKey();
            }


        }
    }
}
