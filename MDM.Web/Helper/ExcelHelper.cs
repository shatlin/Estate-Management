using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.ComponentModel;
using System.Data;
using ClosedXML.Excel;
using ClosedXML.Utils;
using ClosedXML.Attributes;

namespace MDM.Helper
{
    public class ExcelHelper
    {


        public static DataTable ListToDataTable<T>(List<T> data, bool showSrNo, string[] displayColumns, string[] ColumnsToRemove)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            int i = 0;

            foreach (PropertyDescriptor prop in properties)
            {

                if (i < displayColumns.Length)
                {
                    table.Columns.Add(displayColumns[i], Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                i++;
            }


            foreach (T item in data)
            {
                i = 0;
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[displayColumns[i]] = prop.GetValue(item) ?? DBNull.Value;
                    i++;
                }
                table.Rows.Add(row);
            }

            //object[] values = new object[properties.Count - 1];
            //foreach (T item in data)
            //{
            //    for (int j = 0; j < values.Length; j++)
            //    {
            //        values[j] = properties[j].GetValue(item);
            //    }

            //    table.Rows.Add(values);
            //}

            if (showSrNo)
            {
                DataColumn dataColumn = table.Columns.Add("#", typeof(int));
                dataColumn.SetOrdinal(0);
                int index = 1;
                foreach (DataRow item in table.Rows)
                {
                    item[0] = index;
                    index++;
                }
            }
            foreach (string ColName in ColumnsToRemove)
            {
                if (table.Columns.Contains(ColName))
                    table.Columns.Remove(ColName);
            }
            return table;
        }

        public static byte[] ExportExcel(DataTable dataTable, string heading)
        {

            byte[] result = null;

            using (var workbook = new XLWorkbook())
            {
                int startRowFrom = String.IsNullOrEmpty(heading) ? 1 : 3;
                dataTable.TableName = String.Format("{0} Data", heading);
                var workSheet = workbook.Worksheets.Add(dataTable);
                workSheet.Columns().AdjustToContents();
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    result = stream.ToArray();
                }

            }

            return result;
        }


        public static DataTable GetDataFromExcel(string path)
        {

            DataTable dt = new DataTable();
            string value = string.Empty;
            using (XLWorkbook workBook = new XLWorkbook(path))
            {

                IXLWorksheet workSheet = workBook.Worksheet(1);
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            value = cell.Value.ToString();
                            if (!string.IsNullOrEmpty(value))
                            {
                                if (value[0] == '\'')
                                {
                                    value = value.Substring(1);
                                }
                                dt.Columns.Add(value);
                            }
                            else
                            {
                                break;
                            }
                        }
                        firstRow = false;
                    }
                    else
                    {
                        int i = 0;
                        DataRow toInsert = dt.NewRow();
                        foreach (IXLCell cell in row.Cells(1, dt.Columns.Count))
                        {
                            try
                            {
                                value = cell.Value.ToString();

                                if (!string.IsNullOrEmpty(value))
                                {
                                    if (value[0] == '\'')
                                    {
                                        value = value.Substring(1);
                                    }
                                }
                                    toInsert[i] = value;
                            }
                            catch
                            {

                            }
                            i++;
                        }
                        dt.Rows.Add(toInsert);
                    }
                }

                return dt;

            }
        }

        public static byte[] ExportExcel<T>(List<T> data, bool showSlno, string[] displayColumns, string[] ColumnsToRemove, string Heading)
        {
            return ExportExcel(ListToDataTable<T>(data, showSlno, displayColumns, ColumnsToRemove), Heading);
        }

    }

}