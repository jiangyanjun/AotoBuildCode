using System;

namespace Millennials.Creator.BaseClass
{
    public static class BusinessBaseClass
    {
        public const string baseClassTemplate =

       @"using System;
using System.Collections.Generic;
{0}

namespace {1}
{{
    /// <summary>
    /// Class with the {4} entity's business layer
    /// </summary>
    public class {2}
    {{
       {3}
    }}
}}";

        public const string usingTemplate = @"using {0};
";
        // 0 - return, 1 - method name, 2 - params, 
        // 3 - content, 4 - description, 5 - param
        public const string metodosTemplate = @"
         /// <summary>
        /// 方法负责： {4}
        /// </summary>
        /// <param name=""{5}""></param>
        /// <returns></returns>
        public {0} {1}({2})
        {{
            try 
			{{
                {3}
            }}
            catch (Exception ex)
            {{
                throw ex;
            }}
        }}
";
    }
}