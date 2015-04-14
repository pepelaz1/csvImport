using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvExport.AcceptanceTests.Data
{
    public class ExportMe
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Integer { get; set; }
        public double Double { get; set; }
        public bool Boolean { get; set; }
        public Uri Uri { get; set; }
    }
}
