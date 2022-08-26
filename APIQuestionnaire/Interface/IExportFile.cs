using APIQuestionnaire.Model;
using System.Data;

namespace APIQuestionnaire.Interface
{
    public interface IExportFile
    {
        Task<DataTable> ToDataTable<DataQuestion>(List<DataQuestion> items);
        Task<string> TransFromTableToCSV(DataTable datatable);
    }
}
