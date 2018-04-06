using System;

namespace Millennials.Creator.BaseClass
{
    public static class BaseLinqBaseClass
    {
        public const string baseClassTemplate =

        @"using System;
using System.Linq;
using System.Web;

namespace {0}
{{
    /// <summary>
    /// 数据访问基类
    /// </summary>
    public class BaseDAO
    {{
       protected DataBaseDataContext db;
      
       public BaseDAO()
       {{
            db = new DataBaseDataContext();
       }}
    }}
}}";

    }
}