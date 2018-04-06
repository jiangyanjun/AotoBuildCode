using System;
using System.Text;
using Millennials.Creator.BaseClass;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Model;
using Common;
using System.Collections.Generic;
using System.Linq;
namespace Millennials.Creator
{
    /// <summary>
    /// Class responsible to create classes
    /// </summary>
    public class ClassCreator
    {
        #region 私有属性

        public Hashtable conversionBDCSTable;
        private DataGridView gvProjects;

        // tags
        private const string PROPERTIES_OPEN_TAG = "[PROPERTIES]";
        private const string PROPERTIES_CLOSE_TAG = "[/PROPERTIES]";
        private const string ATTRIBUTES_OPEN_TAG = "[ATTRIBUTES]";
        private const string ATTRIBUTES_CLOSE_TAG = "[/ATTRIBUTES]";
        private const string TYPE_TAG = "[TYPE]";
        private const string FIELD_TAG = "[FIELD]";
        private const string CLASS_TAG = "[CLASS]";
        private const string NAMESPACE_TAG = "[NAMESPACE]";
        private const string BUSINESS_TAG = "[BUSINESS]";
        private const string USING_TAG = "[USING]";
        private const string DAO_TAG = "[DAO]";
        private const string OBJECT_TAG = "[OBJECT]";

        // methods description
        private const string INSERT_DESCRIPTION = "插入{0}对象到数据库";
        private const string DELETE_DESCRIPTION = "从数据库删除{0}对象";
        private const string EDIT_DESCRIPTION = "编辑{0}对象到数据库";
        private const string LIST_DESCRIPTION = "从数据库查询返回list< {0}>对象";

        // methods name
        private const string INSERT_NAME = "Insert{0}";
        private const string DELETE_NAME = "Delete{0}";
        private const string EDIT_NAME = "Edit{0}";
        private const string LIST_NAME = "List{0}";

        // external files
        private const string BASE_DAO_FILE = "\\BaseDAO.cs";
        private const string NHIBERNATE_HELPER_FILE = "\\NHibernateHelper.cs";
        private const string DBML_FILE = "\\DataBase.dbml";

        #endregion

        #region 构造函数

        /// <summary>
        /// Class constructor
        /// </summary>
        public ClassCreator(DataGridView gvProjects)
        {
            this.gvProjects = gvProjects;

            conversionBDCSTable = new Hashtable();
            LoadConversionBDCSTable();
        }
        public ClassCreator()
        {
        }
        #endregion

        #region Common

        /// <summary>
        /// 方法负责： create Three-tier and MVC's model
        /// </summary>
        /// <param name="tvTables"></param>
        /// <param name="path"></param>
        /// <param name="item"></param>
        /// <param name="dataAccessType"></param>
        public void CreateModel(TreeView tvTables, string path,
            DataGridViewRow item, DataAccess dataAccessType)
        {
            StringBuilder attributesContent;
            StringBuilder propertiesContent;

            string classContent = String.Empty;
            string template = String.Empty;

            foreach (AdvancedTreeNode tab in tvTables.Nodes)
            {
                // dump old content
                classContent = String.Empty;
                propertiesContent = new StringBuilder();
                attributesContent = new StringBuilder();

                // table
                Table table = (Table)tab.Value;
                // if table is checked, create it
                if (tab.Checked)
                {
                    foreach (AdvancedTreeNode col in tab.Nodes)
                    {
                        // if column is checked, create it
                        if (col.Checked)
                        {
                            // column
                            Column column = (Column)col.Value;

                            if (string.IsNullOrEmpty(item.Cells["Template"].Value.ToString()))
                            {
                                // attributes
                                string attributeName = column.Name[0].ToString().ToLower() + column.Name.Substring(1);
                                attributesContent.Append(String.Format(CSBaseClass.baseAttributeTemplate,
                                    conversionBDCSTable[column.Type], attributeName));
                                // properties
                                string propertyName = column.Name[0].ToString().ToUpper() + column.Name.Substring(1);
                                propertiesContent.Append(String.Format(CSBaseClass.basePropertyTemplate,
                                    propertyName, conversionBDCSTable[column.Type], attributeName));
                            }
                            else
                            {
                                template = System.IO.File.ReadAllText(item.Cells["Template"].Value.ToString());

                                // if contains properties only
                                if (template.Contains(PROPERTIES_OPEN_TAG) && template.Contains(PROPERTIES_CLOSE_TAG))
                                {
                                    propertiesContent.Append(template.Substring(template.IndexOf(PROPERTIES_OPEN_TAG),
                                        template.Substring(template.IndexOf(PROPERTIES_OPEN_TAG)).IndexOf(PROPERTIES_CLOSE_TAG)).Replace(TYPE_TAG,
                                        conversionBDCSTable[column.Type].ToString()).Replace(FIELD_TAG,
                                        column.Name[0].ToString().ToUpper() + column.Name.Substring(1)).Replace(PROPERTIES_OPEN_TAG, ""));
                                }
                                if (template.Contains(ATTRIBUTES_OPEN_TAG) && template.Contains(ATTRIBUTES_CLOSE_TAG))
                                {
                                    attributesContent.Append(template.Substring(template.IndexOf(ATTRIBUTES_OPEN_TAG),
                                        template.Substring(template.IndexOf(ATTRIBUTES_OPEN_TAG)).IndexOf(ATTRIBUTES_CLOSE_TAG)).Replace(TYPE_TAG,
                                        conversionBDCSTable[column.Type].ToString()).Replace(FIELD_TAG,
                                        column.Name[0].ToString().ToUpper() + column.Name.Substring(1)).Replace(ATTRIBUTES_OPEN_TAG, ""));
                                }
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(item.Cells["Template"].Value.ToString()))
                    {
                        // Case access type is Nhibernate, the class must be serializable
                        if (dataAccessType == DataAccess.NHIBERNATE)
                        {
                            // Class content
                            classContent = String.Format(CSBaseClass.baseHiberClassTemplate,
                                item.Cells["Namespace"].Value,
                                tab.Text,
                                attributesContent.ToString(),
                                propertiesContent.ToString());
                        }
                        else
                        {
                            // Class content
                            classContent = String.Format(CSBaseClass.baseClassTemplate,
                                item.Cells["Namespace"].Value,
                                tab.Text,
                                attributesContent.ToString(),
                                propertiesContent.ToString());
                        }
                    }
                    else
                    {
                        // Removing sub tags and replacing by the required tags to create the values
                        if (template.Contains(PROPERTIES_OPEN_TAG))
                        {
                            template = template.Replace(template.Substring(template.IndexOf(PROPERTIES_OPEN_TAG),
                                            template.Substring(template.IndexOf(PROPERTIES_OPEN_TAG)).IndexOf(PROPERTIES_CLOSE_TAG)
                                            + (PROPERTIES_CLOSE_TAG).Length), PROPERTIES_OPEN_TAG);
                        }
                        if (template.Contains(ATTRIBUTES_OPEN_TAG))
                        {
                            template = template.Replace(template.Substring(template.IndexOf(ATTRIBUTES_OPEN_TAG),
                                            template.Substring(template.IndexOf(ATTRIBUTES_OPEN_TAG)).IndexOf(ATTRIBUTES_CLOSE_TAG)
                                            + (ATTRIBUTES_CLOSE_TAG).Length), ATTRIBUTES_OPEN_TAG);
                        }

                        template = template.Replace(PROPERTIES_OPEN_TAG, propertiesContent.ToString());
                        template = template.Replace(ATTRIBUTES_OPEN_TAG, attributesContent.ToString());
                        template = template.Replace(CLASS_TAG, tab.Text + Helper.GetProjectSuffix(ProjectType.MODEL, gvProjects));
                        template = template.Replace(NAMESPACE_TAG, item.Cells["Namespace"].Value.ToString());

                        classContent = template;
                    }
                    // Creating the class
                    using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                        + "\\" + tab.Text + item.Cells["Suffix"].Value + ".cs"))
                    {
                        sw.WriteLine(classContent);
                        sw.Close();
                    }
                }
            }
        }

        #endregion

        #region MVC

        /// <summary>
        /// 方法负责： create MVC's Controller
        /// </summary>
        /// <param name="tvTables"></param>
        /// <param name="path"></param>
        /// <param name="item"></param>
        /// <param name="dataAccessType"></param>
        public void CreateController(TreeView tvTables, string path,
            DataGridViewRow item, DataAccess dataAccessType)
        {
            string usingContent = String.Empty;
            string classContent = String.Empty;
            string methodContent = String.Empty;
            string regionContent = String.Empty;
            string returnType = String.Empty;
            string param = String.Empty;
            string internalParam = String.Empty;
            string idContent = String.Empty;
            string generalDeclare = String.Empty;
            string idDeclare = String.Empty;
            string methodParams = String.Empty;

            usingContent = String.Format(BusinessBaseClass.usingTemplate,
                Helper.GetProjectNamespace(ProjectType.MODEL, gvProjects));

            foreach (AdvancedTreeNode tab in tvTables.Nodes)
            {
                if (tab.Checked)
                {
                    returnType = String.Empty;
                    methodParams = String.Empty;
                    generalDeclare = String.Empty;
                    idDeclare = String.Empty;

                    foreach (AdvancedTreeNode col in tab.Nodes)
                    {
                        if (col.Checked)
                        {
                            // column
                            Column column = (Column)col.Value;
                            if (column.PrimaryKey)
                            {
                                idContent = conversionBDCSTable[column.Type] + " _" + column.Name + ", ";
                                idDeclare = column.Name[0].ToString().ToUpper() + column.Name.Substring(1)
                                    + " = " + "_" + column.Name + ", ";
                            }
                            methodParams += conversionBDCSTable[column.Type] + " _" + column.Name + ", ";
                            generalDeclare += column.Name[0].ToString().ToUpper() + column.Name.Substring(1)
                                    + " = " + "_" + column.Name + ", ";
                        }
                    }

                    methodParams = methodParams.Remove(methodParams.Length - 2); // remove last comma
                    generalDeclare = generalDeclare.Remove(generalDeclare.Length - 2);

                    // Insert
                        string str = idDeclare.Length>0 ? generalDeclare.Replace(idDeclare, "") : generalDeclare;
                        methodContent = String.Format(DAOBaseClass.methodTemplate,
                                     tab.Text,
                                     String.Format(INSERT_NAME, tab.Text),
                                      methodParams.Contains(idContent) ? methodParams.Replace(idContent, "") : methodParams,
                                      "return new " + tab.Text + "()." + "Insert(new " + tab.Text + "(){" + str + "});",
                                     String.Format(INSERT_DESCRIPTION, tab.Text),
                                     methodParams);

                    // Edit
                    methodContent += String.Format(DAOBaseClass.methodTemplate,
                        tab.Text, 
                        String.Format(EDIT_NAME, tab.Text),
                        methodParams,
                        "return new " + tab.Text + "()." + "Edit(new " + tab.Text + "(){" + generalDeclare + "});",
                        String.Format(EDIT_DESCRIPTION, tab.Text),
                        methodParams);

                    // List
                    if (dataAccessType == DataAccess.ADONET || dataAccessType == DataAccess.LINQ)
                    {
                        returnType = "List";
                        if (dataAccessType == DataAccess.ADONET)
                        {
                            param = methodParams;
                            internalParam = "new " + tab.Text + "(){" + generalDeclare + "}";
                        }
                        else
                        {
                            param = "";
                            internalParam = "";
                        }
                    }
                    else
                    {
                        returnType = "IList";
                        param = "";
                        internalParam = "";
                    }

                    methodContent += String.Format(DAOBaseClass.methodTemplate,
                        returnType + "<" + tab.Text + ">",
                        String.Format(LIST_NAME, tab.Text),
                        param,
                        "return new " + tab.Text + "()." + "List(" + internalParam + ");",
                        String.Format(LIST_DESCRIPTION, tab.Text),
                        methodParams);

                    // Delete
                    methodContent += String.Format(DAOBaseClass.methodTemplate,
                        "void", 
                        String.Format(DELETE_NAME, tab.Text),
                        idContent.Replace(", ", ""),
                        "new " + tab.Text + "()." + "Delete(new " + tab.Text + "(){" + idDeclare.Replace(", ", "") + "});",
                        String.Format(DELETE_DESCRIPTION, tab.Text),
                        methodParams);

                        regionContent += String.Format(ControllerBaseClass.regionTemplate, tab.Text, methodContent);
                }
            }

            classContent = String.Format(ControllerBaseClass.baseClassTemplate,
                usingContent, item.Cells["Namespace"].Value,
                "Controller" + item.Cells["Suffix"].Value,
                regionContent);

            // Creating the class
            using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                + "\\Controller" + item.Cells["Suffix"].Value + ".cs"))
            {
                sw.WriteLine(classContent);
                sw.Close();
            }
        }

        /// <summary>
        /// 方法负责： create the MVC's Model
        /// </summary>
        /// <param name="tvTables"></param>
        /// <param name="path"></param>
        /// <param name="item"></param>
        /// <param name="dataAccessType"></param>
        /// <param name="connectionString"></param>
        public void CreateMVCModel(TreeView tvTables, string path,
            DataGridViewRow item, DataAccess dataAccessType,
            string connectionString)
        {
            string classContent = String.Empty;
            string attributesContent = String.Empty;
            string propertiesContent = String.Empty;

            string usingContent = String.Empty;
            string methodsContent = String.Empty;
            string mapContent = String.Empty;
            string mapIdContent = String.Empty;
            string mapFieldsContent = String.Empty;
            string mapDetailFieldsContent = String.Empty;
            string classBase = String.Empty;

            // codification vars
            string codeContent = String.Empty;
            string fieldsContent = String.Empty;
            string valuesContent = String.Empty;
            string paramsContent = String.Empty;
            string conditionContent = String.Empty;
            string conditionParamContent = String.Empty;
            string updateContent = String.Empty;
            string tablesContent = String.Empty;
            string columnsContent = String.Empty;
            string paramLinqContent = String.Empty;

            string id = String.Empty;
            int numberOfFields = 1;
            int numberOfCheckColumns = 0;

            #region Creating the BaseDAO

            if (dataAccessType == DataAccess.ADONET)
            {
                // Creating the class
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                    + BASE_DAO_FILE))
                {
                    sw.WriteLine(String.Format(BaseDAOBaseClass.baseClassTemplate, item.Cells["Namespace"].Value));
                    sw.Close();
                }
            }
            else if (dataAccessType == DataAccess.NHIBERNATE)
            {
                // Creating the class
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                    + NHIBERNATE_HELPER_FILE))
                {
                    sw.WriteLine(String.Format(BaseHiberBaseClass.baseClassTemplate, item.Cells["Namespace"].Value,
                        Helper.GetProjectName(ProjectType.MODEL, gvProjects)));
                    sw.Close();
                }
            }
            else //DataAccess.LINQ
            {
                // Creating the class
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                    + BASE_DAO_FILE))
                {
                    sw.WriteLine(String.Format(BaseLinqBaseClass.baseClassTemplate, item.Cells["Namespace"].Value));
                    sw.Close();
                }
            }

            #endregion

            foreach (AdvancedTreeNode tab in tvTables.Nodes)
            {
                // dump old content
                classContent = String.Empty;
                propertiesContent = String.Empty;
                attributesContent = String.Empty;

                codeContent = "";
                fieldsContent = "";
                updateContent = "";
                valuesContent = "";
                paramsContent = "";
                conditionContent = "";
                conditionParamContent = "";
                numberOfFields = 1;
                id = "";

                mapContent = String.Empty;
                mapIdContent = String.Empty;
                mapFieldsContent = String.Empty;
                mapDetailFieldsContent = String.Empty;
                usingContent = String.Empty;
                columnsContent = String.Empty;
                paramLinqContent = String.Empty;

                string methodParam = tab.Text[0].ToString().ToLower() + tab.Text.Substring(1);

                #region Checked columns
                numberOfCheckColumns = 0;
                foreach (AdvancedTreeNode col in tab.Nodes)
                {
                    if (col.Checked)
                    {
                        numberOfCheckColumns++;
                    }
                }
                #endregion

                // table
                Table table = (Table)tab.Value;
                // if table is checked, create it
                if (tab.Checked)
                {
                    foreach (AdvancedTreeNode col in tab.Nodes)
                    {
                        // if column is checked, create it
                        if (col.Checked)
                        {
                               #region 私有属性 and properties

                            // column
                            Column column = (Column)col.Value;
                            mapDetailFieldsContent = "";

                            // attributes
                            string attributeName = column.Name[0].ToString().ToLower() + column.Name.Substring(1);
                            attributesContent += String.Format(CSBaseClass.baseAttributeTemplate,
                                conversionBDCSTable[column.Type],
                                attributeName);

                            // properties
                            string propertyName = column.Name[0].ToString().ToUpper() + column.Name.Substring(1);
                            propertiesContent += String.Format(CSBaseClass.basePropertyTemplate,
                                propertyName,
                                conversionBDCSTable[column.Type],
                                attributeName);

                            #endregion

                            #region Data access


                            if (!column.PrimaryKey)
                            {
                                fieldsContent += column.Name;
                                valuesContent += "@" + column.Name;
                                updateContent += column.Name + " = " + "@" + column.Name;
                                paramsContent += String.Format(DAOBaseClass.paramCmdTemplate,
                                        "@" + column.Name,
                                        methodParam + "." + column.Name[0].ToString().ToUpper() + column.Name.Substring(1));
                                // linq
                                paramLinqContent += column.Name[0].ToString().ToUpper() + column.Name.Substring(1) + " = " +
                                    methodParam + "." + column.Name[0].ToString().ToUpper() + column.Name.Substring(1);
                                if (numberOfFields < numberOfCheckColumns)
                                {
                                    fieldsContent += ", ";
                                    valuesContent += ", ";
                                    updateContent += ", ";
                                    paramLinqContent += ", ";
                                }
                            }
                            else
                            {
                                conditionContent = column.Name + " = " + "@" + column.Name + ";";
                                conditionParamContent = String.Format(DAOBaseClass.paramCmdTemplate,
                                    "@" + column.Name, methodParam + "." + column.Name[0].ToString().ToUpper() + column.Name.Substring(1));
                                id = column.Name[0].ToString().ToUpper() + column.Name.Substring(1);
                            }

                            #region Nhibernate mapping
                            if (dataAccessType == DataAccess.NHIBERNATE)
                            {
                                // mapping content
                                if (column.PrimaryKey)
                                {
                                    mapIdContent = String.Format(HbmBaseClass.basePropertyTemplate, "id",
                                        column.Name[0].ToString().ToUpper() + column.Name.Substring(1),
                                        column.Name, conversionBDCSTable[column.Type], "");
                                }
                                else
                                {
                                    if (!column.Nullable)
                                    {
                                        mapDetailFieldsContent += @"not-null=""true"" ";
                                    }
                                    if (column.CharacterMaximumLength != null)
                                    {
                                        mapDetailFieldsContent += String.Format(@"length=""{0}""", column.CharacterMaximumLength);
                                    }
                                    mapContent += String.Format(HbmBaseClass.basePropertyTemplate, "property",
                                        column.Name[0].ToString().ToUpper() + column.Name.Substring(1),
                                        column.Name, conversionBDCSTable[column.Type], mapDetailFieldsContent);
                                }
                            }
                            #endregion

                            #region dmbl linq

                            if (dataAccessType == DataAccess.LINQ)
                            {
                                if (column.PrimaryKey)
                                {
                                    columnsContent += String.Format(DBMLBaseClass.baseColumnIdTemplate,
                                        column.Name, conversionBDCSTable[column.Type], column.Type);
                                }
                                else
                                {
                                    columnsContent += String.Format(DBMLBaseClass.baseColumnTemplate,
                                        column.Name, conversionBDCSTable[column.Type], column.Type, (column.Nullable) ? "true" : "false");
                                }
                            }

                            #endregion


                            numberOfFields++;

                            #endregion
                        }
                    }

                    // Creating mapping
                    if (dataAccessType == DataAccess.NHIBERNATE)
                    {
                        // Mapping content
                        mapContent = String.Format(HbmBaseClass.baseClassTemplate,
                            item.Cells["Assembly"].Value,
                            item.Cells["Namespace"].Value,
                            tab.Text,
                            tab.Text,
                            mapIdContent,
                            mapContent);

                        // Creating the mapping
                        using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                        + "\\" + tab.Text + item.Cells["Suffix"].Value + ".hbm.xml"))
                        {
                            sw.WriteLine(mapContent);
                            sw.Close();
                        }
                    }

                    #region DAO class methods

                    if (dataAccessType == DataAccess.ADONET)
                    {
                        classBase = ": BaseDAO";
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Data");
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Data.SqlClient");
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Linq");

                        // Insert
                        // File content
                        codeContent = String.Format(DAOBaseClass.insertCmdTemplate,
                            tab.Text, fieldsContent, valuesContent, paramsContent, methodParam);
                        // Method
                        methodsContent = String.Format(DAOBaseClass.methodTemplate,
                            tab.Text, 
                            String.Format(INSERT_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                            String.Format(INSERT_DESCRIPTION, tab.Text),
                            methodParam);

                        // Edit
                        // File content
                        codeContent = String.Format(DAOBaseClass.editCmdTemplate,
                            tab.Text, updateContent, conditionContent, paramsContent + conditionParamContent, methodParam);
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(EDIT_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                           String.Format(EDIT_DESCRIPTION, tab.Text),
                            methodParam);

                        // List
                        // File content
                        codeContent = String.Format(DAOBaseClass.listCmdTemplate,
                            tab.Text, conditionContent,
                            conditionParamContent, tab.Text);
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            "List<" + tab.Text + ">",
                            String.Format(LIST_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                            String.Format(LIST_DESCRIPTION, tab.Text),
                            methodParam);

                        // Delete
                        codeContent = String.Format(DAOBaseClass.deleteCmdTemplate,
                            tab.Text, conditionContent, conditionParamContent);
                        // Method
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            "void",
                            String.Format(DELETE_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                            String.Format(DELETE_DESCRIPTION, tab.Text),
                            methodParam);
                    }

                    #endregion

                    #region Nhibernate methods

                    else if (dataAccessType == DataAccess.NHIBERNATE)
                    {
                        classBase = "";
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "NHibernate");

                        // Insert
                        // File content
                        codeContent = String.Format(DAOBaseClass.nhibernateInsertTemplate,
                            "Save", methodParam, "return session.Get<" + tab.Text + ">(" + methodParam + "." + id + ");");
                        // Method
                        methodsContent = String.Format(DAOBaseClass.methodTemplate,
                            tab.Text, 
                            String.Format(INSERT_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                            String.Format(INSERT_DESCRIPTION, tab.Text),
                            methodParam);

                        // Edit
                        // File content
                        codeContent = String.Format(DAOBaseClass.nhibernateInsertTemplate,
                            "Update", methodParam, "return session.Get<" + tab.Text + ">(" + methodParam + "." + id + ");");
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(EDIT_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                           String.Format(EDIT_DESCRIPTION, tab.Text),
                            methodParam);

                        // List
                        // File content
                        codeContent = String.Format(DAOBaseClass.nhibernateListCmdTemplate,
                            tab.Text);
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            "IList<" + tab.Text + ">", "List",
                            "",
                            codeContent,
                            String.Format(LIST_DESCRIPTION, tab.Text),
                            methodParam);


                        // Delete
                        codeContent = String.Format(DAOBaseClass.nhibernateInsertTemplate,
                            "Delete", methodParam, "");
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            "void",
                            String.Format(DELETE_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                            String.Format(DELETE_DESCRIPTION, tab.Text),
                            methodParam);

                    }

                    #endregion

                    #region LINQ
                    else
                    {
                        classBase = ": BaseDAO";
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Linq");
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Web");

                        // Insert
                        // File content
                        codeContent = String.Format(LinqBaseClass.insertCmdTemplate,
                            tab.Text, methodParam, paramLinqContent);
                        // Method
                        methodsContent = String.Format(LinqBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(INSERT_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                            String.Format(INSERT_DESCRIPTION, tab.Text),
                            methodParam);

                        // Edit
                        // File content
                        codeContent = String.Format(LinqBaseClass.editCmdTemplate,
                            methodParam, tab.Text, id, methodParam + "." + id,
                            methodParam + "Edit = " + methodParam + ";");
                        methodsContent += String.Format(LinqBaseClass.methodTemplate,
                            tab.Text, 
                            String.Format(EDIT_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                            String.Format(EDIT_DESCRIPTION, tab.Text),
                            methodParam);

                        // List
                        // File content
                        codeContent = String.Format(LinqBaseClass.listCmdTemplate,
                            methodParam, tab.Text);
                        methodsContent += String.Format(LinqBaseClass.methodTemplate,
                            "List<" + tab.Text + ">", 
                            String.Format(LIST_NAME, ""),
                            "",
                            codeContent,
                            String.Format(LIST_DESCRIPTION, tab.Text),
                            methodParam);

                        // Delete
                        codeContent = String.Format(LinqBaseClass.deleteCmdTemplate,
                            methodParam, tab.Text, id, methodParam + "." + id);
                        // Method
                        methodsContent += String.Format(LinqBaseClass.methodTemplate,
                            "void",
                            String.Format(DELETE_NAME, ""),
                            tab.Text + " " + methodParam,
                            codeContent,
                            String.Format(DELETE_DESCRIPTION, tab.Text),
                            methodParam);

                        tablesContent += String.Format(DBMLBaseClass.baseTableTemplate,
                            connectionString.Split(';')[1].Split('=')[1], tab.Text, columnsContent);
                    }
                    #endregion

                    // Class content
                    classContent = String.Format(CSMVCBaseClass.baseClassTemplate,
                        item.Cells["Namespace"].Value, tab.Text, attributesContent,
                        propertiesContent, usingContent, classBase, methodsContent);

                    // Creating the class
                    using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                        + "\\" + tab.Text + item.Cells["Suffix"].Value + ".cs"))
                    {
                        sw.WriteLine(classContent);
                        sw.Close();
                    }
                }
            }
            if (dataAccessType == DataAccess.LINQ)
            {
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                            + DBML_FILE))
                {
                    sw.WriteLine(String.Format(DBMLBaseClass.baseClassTemplate,
                        connectionString.Split(';')[1].Split('=')[1],
                        connectionString, tablesContent));
                    sw.Close();
                }
            }
        }

        #endregion

        #region Tree-tier

        /// <summary>
        /// 方法负责： create Three-tier's business
        /// </summary>
        /// <param name="tvTables"></param>
        /// <param name="path"></param>
        /// <param name="item"></param>
        /// <param name="dataAccessType"></param>
        public void CreateBusiness(TreeView tvTables, string path,
            DataGridViewRow item, DataAccess dataAccessType)
        {
            string classContent = String.Empty;
            string usingContent = String.Empty;
            string metthodsContent = String.Empty;
            string externalParam = String.Empty;
            string internalParam = String.Empty;
            string retorno = String.Empty;

            foreach (AdvancedTreeNode tab in tvTables.Nodes)
            {
                externalParam = String.Empty;
                internalParam = String.Empty;
                retorno = String.Empty;

                //table
                Table table = (Table)tab.Value;
                // if table is checked, create it
                if (tab.Checked)
                {
                    usingContent = String.Format(BusinessBaseClass.usingTemplate,
                        Helper.GetProjectNamespace(ProjectType.MODEL, gvProjects));
                    usingContent += String.Format(BusinessBaseClass.usingTemplate,
                        Helper.GetProjectNamespace(ProjectType.DAO, gvProjects));

                    string paramMethod = tab.Text[0].ToString().ToLower() + tab.Text.Substring(1);

                    // params
                    if (dataAccessType == DataAccess.ADONET)
                    {
                        externalParam = tab.Text + " " + paramMethod;
                        internalParam = paramMethod;
                    }
                    else
                    {
                        externalParam = "";
                        internalParam = "";
                    }

                    // to nhibernate, return type is different
                    if (dataAccessType == DataAccess.NHIBERNATE)
                    {
                        retorno = "IList";
                    }
                    else
                    {
                        retorno = "List";
                    }

                    if (string.IsNullOrEmpty(item.Cells["Template"].Value.ToString()))
                    {
                        // List
                        metthodsContent = String.Format(BusinessBaseClass.metodosTemplate,
                            retorno + "<" + tab.Text + ">",
                            String.Format(LIST_NAME, ""),
                            externalParam,
                            "return new " + tab.Text + Helper.GetProjectSuffix(ProjectType.DAO, gvProjects) + "().List(" + internalParam + ");",
                           String.Format(LIST_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Insert
                        metthodsContent += String.Format(BusinessBaseClass.metodosTemplate,
                            tab.Text,
                            String.Format(INSERT_NAME, ""),
                            tab.Text + " " + paramMethod,
                            "return new " + tab.Text + Helper.GetProjectSuffix(ProjectType.DAO, gvProjects) + "().Insert(" + paramMethod + ");",
                           String.Format(INSERT_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Edit
                        metthodsContent += String.Format(BusinessBaseClass.metodosTemplate,
                            tab.Text,
                            String.Format(EDIT_NAME, ""),
                            tab.Text + " " + paramMethod,
                            "return new " + tab.Text + Helper.GetProjectSuffix(ProjectType.DAO, gvProjects) + "().Edit(" + paramMethod + ");",
                            String.Format(EDIT_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Delete
                        metthodsContent += String.Format(BusinessBaseClass.metodosTemplate,
                            "void",
                            String.Format(DELETE_NAME, ""),
                            tab.Text + " " + paramMethod,
                            "new " + tab.Text + Helper.GetProjectSuffix(ProjectType.DAO, gvProjects) + "().Delete(" + paramMethod + ");",
                            String.Format(DELETE_DESCRIPTION, tab.Text),
                            paramMethod);

                        classContent = String.Format(BusinessBaseClass.baseClassTemplate,
                            usingContent,
                            item.Cells["Namespace"].Value,
                            tab.Text + item.Cells["Suffix"].Value,
                            metthodsContent,
                            tab.Text);
                    }
                    else
                    {
                        string template = System.IO.File.ReadAllText(item.Cells["Template"].Value.ToString());
                        template = template.Replace(BUSINESS_TAG, tab.Text + item.Cells["Suffix"].Value);
                        template = template.Replace(USING_TAG, usingContent);
                        template = template.Replace(DAO_TAG, tab.Text + Helper.GetProjectSuffix(ProjectType.DAO, gvProjects));
                        template = template.Replace(NAMESPACE_TAG, item.Cells["Namespace"].Value.ToString());
                        template = template.Replace(TYPE_TAG, tab.Text);
                        template = template.Replace(OBJECT_TAG, paramMethod);
                        classContent = template;
                    }
                    // Creating the class
                    using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                        + "\\" + tab.Text + item.Cells["Suffix"].Value + ".cs"))
                    {
                        sw.WriteLine(classContent);
                        sw.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 方法负责： create Three-tier's DAO
        /// </summary>
        /// <param name="tvTables"></param>
        /// <param name="path"></param>
        /// <param name="item"></param>
        /// <param name="dataAccessType"></param>
        /// <param name="connectionString"></param>
        public void CreateDAO(TreeView tvTables, string path,
            DataGridViewRow item, DataAccess dataAccessType,
            string connectionString)
        {
            string classContent = String.Empty;
            string usingContent = String.Empty;
            string methodsContent = String.Empty;
            string mapContent = String.Empty;
            string mapIdContent = String.Empty;
            string mapFieldContent = String.Empty;
            string mapFieldDetailsContent = String.Empty;
            string baseClass = String.Empty;

            string codeContent = String.Empty;
            string fieldContent = String.Empty;
            string valuesContent = String.Empty;
            string paramsContent = String.Empty;
            string conditionContent = String.Empty;
            string conditionParamContent = String.Empty;
            string updateContent = String.Empty;
            string tablesContent = String.Empty;
            string columnsContent = String.Empty;
            string paramLinqContent = String.Empty;

            string id = String.Empty;
            int numberOfFields = 1;
            int numberOfCheckedColumns = 0;

            #region Creating the data access class

            if (dataAccessType == DataAccess.ADONET)
            {
                // Creating the class
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                    + BASE_DAO_FILE))
                {
                    sw.WriteLine(String.Format(BaseDAOBaseClass.baseClassTemplate, item.Cells["Namespace"].Value));
                    sw.Close();
                }
            }
            else if (dataAccessType == DataAccess.NHIBERNATE)
            {
                // Creating the class
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                    + NHIBERNATE_HELPER_FILE))
                {
                    sw.WriteLine(String.Format(BaseHiberBaseClass.baseClassTemplate, item.Cells["Namespace"].Value,
                        Helper.GetProjectName(ProjectType.DAO, gvProjects)));
                    sw.Close();
                }
            }
            else //DataAccess.LINQ
            {
                // Creating the class
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                    + BASE_DAO_FILE))
                {
                    sw.WriteLine(String.Format(BaseLinqBaseClass.baseClassTemplate, item.Cells["Namespace"].Value));
                    sw.Close();
                }
            }

            #endregion

            foreach (AdvancedTreeNode tab in tvTables.Nodes)
            {
                // Init values
                codeContent = "";
                fieldContent = "";
                updateContent = "";
                valuesContent = "";
                paramsContent = "";
                conditionContent = "";
                conditionParamContent = "";
                numberOfFields = 1;
                id = "";

                mapContent = String.Empty;
                mapIdContent = String.Empty;
                mapFieldContent = String.Empty;
                mapFieldDetailsContent = String.Empty;
                columnsContent = String.Empty;
                paramLinqContent = String.Empty;

                // table
                Table table = (Table)tab.Value;
                // if table is checked, create it
                if (tab.Checked)
                {
                    usingContent = String.Format(DAOBaseClass.usingTemplate,
                        Helper.GetProjectNamespace(ProjectType.MODEL, gvProjects));

                    string paramMethod = tab.Text[0].ToString().ToLower() + tab.Text.Substring(1);

                    #region Checked columns
                    numberOfCheckedColumns = 0;
                    foreach (AdvancedTreeNode col in tab.Nodes)
                    {
                        if (col.Checked)
                        {
                            numberOfCheckedColumns++;
                        }
                    }
                    #endregion

                    foreach (AdvancedTreeNode col in tab.Nodes)
                    {
                        Column column = (Column)col.Value;
                        mapFieldDetailsContent = "";

                        // if column is checked, create it
                        if (col.Checked)
                        {
                            if (!column.PrimaryKey)
                            {
                                fieldContent += column.Name;
                                valuesContent += "@" + column.Name;
                                updateContent += column.Name + " = " + "@" + column.Name;
                                paramsContent += String.Format(DAOBaseClass.paramCmdTemplate,
                                        "@" + column.Name, paramMethod + "." + column.Name[0].ToString().ToUpper() + column.Name.Substring(1));
                                // linq
                                paramLinqContent += column.Name[0].ToString().ToUpper() + column.Name.Substring(1) + " = " +
                                    paramMethod + "." + column.Name[0].ToString().ToUpper() + column.Name.Substring(1);
                                if (numberOfFields < numberOfCheckedColumns)
                                {
                                    fieldContent += ", ";
                                    valuesContent += ", ";
                                    updateContent += ", ";
                                    paramLinqContent += ", ";
                                }
                            }
                            else
                            {
                                conditionContent = column.Name + " = " + "@" + column.Name + ";";
                                conditionParamContent = String.Format(DAOBaseClass.paramCmdTemplate,
                                    "@" + column.Name, paramMethod + "." + column.Name[0].ToString().ToUpper() + column.Name.Substring(1));
                                id = column.Name[0].ToString().ToUpper() + column.Name.Substring(1);

                            }

                            #region Nhibernate mapping
                            if (dataAccessType == DataAccess.NHIBERNATE)
                            {
                                // mapping content
                                if (column.PrimaryKey)
                                {
                                    mapIdContent = String.Format(HbmBaseClass.basePropertyTemplate, "id",
                                        column.Name[0].ToString().ToUpper() + column.Name.Substring(1),
                                        column.Name, conversionBDCSTable[column.Type], "");
                                }
                                else
                                {
                                    if (!column.Nullable)
                                    {
                                        mapFieldDetailsContent += @"not-null=""true"" ";
                                    }
                                    if (column.CharacterMaximumLength != null)
                                    {
                                        mapFieldDetailsContent += String.Format(@"length=""{0}""", column.CharacterMaximumLength);
                                    }
                                    mapContent += String.Format(HbmBaseClass.basePropertyTemplate, "property",
                                        column.Name[0].ToString().ToUpper() + column.Name.Substring(1),
                                        column.Name, conversionBDCSTable[column.Type], mapFieldDetailsContent);
                                }
                            }
                            #endregion

                            #region dmbl linq

                            if (dataAccessType == DataAccess.LINQ)
                            {
                                if (column.PrimaryKey)
                                {
                                    columnsContent += String.Format(DBMLBaseClass.baseColumnIdTemplate,
                                        column.Name, conversionBDCSTable[column.Type], column.Type);
                                }
                                else
                                {
                                    columnsContent += String.Format(DBMLBaseClass.baseColumnTemplate,
                                        column.Name, conversionBDCSTable[column.Type], column.Type, (column.Nullable) ? "true" : "false");
                                }
                            }

                            #endregion

                            numberOfFields++;
                        }

                    }
                    // creating mapping
                    if (dataAccessType == DataAccess.NHIBERNATE)
                    {
                        // mapping content
                        mapContent = String.Format(HbmBaseClass.baseClassTemplate,
                            item.Cells["Assembly"].Value, item.Cells["Namespace"].Value, tab.Text, tab.Text,
                            mapIdContent, mapContent);

                        // Creating the Nhibernate mapping
                        using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                        + "\\" + tab.Text + item.Cells["Suffix"].Value + ".hbm.xml"))
                        {
                            sw.WriteLine(mapContent);
                            sw.Close();
                        }
                    }

                    #region DAO class methods

                    if (dataAccessType == DataAccess.ADONET)
                    {
                        baseClass = ": BaseDAO";
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Data");
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Data.SqlClient");
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Linq");

                        // Insert
                        // file content
                        codeContent = String.Format(DAOBaseClass.insertCmdTemplate,
                            tab.Text, fieldContent, valuesContent, paramsContent, paramMethod);
                        // Method
                        methodsContent = String.Format(DAOBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(INSERT_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(INSERT_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Edit
                        // File content
                        codeContent = String.Format(DAOBaseClass.editCmdTemplate,
                            tab.Text, updateContent, conditionContent, paramsContent + conditionParamContent, paramMethod);
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(EDIT_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(EDIT_DESCRIPTION, tab.Text),
                            paramMethod);

                        // List
                        // File content
                        codeContent = String.Format(DAOBaseClass.listCmdTemplate,
                            tab.Text, conditionContent,
                            conditionParamContent, tab.Text);
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            "List<" + tab.Text + ">", "List",
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(LIST_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Delete
                        codeContent = String.Format(DAOBaseClass.deleteCmdTemplate,
                            tab.Text, conditionContent, conditionParamContent);
                        // Method
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            "void", 
                            String.Format(DELETE_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(DELETE_DESCRIPTION, tab.Text),
                            paramMethod);
                    }

                    #endregion

                    #region NHibernate Methods

                    else if (dataAccessType == DataAccess.NHIBERNATE)
                    {
                        baseClass = "";
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "NHibernate");

                        // Insert
                        // File content
                        codeContent = String.Format(DAOBaseClass.nhibernateInsertTemplate,
                            "Save", paramMethod, "return session.Get<" + tab.Text + ">(" + paramMethod + "." + id + ");");

                        methodsContent = String.Format(DAOBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(INSERT_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(INSERT_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Edit
                        // File content
                        codeContent = String.Format(DAOBaseClass.nhibernateInsertTemplate,
                            "Update", paramMethod, "return session.Get<" + tab.Text + ">(" + paramMethod + "." + id + ");");
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(EDIT_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(EDIT_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Delete
                        codeContent = String.Format(DAOBaseClass.nhibernateInsertTemplate,
                            "Delete", paramMethod, "");
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            "void",
                            String.Format(DELETE_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(DELETE_DESCRIPTION, tab.Text),
                            paramMethod);


                        // List
                        // File content
                        codeContent = String.Format(DAOBaseClass.nhibernateListCmdTemplate,
                            tab.Text);
                        methodsContent += String.Format(DAOBaseClass.methodTemplate,
                            "IList<" + tab.Text + ">",
                            String.Format(LIST_NAME, ""),
                            "",
                            codeContent,
                            String.Format(LIST_DESCRIPTION, tab.Text),
                            paramMethod);

                    }

                    #endregion

                    #region LINQ
                    else
                    {
                        baseClass = ": BaseDAO";
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Linq");
                        usingContent += String.Format(DAOBaseClass.usingTemplate, "System.Web");

                        // Insert
                        // File content
                        codeContent = String.Format(LinqBaseClass.insertCmdTemplate,
                            tab.Text, paramMethod, paramLinqContent);
                        // Method
                        methodsContent = String.Format(LinqBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(INSERT_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(INSERT_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Edit
                        // File content
                        codeContent = String.Format(LinqBaseClass.editCmdTemplate,
                            paramMethod, tab.Text, id, paramMethod + "." + id,
                            paramMethod + "Edition = " + paramMethod + ";");
                        methodsContent += String.Format(LinqBaseClass.methodTemplate,
                            tab.Text,
                            String.Format(EDIT_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(EDIT_DESCRIPTION, tab.Text),
                            paramMethod);

                        // List
                        // File content
                        codeContent = String.Format(LinqBaseClass.listCmdTemplate,
                            paramMethod, tab.Text);
                        methodsContent += String.Format(LinqBaseClass.methodTemplate,
                            "List<" + tab.Text + ">",
                            String.Format(LIST_NAME, ""),
                            "",
                            codeContent,
                            String.Format(LIST_DESCRIPTION, tab.Text),
                            paramMethod);

                        // Delete
                        codeContent = String.Format(LinqBaseClass.deleteCmdTemplate,
                            paramMethod, tab.Text, id, paramMethod + "." + id);
                        // Method
                        methodsContent += String.Format(LinqBaseClass.methodTemplate,
                            "void",
                            String.Format(DELETE_NAME, ""),
                            tab.Text + " " + paramMethod,
                            codeContent,
                            String.Format(DELETE_DESCRIPTION, tab.Text),
                            paramMethod);

                        tablesContent += String.Format(DBMLBaseClass.baseTableTemplate,
                            connectionString.Split(';')[1].Split('=')[1], tab.Text, columnsContent);
                    }
                    #endregion


                    classContent = String.Format(DAOBaseClass.baseClassTemplate,
                        usingContent, item.Cells["Namespace"].Value, tab.Text + item.Cells["Suffix"].Value,
                        methodsContent, tab.Text, baseClass);

                    // Creating the class
                    using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                        + "\\" + tab.Text + item.Cells["Suffix"].Value + ".cs"))
                    {
                        sw.WriteLine(classContent);
                        sw.Close();
                    }
                }
            }
            if (dataAccessType == DataAccess.LINQ)
            {
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value
                            + DBML_FILE))
                {
                    sw.WriteLine(String.Format(DBMLBaseClass.baseClassTemplate,
                       connectionString.Split(';')[1].Split('=')[1],
                       connectionString, tablesContent));
                    sw.Close();
                }
            }
        }

        #endregion

        #region Others

        private void LoadConversionBDCSTable()
        {
            conversionBDCSTable.Add("tinyint", "short");
            conversionBDCSTable.Add("smallint", "short");
            conversionBDCSTable.Add("int", "int");
            conversionBDCSTable.Add("bigint", "long");
            conversionBDCSTable.Add("bit", "bool");
            conversionBDCSTable.Add("decimal", "decimal");
            conversionBDCSTable.Add("numeric", "decimal");
            conversionBDCSTable.Add("smallmoney", "decimal");
            conversionBDCSTable.Add("money", "decimal");
            conversionBDCSTable.Add("real", "decimal");
            conversionBDCSTable.Add("float", "float");
            conversionBDCSTable.Add("smalldatetime", "DateTime");
            conversionBDCSTable.Add("date", "DateTime");
            conversionBDCSTable.Add("datetime", "DateTime");
            conversionBDCSTable.Add("char", "char");
            conversionBDCSTable.Add("varchar", "string");
            conversionBDCSTable.Add("text", "string");
            conversionBDCSTable.Add("nchar", "char");
            conversionBDCSTable.Add("nvarchar", "string");
            conversionBDCSTable.Add("ntext", "string");
            conversionBDCSTable.Add("uniqueidentifier", "Guid");
            conversionBDCSTable.Add("xml", "object");
            conversionBDCSTable.Add("varbinary", "bool");
        }

        #endregion
    }
}