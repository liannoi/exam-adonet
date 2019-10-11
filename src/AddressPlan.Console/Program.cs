using AddressPlan.BL.BusinessObjects;
using AddressPlan.BL.BusinessServices;
using System.Collections.Generic;
using System.Linq;

namespace AddressPlan.Console
{
    internal class Program
    {
        protected static void Main(string[] args)
        {
            AddressBusinessService addressBusinessService = new AddressBusinessService();
            IEnumerable<AddressBusinessObject> streets = addressBusinessService.GetAddresses(streetId: 0, subdivisionId: 0);

            System.Console.WriteLine("1. наименование улицы, номер дома и наименование подразделения, номер дома которого содержит 1/2");
            System.Console.WriteLine("===================");
            streets.Where(s => s.House.Contains("1/2")).ToList().ForEach(a => System.Console.WriteLine($"{a.StreetName}, {a.House}, {a.SubdivisionName}"));
            System.Console.WriteLine("===================");

            System.Console.WriteLine("2. наименование улицы, номер дома,  подразделения - ЖЕД 402 и ЖЕД 411");
            System.Console.WriteLine("===================");
            streets.Where(s => s.SubdivisionName == "ЖЕД 402" || s.SubdivisionName == "ЖЕД 411").ToList().ForEach(a => System.Console.WriteLine($"{a.StreetName}, {a.House}"));
            System.Console.WriteLine("===================");

            System.Console.WriteLine("3. наименование улицы, номер дома  и количество домов подразделения - ЖЕД 405");
            System.Console.WriteLine("===================");
            IEnumerable<AddressBusinessObject> query = streets.Where(s => s.SubdivisionName == "ЖЕД 405");
            query.ToList().ForEach(a => System.Console.WriteLine($"{a.StreetName}, {a.House}"));
            System.Console.WriteLine($"\nКол-во: {query.Count()}");
            System.Console.WriteLine("===================");

            System.Console.WriteLine("4. наименование всех подразделений и количество улиц, которые они обслуживают");
            System.Console.WriteLine("===================");
            IEnumerable<SubdivisionProcessBusinessObject> query1 = from s in streets
                                                                   group s.SubdivisionName by s.SubdivisionName into g
                                                                   select new SubdivisionProcessBusinessObject
                                                                   {
                                                                       SubdivisionName = g.Key,
                                                                       CountProcess = g.Count()
                                                                   };
            query1.ToList().ForEach(a => System.Console.WriteLine($"{a.SubdivisionName}, {a.CountProcess}"));
            System.Console.WriteLine("===================");

            /*
             * 
             * Пятый и шестой запрос, через LINQ не написал.
             * 
             */
        }
    }
}
