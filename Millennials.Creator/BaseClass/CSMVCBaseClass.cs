using System;

namespace Millennials.Creator.BaseClass
{
    public static class CSMVCBaseClass
    {
        // 0 - namespace, 1 - class, 2 - attributes,
        // 3 - properties, 4 - using, 5 - baseclass, 6 - methods
        public const string baseClassTemplate =

       @"using System;
using System.Text;
using System.Collections.Generic;
{4}
 
namespace {0}
 {{
    /// <summary>
    /// {1}'s data model and persistence
    /// </summary>
     public class {1} {5}
     {{
         #region ˽������
         {2}
         #endregion
         #region ���캯��
         /// <summary>
         /// Construtor
         /// </summary>
         public {1}(): base()
         {{
         }}
         #endregion
         #region ��������
         {3}
         #endregion
         #region ����
         {6}
         #endregion
     }}
 }}";

    }
}