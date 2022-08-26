using APIQuestionnaire.Model;
using System.Data;
using System.Reflection;
using System.Text;

namespace APIQuestionnaire.Interface
{
    public class Exportfile : IExportFile
    {
        public async Task<DataTable> ToDataTable<DataQuestion>(List<DataQuestion> items)
        {
           
            PropertyInfo[] Props = typeof(DataQuestion).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            try
            {
                DataTable dataTable = new DataTable(typeof(DataQuestion).Name);

                foreach (PropertyInfo prop in Props)
                {
                    dataTable.Columns.Add(prop.Name);
                }

                foreach (DataQuestion item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                return dataTable;
            }
            catch
            {
                return new DataTable();
            }
        }

        public async Task<string> TransFromTableToCSV(DataTable datatable)
        {            
            try
            {
                StringBuilder sb = new StringBuilder();
                IEnumerable<string> columnNames = datatable.Columns.Cast<DataColumn>().Select(x => x.ColumnName);
                sb.AppendLine(String.Join(',', columnNames));

                foreach (DataRow row in datatable.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(x => String.Concat("\"", x.ToString().Replace("\"", "\"\""), "\""));
                    sb.AppendLine(String.Join(',', fields));
                }

                return sb.ToString();
            }
            catch
            {
                return new StringBuilder().ToString();
            }
        }
    }
}
