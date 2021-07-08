using System;

namespace WorkDays
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime[] holidays = new DateTime[]
            {
                new DateTime(2020, 12, 24),
                new DateTime(2020, 12, 25),
                new DateTime(2021, 01, 01),
                new DateTime(2021, 01, 02),
                new DateTime(2021, 03, 02),
                new DateTime(2021, 03, 03),
                new DateTime(2021, 04, 10),
                new DateTime(2021, 04, 13),
                new DateTime(2021, 05, 01),
                new DateTime(2021, 05, 06),
                new DateTime(2021, 09, 21),
                new DateTime(2021, 09, 22),
                new DateTime(2021, 12, 24),
                new DateTime(2021, 12, 25),
            };

            DateTime[] workSaturdays = new DateTime[]
            {
                new DateTime(2021, 01, 24),
                new DateTime(2021, 03, 21),
                new DateTime(2021, 09, 12),
                new DateTime(2021, 12, 12),
            };

            int workDays = 0;
            Console.WriteLine("Enter end date(YYYY/MM/DD): ");
            DateTime endDate = System.Convert.ToDateTime(Console.ReadLine());
            DateTime now = DateTime.Now;

            do{
                now = now.AddDays(1);

                if((now.DayOfWeek >= DayOfWeek.Monday) && (now.DayOfWeek <= DayOfWeek.Friday))
                {
                    workDays++;
                    foreach(var i in holidays)
                    {
                        if(i.Date == now.Date)
                        {
                            workDays--;
                        }
                    }

                    foreach(var i in workSaturdays)
                    {
                        if(i.Date == now.Date)
                        {
                            workDays++;
                        }
                    }
                }
            } while (now.Date != endDate.Date);

            Console.WriteLine("{0} work days.",workDays);
        }
    }
}
