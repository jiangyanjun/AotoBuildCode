using System;

namespace Millennials.Creator.BaseClass
{
    public static class DAOBaseClass
    {
        public const string baseClassTemplate =

        @"using System;
using System.Collections.Generic;
{0}

namespace {1}
{{
    /// <summary>
    /// {4}'s data access class
    /// </summary>
    public class {2} {5}
    {{
        /// <summary>
        /// Constructor
        /// </summary>
        public {2}(): base()
        {{
        }}

        {3}
    }}
}}";

        public const string usingTemplate = @"using {0};
";

        public const string paramCmdTemplate = @"cmd.Parameters.AddWithValue(""{0}"", {1});
                ";

        // 0 - return, 1 - method name, 2 - params, 
        // 3 - content, 4 - description, 5 - param
        public const string methodTemplate = @"
         /// <summary>
        /// 方法负责： {4}
        /// </summary>
        /// <param name=""{5}""></param>
        /// <returns></returns>
        public {0} {1}({2})
        {{
            {3}
        }}
";
        // 0 - table, 1 - condition, 2 - params
        public const string deleteCmdTemplate = @"
            conn = new SqlConnection(connectionString);
	        try
	        {{
	            conn.Open();
	            cmd = new SqlCommand(""delete from {0} where {1}"", conn);
				{2}
				
				cmd.ExecuteNonQuery();
	        }}
	        finally
	        {{
	            conn.Close();
	        }}
";
        // 0-table, 1-fields, 2-values, 3-params, 4-return var
        public const string insertCmdTemplate = @"conn = new SqlConnection(connectionString);
            SqlDataReader dr = null;
	        try 
			{{
				conn.Open();
				cmd = new SqlCommand(""insert into {0}({1}) values({2})"", conn);
	            {3}
				dr = cmd.ExecuteReader();
                var t = new CastDbType<{0}>();
                if (dr.HasRows)
                {{
                    {4} = t.Fill(dr)[0];
                }}
	        }}
	        finally 
			{{
                if (dr != null && !dr.IsClosed)
                {{
                    dr.Close();
                }}
	            conn.Close();
	        }}
			
			return {4};
";

        // 0-table, 1-fields, 2-condition, 3-params, 4- return var
        public const string editCmdTemplate = @"conn = new SqlConnection(connectionString);
            SqlDataReader dr = null;
	        try 
			{{
				conn.Open();
				cmd = new SqlCommand(""update {0} set {1} where {2}"", conn);
	            {3}
				dr = cmd.ExecuteReader();
                var t = new CastDbType<{0}>();
                if (dr.HasRows)
                {{
                    {4} = t.Fill(dr)[0];
                }}
	        }}
	        finally 
			{{
                if (dr != null && !dr.IsClosed)
                {{
                    dr.Close();
                }}
	            conn.Close();
	        }}
			
			return {4};
";


        // 0-table, 1-condition, 2-params, 3-type
        public const string listCmdTemplate = @"conn = new SqlConnection(connectionString);
            SqlDataReader dr = null;
            List<{3}> lstReturn = new List<{3}>();

	        try 
			{{
				conn.Open();
				cmd = new SqlCommand(""select * from {0} where {1}"", conn);
	            {2}
				dr = cmd.ExecuteReader();
                var t = new CastDbType<{0}>();
                if (dr.HasRows)
                {{
                    lstReturn = t.Fill(dr).ToList<{0}>();
                }}
	        }}
	        finally 
			{{
                if (dr != null && !dr.IsClosed)
                {{
                    dr.Close();
                }}
	            conn.Close();
	        }}
			
			return lstReturn;
";
        public const string nhibernateInsertTemplate = @"
            ISession session = NHibernateHelper.GetSession();
	        session.{0}({1});
	        session.Flush();
	        session.Close();
            {2}
";
        public const string nhibernateListCmdTemplate = @"
            ISession session = NHibernateHelper.GetSession();
            return session.CreateCriteria(typeof({0})).List<{0}>();
";

    }
}