using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvExport
{
    public interface IObjectToCsv
    {
        /// <summary>
        /// Creates the CSV.
        /// </summary>
        /// <param name="classesToConvert">The classes automatic convert.</param>
        /// <returns>
        /// a string containing the csv text
        /// </returns>
        string CreateCsv(List<object> classesToConvert);

        /// <summary>
        /// Creates the named pairs.
        /// </summary>
        /// <param name="classesToConvert">The classes automatic convert.</param>
        /// <returns></returns>
        List<Dictionary<string, string>> CreateNamedPairs(List<object> classesToConvert);

        /// <summary>
        /// Creates the CSV.
        /// </summary>
        /// <param name="namedPairs">The named pairs.</param>
        /// <returns></returns>
        string CreateCsv(List<Dictionary<string, string>> namedPairs);
    }
}
