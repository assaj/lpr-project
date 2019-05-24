using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ComponentModel;

namespace _1h
{
    public class HelperDominio
    {
        public static DataTable ConvertTo<T>(IList<T> list)
        {
            var table = CreateTable<T>();
            var entityType = typeof(T);
            var properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                var row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
            if (rows != null)
            {
                list = rows.Select(row => CreateItem<T>(row)).ToList();
            }
            return list;
        }

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }
            var rows = table.Rows.Cast<DataRow>().ToList();
            return ConvertTo<T>(rows);
        }
        
        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            var cont = 0;
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();
                
                var properties = obj.GetType().GetProperties().ToList();
                foreach (DataColumn column in row.Table.Columns)
                {
                    var prop = properties.Find(x => x.Name.ToLower() == column.ColumnName.ToLower());

                    try 
                    {
                        var value = row[column.ColumnName];
                        
                        if (prop.PropertyType == typeof(byte[]))
                            prop.SetValue(obj, StringToByteArray(value.ToString()), null);
                        else if (prop.PropertyType == typeof(string) && value is DateTime)
                            prop.SetValue(obj, ((DateTime)value).ToString("dd/MM/yyyy"), null);
                        else if (prop.PropertyType == typeof(string))
                        {
                            if (value != null)
                                prop.SetValue(obj, value.ToString().Replace("#", "'"), null);
                        }
                        else if (prop.PropertyType == typeof(bool))
                        {
                            if (value != null)
                                prop.SetValue(obj, ((Int16)value == 1 ? true : false), null);
                        }
                        else if (prop.PropertyType == typeof(double))
                        {
                            if (value != null)
                                prop.SetValue(obj, Convert.ToDouble(value), null);
                        }
                        else if (prop.PropertyType == typeof(Int64))
                        {
                            if (value != null)
                                prop.SetValue(obj, Convert.ToInt64(value), null);
                        }
                        else
                            prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        // throw;
                    }
                }
            }
            cont++;
            return obj;
        }

        public static byte[] StringToByteArray(String hex)
        {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static DataTable CreateTable<T>()
        {
            var entityType = typeof(T);
            var table = new DataTable(entityType.Name);
            var properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }
    }
}
