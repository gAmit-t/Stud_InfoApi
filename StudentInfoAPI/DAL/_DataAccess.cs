using Newtonsoft.Json.Linq;
using StudentInfo.Custom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.DAL
{
    public static class _DataAccess
    {

        #region "DataTable Related"
        private static DataTable GetDataTable(SqlCommand cmd, int TimeOut = -1)
        {
            if (cmd.Connection == null) cmd.Connection = new SqlConnection(StaticGeneral.GetDBConnectionString());
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        private static DataTable GetDataTable(SqlCommand cmd, string strConn, int TimeOut = -1)
        {
            if (cmd.Connection == null) cmd.Connection = new SqlConnection(strConn);
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public static DataTable GetDataTable(string qry, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            return GetDataTable(cmd);
        }

        public static DataTable GetDataTable(string qry, JObject data, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, null, null);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd);
        }

        public static DataTable GetDataTable(string qry, JObject data, List<string> ExcPara, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, null);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd);
        }

        public static DataTable GetDataTable(string qry, Dictionary<string, object> IncPara, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(null, null, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd);
        }

        public static DataTable GetDataTable(string qry, JObject data, Dictionary<string, object> IncPara, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, null, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd);
        }

        public static DataTable GetDataTable(string qry, JObject data, Dictionary<string, object> IncPara, List<string> ExcPara, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd);
        }

        public static DataTable GetDataTable(string qry, JObject data, Dictionary<string, object> IncPara, DataSet ds, List<string> ExcPara,
            bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara, ds);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd);
        }

        public static DataTable GetDataTable(string qry, JObject data, Dictionary<string, object> IncPara, List<string> ExcPara,
             string whichConn, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd, StaticGeneral.GetDBConnectionString(whichConn));
        }

        public static DataTable GetDataTable(string DBName, string qry, JObject data, Dictionary<string, object> IncPara, List<string> ExcPara,
             string whichConn, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd, StaticGeneral.GetDBConnectionString(whichConn, DBName));
        }

        public static DataTable GetDataTable(string qry, JObject data, Dictionary<string, object> IncPara, DataSet ds, List<string> ExcPara,
             string whichConn, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara, ds);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd, StaticGeneral.GetDBConnectionString(whichConn));
        }

        public static DataTable GetDataTable(string DBName, string qry, JObject data, Dictionary<string, object> IncPara, DataSet ds, List<string> ExcPara,
             string whichConn, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara, ds);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataTable(cmd, StaticGeneral.GetDBConnectionString(whichConn, DBName));
        }


        //public static DataTable GetEMailInfo(string email_temp_shor_code, JObject obj)
        //{
        //    try
        //    {
        //        string xml_info = StaticGeneral.JsonToXML(obj);

        //        Dictionary<string, object> param = new Dictionary<string, object>();
        //        param.Add("EmpTempShortCode", email_temp_shor_code);
        //        param.Add("EmpKeyColValue", xml_info);
        //        DataTable dt = _DataAccess.GetDataTable("wsp_get_email_content", param);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

        #region "DataSet Related"

        private static DataSet GetDataSet(SqlCommand cmd, int TimeOut = -1)
        {
            if (cmd.Connection == null) cmd.Connection = new SqlConnection(StaticGeneral.GetDBConnectionString());
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        private static DataSet GetDataSet(SqlCommand cmd, string strConn, int TimeOut = -1)
        {
            if (cmd.Connection == null) cmd.Connection = new SqlConnection(strConn);
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public static DataSet GetDataSet(string qry, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            return GetDataSet(cmd);
        }

        public static DataSet GetDataSet(string qry, JObject data, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, null, null);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd);
        }

        public static DataSet GetDataSet(string qry, JObject data, List<string> ExcPara, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, null);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd);
        }

        public static DataSet GetDataSet(string qry, Dictionary<string, object> IncPara, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(null, null, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd);
        }

        public static DataSet GetDataSet(string qry, JObject data, Dictionary<string, object> IncPara, List<string> ExcPara, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd);
        }

        public static DataSet GetDataSet(string qry, JObject data, Dictionary<string, object> IncPara, DataSet ds, List<string> ExcPara,
            bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara, ds);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd);
        }

        public static DataSet GetDataSet(string qry, JObject data, Dictionary<string, object> IncPara, List<string> ExcPara,
             string whichConn, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd, StaticGeneral.GetDBConnectionString(whichConn));
        }

        public static DataSet GetDataSet(string DBName, string qry, JObject data, Dictionary<string, object> IncPara, List<string> ExcPara,
             string whichConn, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd, StaticGeneral.GetDBConnectionString(whichConn, DBName));
        }

        public static DataSet GetDataSet(string qry, JObject data, Dictionary<string, object> IncPara, DataSet ds, List<string> ExcPara,
             string whichConn, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara, ds);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd, StaticGeneral.GetDBConnectionString(whichConn));
        }

        public static DataSet GetDataSet(string DBName, string qry, JObject data, Dictionary<string, object> IncPara, DataSet ds, List<string> ExcPara,
             string whichConn, bool isSP = true, int TimeOut = -1)
        {
            SqlCommand cmd = new SqlCommand(qry);
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(data, ExcPara, IncPara, ds);
            cmd.Parameters.AddRange(sp.ToArray());
            return GetDataSet(cmd, StaticGeneral.GetDBConnectionString(whichConn, DBName));
        }

        public static DataSet GetDataSetFromSP(string strSPName, Dictionary<string, string> ParaNameValues)
        {
            using (SqlConnection conn = new SqlConnection(StaticGeneral.GetDBConnectionString()))
            {
                //  SqlConnection sCon = new SqlConnection(GetDBConnectionString());
                SqlDataAdapter sda = new SqlDataAdapter(strSPName, conn);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (ParaNameValues != null)
                {
                    foreach (KeyValuePair<string, string> item in ParaNameValues)
                    {
                        SqlParameter sp;
                        if (item.Value == null)
                        {
                            sp = new SqlParameter(item.Key, DBNull.Value);
                        }
                        else
                        {
                            sp = new SqlParameter(item.Key, item.Value);
                        }
                        sda.SelectCommand.Parameters.Add(sp);
                    }
                }
                DataSet dtRtn = new DataSet();
                sda.Fill(dtRtn);
                return dtRtn;
            }
        }

        #endregion

        #region "get Parameter List"
        private static List<SqlParameter> GetParameterList(JObject data, List<string> ExcludeParams = null, Dictionary<string, object> IncludeParams = null, DataSet ds = null)
        {
            List<SqlParameter> Rtn = new List<SqlParameter>();
            if (ExcludeParams == null)
            {
                ExcludeParams = new List<string>();
            }

            if (IncludeParams != null)
            {
                foreach (var obj in IncludeParams)
                {
                    if (obj.Value == null)
                    {
                        SqlParameter dbPara1 = new SqlParameter(obj.Key.ToString().Trim(), DBNull.Value);
                        Rtn.Add(dbPara1);
                    }
                    else if (obj.Value.ToString() == "null" || obj.Value.ToString() == "undefined" || obj.Value.ToString() == "''" || obj.Value.ToString() == "" || obj.Value.ToString() == "{}")
                    {
                        SqlParameter dbPara1 = new SqlParameter(obj.Key.ToString().Trim(), DBNull.Value);
                        Rtn.Add(dbPara1);
                    }
                    else
                    {
                        SqlParameter dbPara1 = new SqlParameter(obj.Key.ToString().Trim(), obj.Value.ToString());
                        Rtn.Add(dbPara1);
                    }
                }
            }

            if (data != null)
            {
                foreach (var obj in data)
                {
                    if (ExcludeParams.Where(x => x.ToLower() == obj.Key.ToLower()).Count() > 0)
                    {
                        continue;
                    }

                    if (obj.Value == null)
                    {
                        SqlParameter dbPara1 = new SqlParameter(obj.Key.ToString().Trim(), DBNull.Value);
                        Rtn.Add(dbPara1);
                    }
                    else if (obj.Value.ToString() == "null" || obj.Value.ToString() == "undefined" || obj.Value.ToString() == "''" || obj.Value.ToString() == "" || obj.Value.ToString() == "{}")
                    {
                        SqlParameter dbPara1 = new SqlParameter(obj.Key.ToString().Trim(), DBNull.Value);
                        Rtn.Add(dbPara1);
                    }
                    else
                    {
                        SqlParameter dbPara1 = new SqlParameter(obj.Key.ToString().Trim(), obj.Value.ToString());
                        Rtn.Add(dbPara1);
                    }
                }
            }

            if (ds != null)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        SqlParameter dbPara1 = new SqlParameter(dt.TableName, dt);
                        Rtn.Add(dbPara1);
                    }
                }
            }
            return Rtn;
        }
        #endregion

        public static int ExecuteNonQuery(string strSQL)
        {
            SqlConnection sCon = new SqlConnection(StaticGeneral.GetDBConnectionString());
            sCon.Open();
            SqlCommand sCmd = new SqlCommand(strSQL, sCon);

            int iRtn = sCmd.ExecuteNonQuery();
            sCon.Close();
            return iRtn;
        }

        //Added by vishal 28/08/2023
        public static int ExecuteNonQuery(string query, Dictionary<string, object> IncPara, bool isSP = true, int TimeOut = -1)
        {
            SqlConnection sCon = new SqlConnection(StaticGeneral.GetDBConnectionString());
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = sCon;
            if (isSP) cmd.CommandType = CommandType.StoredProcedure;
            if (TimeOut != -1) cmd.CommandTimeout = TimeOut;
            List<SqlParameter> sp = GetParameterList(null, null, IncPara);
            cmd.Parameters.AddRange(sp.ToArray());
            sCon.Open();
            int iRtn = cmd.ExecuteNonQuery();
            sCon.Close();
            return iRtn;
        }

        public static async Task<int> ExecuteNonQueryAsync(string strSQL)
        {
            int rtn;
            using (var conn = new SqlConnection(StaticGeneral.GetDBConnectionString()))
            {
                await conn.OpenAsync();
                var cmnd = conn.CreateCommand();
                cmnd.CommandText = strSQL;
                rtn = await cmnd.ExecuteNonQueryAsync();
            }
            return rtn;
        }

        public static int ExecuteSQLCommand(SqlCommand sqlCmd)
        {
            SqlConnection sCon = new SqlConnection(StaticGeneral.GetDBConnectionString());
            sCon.Open();
            sqlCmd.Connection = sCon;
            int iRtn = sqlCmd.ExecuteNonQuery();
            sCon.Close();
            return iRtn;
        }
        public static async Task<int> ExecuteSQLCommandAsync(SqlCommand sqlCmd)
        {
            int iRtn;
            using (var conn = new SqlConnection(StaticGeneral.GetDBConnectionString()))
            {
                await conn.OpenAsync();
                sqlCmd.Connection = conn;
                iRtn = await sqlCmd.ExecuteNonQueryAsync();
            }
            return iRtn;
        }

    }
}
