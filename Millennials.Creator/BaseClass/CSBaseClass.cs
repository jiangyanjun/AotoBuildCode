using System;

namespace Millennials.Creator.BaseClass
{
    public static class CSBaseClass
    {
        public const string baseClassTemplate =

       @"using System;
using System.Text;
using System.Collections.Generic;
 
namespace {0}
 {{
    /// <summary>
    /// Data model for {1} table
    /// </summary>
     public class {1}
     {{
         #region ˽������
         {2}
         #endregion
         #region ���캯��
         /// <summary>
         /// Constructor.
         /// </summary>
         public {1}(){{}}
         #endregion
         #region ��������
         {3}
         #endregion
     }}
 }}";

        public const string baseHiberClassTemplate =

       @"using System;
using System.Text;
using System.Collections.Generic;
 
namespace {0}
 {{
    /// <summary>
    /// {1}'s data model
    /// </summary>
     [Serializable]
     public class {1}
     {{
            #region ˽������
         {2}
         #endregion

         #region ���캯��
         /// <summary>
         /// Constructor.
         /// </summary>
         public {1}(){{}}
         #endregion

         #region ��������
         {3}
         #endregion
     }}
 }}";

        public const string baseAttributeTemplate = @"private {0} {1};
         ";

        public const string basePropertyTemplate =
        @"
        public {1} {0}
        {{
            get {{ return {2}; }}
            set {{ {2} = value; }}
        }}
";
    }
}