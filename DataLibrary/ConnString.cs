using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary
{
    public class ConnString
    {
        /// <summary>
        /// �õ���̳Sql�����ַ���
        /// </summary>
        public static string GetConString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
    }
}
