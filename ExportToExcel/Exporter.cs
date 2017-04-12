using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldPopulation.BusinessEntity;
using WorldPopulation.BusinessObject;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportToExcel
{
    public class Exporter : IExporter
    {
        public bool Export(List<Country> countries)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int row = 1;

            xlWorkSheet.Cells[row, 1] = "Country";
            xlWorkSheet.Cells[row, 2] = "Female Mortality 5 Years";
            xlWorkSheet.Cells[row, 3] = "Male Mortality 5 Years";
            xlWorkSheet.Cells[row, 4] = "Female Population at 1990";
            xlWorkSheet.Cells[row, 5] = "Male Population at 1990";
            xlWorkSheet.Cells[row, 6] = "Female Life Expectancy at 1990";
            xlWorkSheet.Cells[row, 7] = "Male Life Expectancy at 1990";
            xlWorkSheet.Cells[row, 8] = "Female Population at 2017";
            xlWorkSheet.Cells[row, 9] = "Male Population at 2017";
            xlWorkSheet.Cells[row, 10] = "Female Life Expectancy at 2017";
            xlWorkSheet.Cells[row, 11] = "Male Life Expectancy at 2017";

            row++;

            foreach (Country country in countries.Where(c => c.PopulationIn1910 != null && c.PopulationToday != null).ToList())
            {
                xlWorkSheet.Cells[row, 1] = country.Name;
                xlWorkSheet.Cells[row, 2] = country.MortalityDistributionUntil5Years.Where(c => c.Key == Sex.Female).Single().Value;
                xlWorkSheet.Cells[row, 3] = country.MortalityDistributionUntil5Years.Where(c => c.Key == Sex.Male).Single().Value;
                xlWorkSheet.Cells[row, 4] = country.PopulationIn1910.Female.Count;
                xlWorkSheet.Cells[row, 5] = country.PopulationIn1910.Male.Count;
                xlWorkSheet.Cells[row, 6] = country.PopulationIn1910.Female.LifeExpectancy;
                xlWorkSheet.Cells[row, 7] = country.PopulationIn1910.Male.LifeExpectancy;
                xlWorkSheet.Cells[row, 8] = country.PopulationToday.Female.Count;
                xlWorkSheet.Cells[row, 9] = country.PopulationToday.Male.Count;
                xlWorkSheet.Cells[row, 10] = country.PopulationToday.Female.LifeExpectancy;
                xlWorkSheet.Cells[row, 11] = country.PopulationToday.Male.LifeExpectancy;
                row ++;
            }

            SaveFile("C:\\", "Test", xlApp, xlWorkBook, misValue);

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            return true;
        }
        private void SaveFile(string path, string fileName, Excel.Application xlApp, Excel.Workbook xlWorkBook, object misValue)
        {
            string file_name = String.Format("{0}{1}.xls", path, fileName

                                );

            xlWorkBook.SaveAs(file_name, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //   MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
