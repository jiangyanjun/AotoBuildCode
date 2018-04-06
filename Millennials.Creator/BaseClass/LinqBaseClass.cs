using System;

namespace Millennials.Creator.BaseClass
{
    public static class LinqBaseClass
    {
        

        // 0 - return, 1 - method name, 2 - params, 
        // 3 - content, 4 - description, 5 - params
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
        public const string insertCmdTemplate = @"
            {0} new{1} = new {0}
            {{
                {2}
            }};

            db.InsertOnSubmit(new{1});
            db.SubmitChanges();

            return new{1};";


        public const string editCmdTemplate = @"
            var edit{0} = db.{1}.SingleOrDefault(rows => rows.{2} == {3});

            if (edit{0} != null)
            {{
                {4}

                db.SubmitChanges();
            }}

            return edit{0};";

        public const string listCmdTemplate = @"
            var {0} = from rows in db.{1} select rows;

            return {0}.ToList();";

        public const string deleteCmdTemplate = @"
            var delete{0} = from rows in db.{1} where rows.{2} == {3} select rows;

            db.{1}.DeleteAllOnSubmit(delete{0});
            db.SubmitChanges();";

    }
}