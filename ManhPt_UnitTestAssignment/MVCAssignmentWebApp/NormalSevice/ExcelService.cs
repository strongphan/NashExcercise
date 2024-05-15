using OfficeOpenXml;

namespace MVCAssignment.WebApp.NormalSevice
{
    public class ExcelService : IExcelService
    {
        public byte[] ExportToExcel<T>(IEnumerable<T> dataCollection)
        {
            string sheetName = "People";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                worksheet.Cells["A1"].LoadFromCollection(dataCollection, PrintHeaders: true);
                return package.GetAsByteArray();
            }
        }
    }
}
