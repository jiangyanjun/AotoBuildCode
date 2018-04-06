using System;
using System.Windows.Forms;
using System.Configuration;
using Millennials.Creator.BaseClass;
using System.IO;
using System.Collections;
using Common;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Millennials.Creator
{
    /// <summary>
    /// Class responsible to create a .net solution
    /// </summary>
    public class SolutionCreator
    {
           #region 私有属性

        private ProjectCreator projectCreator;
        private string solutionGuid;

        private const string ASSEMBLY_INFO_FILE = "Properties\\AssemblyInfo.cs";
        private const string NHIBERNATE_DLL = "bin\\Debug\\NHibernate.dll";

        #endregion

        #region 构造函数

        /// <summary>
        /// Class constructor
        /// </summary>
        public SolutionCreator()
        {
            // Solution's GUID
            solutionGuid = "{" + Guid.NewGuid().ToString() + "}";
            projectCreator = new ProjectCreator();
        }

        #endregion

         #region 方法

        /// <summary>
        ///  方法负责 create the .net solution files
        /// </summary>
        /// <param name="solutionName">the solution name</param>
        /// <param name="path">the application path</param>
        /// <param name="tvTables">tree view with the data base's tables</param>
        /// <param name="dataAccessType">data access type</param>
        /// <param name="architectureType">architecture type</param>
        /// <param name="gridSolution">grid with the solutions data</param>
        /// <param name="connectionString">the connection string</param>
        public void CreateSolution(string solutionName,
                                 string path,
                                 TreeView tvTables,
                                 DataAccess dataAccessType,
                                 Architecture architectureType,
                                 DataGridView gridSolution,
                                 string connectionString)
        {

            string solutionContent = SolutionBaseClass.baseClassTemplate;
            string project = String.Empty;
            string globalSection = String.Empty;

            // Generate guids for each solution
            Hashtable nameIdTable = new Hashtable();
            foreach (DataGridViewRow item in gridSolution.Rows)
            {
                // Add in the hastable (projectName => Guid)
                nameIdTable.Add(item.Cells["Name"].Value, "{" + Guid.NewGuid().ToString() + "}");
            }

            // For each solution project..
            foreach (DataGridViewRow item in gridSolution.Rows)
            {
                // Create the prject's folders
                CreateProjectFolders(path, item);

                // AssemblyInfo.cs file content (Properties folder)
                string assemblyInfoContent = String.Format(AssemblyInfoBaseClass.baseClassTemplate,
                    item.Cells["Name"].Value, item.Cells["Name"].Value, Guid.NewGuid().ToString());

                // Creating the AssemblyInfo.cs file
                using (StreamWriter sw = File.CreateText(path + "\\" + item.Cells["Name"].Value + "\\" + ASSEMBLY_INFO_FILE))
                {
                    sw.WriteLine(assemblyInfoContent);
                    sw.Close();
                }

                // Nhibernate reference (dll)
                if ((Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.DAO &&
                        dataAccessType == DataAccess.NHIBERNATE && architectureType == Architecture.THREETIER) ||
                        (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)ProjectType.MODEL &&
                        dataAccessType == DataAccess.NHIBERNATE && architectureType == Architecture.MVC))
                {
                    System.IO.File.Copy(ConfigurationManager.AppSettings["NHibernateAssembly"].ToString(),
                        path + "\\" + item.Cells["Name"].Value + "\\" + NHIBERNATE_DLL);
                }

                // Projects
                projectCreator.CreateProjects(tvTables, architectureType, dataAccessType, 
                    path, item, connectionString, nameIdTable, gridSolution);

                // .sln projects configuration
                project += String.Format(SolutionBaseClass.baseProjectTemplate, solutionGuid, 
                    item.Cells["Name"].Value, item.Cells["Name"].Value + "\\" + item.Cells["Name"].Value + ".csproj", 
                    nameIdTable[item.Cells["Name"].Value].ToString());

                // .sln global section configuration
                globalSection += String.Format(SolutionBaseClass.baseGlobalSectionTemplate, 
                    nameIdTable[item.Cells["Name"].Value].ToString());
            }

            // .sln file content
            solutionContent = String.Format(solutionContent, project, globalSection);

            // Creating .sln file
            using (StreamWriter sw = File.CreateText(path + "\\" + solutionName + ".sln"))
            {
                sw.WriteLine(solutionContent);
                sw.Close();
            }
        }

       /// <summary>
        /// 方法负责： create the necessary project's folders
       /// </summary>
       /// <param name="path"></param>
       /// <param name="item"></param>
        private void CreateProjectFolders(string path, DataGridViewRow item)
        {
            // Creating a folder with the project's name
            DirectoryInfo di = new DirectoryInfo(path + "\\" + item.Cells["Name"].Value);
            di.Create();

            // Creating the sub folders for each project
            di.CreateSubdirectory("bin");
            di.CreateSubdirectory("bin\\Debug");
            di.CreateSubdirectory("obj");
            di.CreateSubdirectory("Properties");
        }

        #endregion
    }
}
