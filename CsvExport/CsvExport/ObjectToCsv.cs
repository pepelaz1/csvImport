using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsvExport
{
    public class ObjectToCsv : IObjectToCsv
    {
        #region Named pairs
        /// <summary>
        /// Creates the named pairs.
        /// </summary>
        /// <param name="classesToConvert">The classes automatic convert.</param>
        /// <returns></returns>
        public List<Dictionary<string, string>> CreateNamedPairs(List<object> classesToConvert)
        {
            List<Dictionary<string, string>> lst = new List<Dictionary<string, string>>();
            foreach (object obj in classesToConvert)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (PropertyInfo pinfo in obj.GetType().GetProperties())
                {
                    object value = pinfo.GetValue(obj);
                    dict.Add(pinfo.Name, ValueToString(value));
                }
                lst.Add(dict);
            }
            return lst;
        }

        /// <summary>
        /// Creates the CSV.
        /// </summary>
        /// <param name="namedPairs">The named pairs.</param>
        /// <returns></returns>
        public string CreateCsv(List<Dictionary<string,string>> namedPairs)
        {
            string csv = string.Empty;
            foreach (Dictionary<string, string> dict in namedPairs)
            {
                if (csv == "")
                    csv += MakeHeader(dict) + "\r\n";
                csv += ProcessDict(dict) + "\r\n";
            }
            return csv;
        }
        #endregion
        
        #region List of objects
        /// <summary>
        /// Creates the CSV.
        /// </summary>
        /// <param name="classesToConvert">The classes automatic convert.</param>
        /// <returns>
        /// a string containing the csv text
        /// </returns>
        public string CreateCsv(List<object> classesToConvert)
        {
            string csv = string.Empty;
            foreach (object obj in classesToConvert)
            {
                if (csv == "")
                    csv += MakeHeader(obj) + "\r\n";
                csv += ProcessObject(obj) + "\r\n";
            }
            return csv;
        }
        #endregion

        /// <summary>
        /// Converts object value to string.
        /// </summary>
        /// <param name="value">The object to convert</param>
        /// <returns></returns>
        /// 
        private string ValueToString(object value)
        {
            if (value is DateTime)
                return ((DateTime)value).ToString("dd/MM/yyyy hh:mm:ss tt");
            else if (value is Double)
                return string.Format("{0:N2}", (Double)value);
            else
                return value.ToString();
        }

        /// <summary>
        /// Makes CSV header row from object.
        /// </summary>
        /// <param name="obj">The object to make header from</param>
        /// <returns></returns>
        /// 
        private string MakeHeader(object obj)
        {
            String result = "";
            foreach (PropertyInfo pinfo in obj.GetType().GetProperties())
                result += pinfo.Name + ",";

            return result.TrimEnd(','); ;
        }

        /// <summary>
        /// Makes CSV header row from dictionary of pairs.
        /// </summary>
        /// <param name="dict">The dictionary to make header from</param>
        /// <returns></returns>
        /// 
        private string MakeHeader(Dictionary<string,string> dict)
        {
            string result = string.Empty;

            foreach (KeyValuePair<string, string> pair in dict)
                result += pair.Key + ",";

            return result.TrimEnd(','); ;
        }

        /// <summary>
        /// Makes CSV row from object
        /// </summary>
        /// <param name="obj">The object to make row data from</param>
        /// <returns></returns>
        /// 
        private string ProcessObject(object obj)
        {
            String result = "";
            foreach (PropertyInfo pinfo in obj.GetType().GetProperties())
            {
                object value = pinfo.GetValue(obj);
                result += ValueToString(value) + ",";
            }
            return result.TrimEnd(','); ;
        }


        /// <summary>
        /// Makes CSV row from dictionary of pairs
        /// </summary>
        /// <param name="obj">The dictionary to make row data from</param>
        /// <returns></returns>
        /// 
        private string ProcessDict(Dictionary<string, string> dict)
        {
            string result = string.Empty;

            foreach (KeyValuePair<string, string> pair in dict)
                result += pair.Value + ",";

            return result.TrimEnd(','); ;
        }

    }
}
