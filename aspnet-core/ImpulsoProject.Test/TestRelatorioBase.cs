using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ImpulsoProject.Test
{
    public class TestRelatorioBase
    {
        public string TestName { get; set; }
        public string Description { get; set; }
        public DateTime ExecutionDate { get; set; }
        public bool IsValidate { get; set; }

        public static async Task GenerateTestReport(List<TestRelatorioBase> testRelatorioBase, string testName)
        {
           var dataHoje = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
           await GenerateExcel(ConvertToDataTable(testRelatorioBase), Environment.CurrentDirectory + $"\\TestReport-{testName}-{dataHoje}.xlsx");
        }

        static DataTable ConvertToDataTable<T>(List<T> models)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in models)
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


        public static async Task GenerateExcel(DataTable dataTable, string path)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = excelWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            foreach (DataTable table in dataSet.Tables)
            {
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                var dataHoje = DateTime.Now.ToString("dd-MM-yyyy-HH-mm");
                table.TableName = dataHoje;
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            excelWorkBook.SaveAs(path);
            excelWorkBook.Close();
            excelApp.Quit();
        }
    }
}
