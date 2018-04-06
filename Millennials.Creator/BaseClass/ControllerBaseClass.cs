using System;

namespace Millennials.Creator.BaseClass
{
    public static class ControllerBaseClass
    {
        // 0 - using, 1 - namespace, 2 - class name, 
        // 3 - methods
        public const string baseClassTemplate =

       @"using System;
using System.Collections.Generic;
{0}

namespace {1}
{{
    /// <summary>
    /// 应用控制器类
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

        public const string regionTemplate = @"
       #region {0} 实体方法
        {1}
       #endregion
";
    }
}