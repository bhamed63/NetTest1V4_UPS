using NetTest1V4_UPS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetTest1V4_UPS.Tools
{
    public static class CSVCreator
    {
        public static void CreateCSVFile(String fileFullPath, IEnumerable<Employee> employees)
        {
            StringBuilder exportSource = createExportSource();

            exportSource.AppendLine(createTableHeader());

            addEmployeesToExportSource(employees, exportSource);

            saveContent(fileFullPath, exportSource);
        }

        #region helper methods

        private static StringBuilder createExportSource()
        {
            return new StringBuilder();
        }

        private static void addEmployeesToExportSource(IEnumerable<Employee> employees, StringBuilder csv)
        {
            foreach (var employee in employees)
                csv.AppendLine(createRow(employee));
        }

        private static void saveContent(string fileFullPath, StringBuilder csv)
        {
            File.WriteAllText(fileFullPath, csv.ToString());
        }

        private static string createRow(Employee employee)
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", employee.Id, employee.Name, employee.Gender, employee.Email, employee.Status);
        }

        private static string createTableHeader()
        {
            return string.Format("Id, Name, Gender, Email, Status");
        } 

        #endregion
    }
}
