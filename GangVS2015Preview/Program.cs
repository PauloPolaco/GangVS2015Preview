using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangVS2015Preview
{
    public sealed class Program
    {
        /// <summary>
        /// System.Math now brings in static
        /// classes with static methods.
        /// </summary>
        private double m_distance => Math.Sqrt(64);
        
        /// <summary>
        /// You no longer need to do use curly 
        /// braces when initializing dictionaries.
        /// { 200, "Okay" }
        /// { 403, "Forbidden" }
        /// </summary>
        private IDictionary m_standardResponseCodes = new Dictionary<int, string>()
        {
            [200] = "Okay",
            [403] = "Forbidden",
            [404] = "Page not found",
            [500] = "Internal server error"
        };

        static void Main(string[] args)
        {
            FormattedStringEscapeBreakpoint();
            IEnumerable<Automobile> cars = AutoPropInitializers();
            ExceptionFilters(cars);
            NullChecks(cars);

            Console.WriteLine("Press the ANY key to continue ...");
            Console.ReadKey();
        }

        private static int FormattedStringEscapeBreakpoint()
        {
            int sum = 0;
            
            for (int iterator = 0; iterator < 10; iterator++)
            {
                Console.WriteLine("iter = {0} | sum = {1}", iterator, sum);
                Console.WriteLine("iter = \{iterator} | sum = \{sum}");

                sum++;
            }

            return sum;
        }

        private static IEnumerable<Automobile> AutoPropInitializers()
        {
            IList<Automobile> cars = new List<Automobile>()
            {
                new Automobile("Ford", "Focus", new DateTime(2014, 8, 15)),
                new Automobile("CompanyName", null, DateTime.UtcNow),
                new Automobile(),
                null
            };

            return cars;
        }
        
        private static void ExceptionFilters(IEnumerable<Automobile> cars)
        {
            foreach (Automobile car in cars)
            {
                try
                {
                    Console.WriteLine("Model = {0}", car.Model);
                }
                catch (Exception ex) if (car == null)
                {
                    Console.WriteLine("Car is null!");
                }
            }
        }

        private static void NullChecks(IEnumerable<Automobile> cars)
        {
            foreach (Automobile car in cars)
            {
                // old way
                if(car != null && car.Model != null)
                {
                    Console.WriteLine("Model = " + car.Model.ToString());
                }

                // new way
                Console.WriteLine("Model = " + car?.Model?.ToString());
            }
        }
    }
}