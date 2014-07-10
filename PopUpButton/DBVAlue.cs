using System;
using System.Data;
using System.Data.SqlClient;

namespace RCO.PopUpButtons.PopUpTools
{
    public class DBValue
    {
        #region Функции преобразования значений, полученных из БД

        /// <summary>
        /// Вернуть значение в виде числа decimal
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static decimal DBValueAsDecimal(DataRow dr, string paramName)
        {
            return Convert.ToDecimal(dr[paramName]);
        }


        /// <summary>
        /// Вернуть значение в виде числа decimal
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static decimal DBValueAsDecimal(DataRowView dr, string paramName)
        {
            return Convert.ToDecimal(dr[paramName]);
        }

        /// <summary>
        /// Вернуть значение в виде строки
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static int DBValueAsInt(DataRowView dr, string paramName)
        {
            return Convert.ToInt32(dr[paramName]);
        }


        /// <summary>
        /// Вернуть значение в виде даты
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="index">индекс столбца в выборке</param>
        /// <returns></returns>
        public static DateTime DBValueAsDateTime(DataRowView dr, int index)
        {
            if (!Convert.IsDBNull(dr[index]))
                return DateTime.Parse(dr[index].ToString());
            else
                return new DateTime();
        }
        /// <summary>
        /// Вернуть значение в виде даты
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static DateTime DBValueAsDateTime(DataRowView dr, string paramName)
        {
            if (!Convert.IsDBNull(dr[paramName]))
                return DateTime.Parse(dr[paramName].ToString());
            else
                return new DateTime();
        }

        /// <summary>
        /// Вернуть значение в виде даты
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="index">индекс столбца в выборке</param>
        /// <returns></returns>
        public static DateTime DBValueAsDateTime(DataRow dr, int index)
        {
            if (!Convert.IsDBNull(dr[index]))
                return DateTime.Parse(dr[index].ToString());
            else
                return new DateTime();
        }
        /// <summary>
        /// Вернуть значение в виде даты
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static DateTime DBValueAsDateTime(DataRow dr, string paramName)
        {
            if (!Convert.IsDBNull(dr[paramName]))
                return DateTime.Parse(dr[paramName].ToString());
            else
                return new DateTime();
        }
        /// <summary>
        /// Вернуть значение в виде строки
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static string DBValueAsString(DataRow dr, string paramName)
        {
            return (!Convert.IsDBNull(dr[paramName])) ? dr[paramName].ToString() : string.Empty;
        }

        /// <summary>
        /// Вернуть значение в виде строки
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static string DBValueAsString(DataRowView dr, string paramName)
        {
            return (!Convert.IsDBNull(dr[paramName])) ? dr[paramName].ToString() : string.Empty;
        }

        /// <summary>
        /// Вернуть значение в виде строки
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramIndex">индекс столбца в выборке</param>
        /// <returns></returns>
        public static string DBValueAsString(DataRow dr, int paramIndex)
        {
            return (!Convert.IsDBNull(dr[paramIndex])) ? dr[paramIndex].ToString() : string.Empty;
        }


        /// <summary>
        /// Вернуть значение булевского типа
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static bool DBValueAsBool(DataRowView dr, string paramName)
        {
            return (!Convert.IsDBNull(dr[paramName])) ? Convert.ToBoolean(dr[paramName]) : false;
        }
        /// <summary>
        /// Вернуть значение булевского типа
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramName">имя столбца в выборке</param>
        /// <returns></returns>
        public static bool DBValueAsBool(DataRow dr, string paramName)
        {
            return (!Convert.IsDBNull(dr[paramName])) ? Convert.ToBoolean(dr[paramName]) : false;
        }

        /// <summary>
        /// Вернуть значение булевского типа
        /// </summary>
        /// <param name="dr">ряд из выборки</param>
        /// <param name="paramIndex">индекс столбца в выборке</param>
        /// <returns></returns>
        public static bool DBValueAsBool(DataRow dr, int paramIndex)
        {
            return (!Convert.IsDBNull(dr[paramIndex])) ? Convert.ToBoolean(dr[paramIndex]) : false;
        }

        #endregion
    }

    /// <summary>
    /// класс для инициализации значений параметров запроса
    /// </summary>
    public class InitParameters
    {
        #region Функции


        public static void InitSqlParameter(SqlCommand comm, string paramName, SqlDbType type, object value)
        {
            comm.Parameters.Add(paramName, type).Value = value ?? DBNull.Value;
        }

        public static void InitSqlParameter(SqlCommand comm, string paramName, char paramValue)
        {
                comm.Parameters.Add(paramName, SqlDbType.Char ).Value = paramValue;
        }


        public static void InitSqlParameter(SqlCommand comm, string paramName, bool paramValue)
        {
            comm.Parameters.Add(paramName, SqlDbType.Int).Value = paramValue;
        }


        public static void InitSqlParameter(SqlCommand comm, string paramName, string paramValue, int size)
        {
            if (!string.IsNullOrEmpty(paramValue))
                comm.Parameters.Add(paramName, SqlDbType.VarChar, size).Value = paramValue;
            else
                comm.Parameters.Add(paramName, SqlDbType.VarChar, size).Value = DBNull.Value;
        }

        public static void InitSqlParameter(SqlCommand comm, string paramName, int paramValue)
        {
            comm.Parameters.Add(paramName, SqlDbType.Int).Value = paramValue;
        }

        public static void InitSqlParameter(SqlCommand comm, string paramName, byte paramValue)
        {
            comm.Parameters.Add(paramName, SqlDbType.Bit).Value = paramValue;
        }

        public static void InitSqlParameter(SqlCommand comm, string paramName, decimal paramValue, int size)
        {
            comm.Parameters.Add(paramName, SqlDbType.Decimal, size).Value = paramValue;
        }

        
        public static void InitCharSqlParameter(SqlCommand comm, string paramName, string paramValue, int size)
        {
            if (!string.IsNullOrEmpty(paramValue))
                comm.Parameters.Add(paramName, SqlDbType.Char, size).Value = paramValue;
            else
                comm.Parameters.Add(paramName, SqlDbType.Char, size).Value = DBNull.Value;
        }


        public static void InitSqlParameter(SqlCommand comm, string paramName, DateTime paramValue)
        {
            DateTime d;
            d = new DateTime();

            if (!paramValue.Equals(d))
                comm.Parameters.Add(paramName, SqlDbType.DateTime).Value = paramValue;
            else
                comm.Parameters.Add(paramName, SqlDbType.DateTime).Value = DBNull.Value;
        }

        #endregion
    }
}