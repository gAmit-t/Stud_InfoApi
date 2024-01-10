using System;
using System.Collections.Generic;
using System.Data;
using StudentInfo.DAL;

namespace StudentInfo.BL.Common
{
    public class Common_BL
    {
        public static DataTable GetGeneralSettings()
        {
            DataTable dtRtnData = new DataTable();
            Dictionary<string, string> ParaValues = new Dictionary<string, string>();
            try
            {
                dtRtnData = _DataAccess.GetDataTable("wsp_GetGeneralSettings_Web ", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRtnData;
        }
    }
}
