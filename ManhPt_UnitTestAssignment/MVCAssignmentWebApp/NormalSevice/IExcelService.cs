
namespace MVCAssignment.WebApp.NormalSevice
{
    public interface IExcelService
    {
        byte[] ExportToExcel<T>(IEnumerable<T> dataCollection);
    }
}