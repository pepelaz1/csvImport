using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvExport.AcceptanceTests
{
    using System.Collections.Generic;
    using System.Text;
    using Data;

    [TestClass]
    public class Acceptance
    {
        [TestMethod]
        public void MapComplexObject()
        {
            List<object> exportModels = CreateExportMe();
            string expected = CompareTo();

            IObjectToCsv objectToCsv = new ObjectToCsv();
            string result = objectToCsv.CreateCsv(exportModels);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MapComplexObjectViaNamedPairs()
        {
            List<object> exportModels = CreateExportMe();
            string expected = CompareTo();

            IObjectToCsv objectToCsv = new ObjectToCsv();
            List<Dictionary<string, string>> namedPairs = objectToCsv.CreateNamedPairs(exportModels);
            string result = objectToCsv.CreateCsv(namedPairs);
            Assert.AreEqual(expected, result);
        }

        private List<object> CreateExportMe()
        {
            List<object> results = new List<object>();
            ExportMe em = new ExportMe()
                {
                    Text = "Doctor notes \"TODAY\"",
                    Date = new DateTime(2012, 10, 10),
                    Integer = 12,
                    Double = 20.00,
                    Boolean = false,
                    Uri = new Uri("http://www.google.com")
                };
            results.Add(em);

            em = new ExportMe()
            {
                Text = "Doctor notes \"TOMORROW\"",
                Date = new DateTime(2013, 12, 01),
                Integer = 10002,
                Double = 280.20,
                Boolean = false,
                Uri = new Uri("http://www.google.com")
            };
            results.Add(em);

            em = new ExportMe()
            {
                Text = "Basic text, with thi's",
                Date = new DateTime(2012, 10, 10),
                Integer = 12,
                Double = 20.00,
                Boolean = true,
                Uri = new Uri("http://www.google.com")
            };
            results.Add(em);
            
            em = new ExportMe()
            {
                Text = "More complex datetime",
                Date = new DateTime(2012, 10, 10, 12, 12, 0),
                Integer = 12,
                Double = 20.00,
                Boolean = false,
                Uri = new Uri("http://www.google.com")
            };
            results.Add(em);

            em = new ExportMe()
            {
                Text = "Trees are green",
                Date = new DateTime(1998, 08, 10, 18, 13, 28),
                Integer = 12,
                Double = 20.00,
                Boolean = false,
                Uri = new Uri("http://www.microsoft.com")
            };
            results.Add(em);
            return results;
        }

        private string CompareTo()
        {
            StringBuilder sb =  new StringBuilder();
            sb.AppendLine("Text,Date,Integer,Double,Boolean,Uri");
            sb.AppendLine("Doctor notes \"TODAY\",10/10/2012 12:00:00 AM,12,20.00,False,http://www.google.com/");
            sb.AppendLine("Doctor notes \"TOMORROW\",01/12/2013 12:00:00 AM,10002,280.20,False,http://www.google.com/");
            sb.AppendLine("Basic text, with thi's,10/10/2012 12:00:00 AM,12,20.00,True,http://www.google.com/");
            sb.AppendLine("More complex datetime,10/10/2012 12:12:00 PM,12,20.00,False,http://www.google.com/");
            sb.AppendLine("Trees are green,10/08/1998 06:13:28 PM,12,20.00,False,http://www.microsoft.com/");
            return sb.ToString();
        }

    }
}
