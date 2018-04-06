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
    /// Class responsible to create a .net project
    /// </summary>
    public class ProjectCreator
    {
           #region 私有属性

        private ClassCreator classCreator;
        private Hashtable nameIdTable;
        private DataGridView gvProjects;

        private const string NHIBERNATE_REFERENCE = "NHibernate, Version=1.2.0.4000, Culture=neutral, PublicKeyToken=aa95f207798dfdb4, processorArchitecture=MSIL";
        private const string SYSTEM_CONFIGURATION = "System.configuration";
        private const string NHIBERNATE_HELPER_CLASS = "NHibernateHelper.cs";
        private const string BASE_DAO_CLASS = "BaseDAO.cs";
        private const string DBML_FILE = "DataBase.dbml";

        #endregion

        #region 构造函数

        /// <summary>
        /// Class constructor
        /// </summary>
        public ProjectCreator()
        {
            
        }

        #endregion

         #region 方法

        /// <summary>
        /// 方法负责： create each solution project
        /// </summary>
        /// <param name="tvTables">tree view with the data base's tables</param>
        /// <param name="architectureType">architecture type</param>
        /// <param name="dataAccessType">data access type</param>
        /// <param name="path">the application path</param>
        /// <param name="item">current project</param>
        /// <param name="connectionString">the connection string</param>
        /// <param name="nameIdTable">table with the projects (name => id)</param>
        /// <param name="gvProjects">grid with the solutions data</param>
        public void CreateProjects(TreeView tvTables, Architecture architectureType,
            DataAccess dataAccessType, string path, DataGridViewRow item,
            string connectionString, Hashtable nameIdTable, DataGridView gvProjects)
        {
            // load attributes from solutionCreator
            this.nameIdTable = nameIdTable;
            this.gvProjects = gvProjects;
            classCreator = new ClassCreator(gvProjects);

            // .csproj file content
            StringBuilder files = new StringBuilder();
            StringBuilder mapContent = new StringBuilder();
            
            string dllReference = String.Empty;
            string projReference = String.Empty;
            string csprojContent = String.Empty;

            bool baseDAOAdded = false;
            bool controllerAdded = false;

            #region files references

            // Creating the file references
            foreach (AdvancedTreeNode node in tvTables.Nodes)
            {
                if (node.Checked)
                {
                    if (architectureType == Architecture.MVC)
                    {
                        if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.MODEL)
                        {
                            files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, node.Text + item.Cells["Suffix"].Value + ".cs"));

                            // Data access
                            if (dataAccessType == DataAccess.ADONET)
                            {
                                // Verifies if baseDAO is already added in the project
                                if (!baseDAOAdded)
                                {
                                    files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, BASE_DAO_CLASS));
                                    baseDAOAdded = true;
                                }
                            }
                            else if (dataAccessType == DataAccess.NHIBERNATE)
                            {
                                // Verifies if baseDAO is already added in the project
                                if (!baseDAOAdded)
                                {
                                    files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, NHIBERNATE_HELPER_CLASS));
                                    baseDAOAdded = true;
                                }
                                // Nhibernate mapping
                                mapContent.Append(String.Format(CSProjBaseClass.embeddedResourceTemplate, node.Text + item.Cells["Suffix"].Value + ".hbm.xml"));
                            }
                            else //DataAccess.LINQ
                            {
                                // Verifies if baseDAO is already added in the project
                                if (!baseDAOAdded)
                                {
                                   files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, DBML_FILE));
                                   files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, BASE_DAO_CLASS));
                                    baseDAOAdded = true;
                                }
                            }

                        }
                        else if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.CONTROLLER)
                        {
                            // Verifies if controller is already added in the project
                            if (!controllerAdded)
                            {
                                files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, "Controller" + item.Cells["Suffix"].Value + ".cs"));
                                controllerAdded = true;
                            }
                        }
                    }
                    else //Architecture.THREETIER
                    {
                        files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, node.Text + item.Cells["Suffix"].Value + ".cs"));

                        if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.DAO)
                        {
                            if (dataAccessType == DataAccess.ADONET)
                            {
                                // Verifies if baseDAO is already added in the project
                                if (!baseDAOAdded)
                                {
                                    files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, BASE_DAO_CLASS));
                                    baseDAOAdded = true;
                                }
                            }
                            else if (dataAccessType == DataAccess.NHIBERNATE)
                            {
                                // Verifies if baseDAO is already added in the project
                                if (!baseDAOAdded)
                                {
                                    files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, NHIBERNATE_HELPER_CLASS));
                                    baseDAOAdded = true;
                                }
                                // Nhibernate mapping
                                mapContent.Append(String.Format(CSProjBaseClass.embeddedResourceTemplate, node.Text + item.Cells["Suffix"].Value + ".hbm.xml"));
                            }
                            else //DataAccess.LINQ
                            {
                                // Verifies if baseDAO is already added in the project
                              //  if (!baseDAOAdded && dataAccessType == DataAccess.LINQ)
                                    if (!baseDAOAdded)
                                {
                                    files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, DBML_FILE));
                                    files.Append(String.Format(CSProjBaseClass.baseFilesTemplate, BASE_DAO_CLASS));
                                    baseDAOAdded = true;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            // If architecture type is MVC
            if (architectureType == Architecture.MVC)
            {
                if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.MODEL)
                {
                    classCreator.CreateMVCModel(tvTables, path, item, dataAccessType, connectionString);
                    projReference = ""; // Model does not have project references

                    if (dataAccessType == DataAccess.ADONET)
                    {
                        dllReference = String.Format(CSProjBaseClass.baseReferenceTemplate, SYSTEM_CONFIGURATION);
                    }
                    else if (dataAccessType == DataAccess.NHIBERNATE)
                    {
                        dllReference = String.Format(CSProjBaseClass.baseReferenceTemplate, NHIBERNATE_REFERENCE);
                    }
                }
                else if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.CONTROLLER)
                {
                    classCreator.CreateController(tvTables, path, item, dataAccessType);

                    // Model
                    projReference = String.Format(CSProjBaseClass.baseProjectReferenceTemplate,
                        Helper.GetProjectPath(ProjectType.MODEL, gvProjects),
                        Helper.GetProjectGUID(ProjectType.MODEL, gvProjects, nameIdTable),
                        Helper.GetProjectName(ProjectType.MODEL, gvProjects));
                }
                else // ProjectType.View
                {
                    // Controller
                    projReference = String.Format(CSProjBaseClass.baseProjectReferenceTemplate,
                        Helper.GetProjectPath(ProjectType.CONTROLLER, gvProjects),
                        Helper.GetProjectGUID(ProjectType.CONTROLLER, gvProjects, nameIdTable),
                        Helper.GetProjectName(ProjectType.CONTROLLER, gvProjects));
                }
            }
            else //ArchitectureType.THREETIER
            {
                if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.MODEL)
                {
                    classCreator.CreateModel(tvTables, path, item, dataAccessType);
                    projReference = ""; // Model does not have project references
                }
                else if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.BUSINESS)
                {
                    classCreator.CreateBusiness(tvTables, path, item, dataAccessType);

                    // Model
                    projReference = String.Format(CSProjBaseClass.baseProjectReferenceTemplate,
                        Helper.GetProjectPath(ProjectType.MODEL, gvProjects),
                        Helper.GetProjectGUID(ProjectType.MODEL, gvProjects, nameIdTable),
                        Helper.GetProjectName(ProjectType.MODEL, gvProjects));

                    // DAO
                    projReference += String.Format(CSProjBaseClass.baseProjectReferenceTemplate,
                        Helper.GetProjectPath(ProjectType.DAO, gvProjects),
                        Helper.GetProjectGUID(ProjectType.DAO, gvProjects, nameIdTable),
                        Helper.GetProjectName(ProjectType.DAO, gvProjects));
                }
                else // ProjectType.DAO
                {
                    classCreator.CreateDAO(tvTables, path, item, dataAccessType, connectionString);

                    // Model
                    projReference = String.Format(CSProjBaseClass.baseProjectReferenceTemplate,
                        Helper.GetProjectPath(ProjectType.MODEL, gvProjects),
                        Helper.GetProjectGUID(ProjectType.MODEL, gvProjects, nameIdTable),
                        Helper.GetProjectName(ProjectType.MODEL, gvProjects));
                    if (dataAccessType == DataAccess.ADONET)
                    {
                        dllReference = String.Format(CSProjBaseClass.baseReferenceTemplate, SYSTEM_CONFIGURATION);
                    }
                    else if (dataAccessType == DataAccess.NHIBERNATE)
                    {
                        dllReference = String.Format(CSProjBaseClass.baseReferenceTemplate, NHIBERNATE_REFERENCE);
                    }
                }
            }

            // .csproj file content
            csprojContent = String.Format(CSProjBaseClass.baseClassTemplate,
                nameIdTable[item.Cells["Name"].Value].ToString(),
                item.Cells["Namespace"].Value,
                item.Cells["Assembly"].Value, files.ToString(), projReference, dllReference, mapContent.ToString());

            // Creating .csproj file
            using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value + "\\" + item.Cells["Name"].Value + ".csproj"))
            {
                sw.WriteLine(csprojContent);
                sw.Close();
            }
        }

        #endregion
    }
}
