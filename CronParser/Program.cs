using System;

namespace CronParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Cron string");
            var cronString = Console.ReadLine();
            ValidateCronString(cronString);
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
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid Cron lenght. Please enter five values separated by a single space.");
                Console.ReadKey();
            }
            

        }
    }
}
