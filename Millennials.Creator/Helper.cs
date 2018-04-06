using System;
using System.Windows.Forms;
using System.Collections;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Millennials.Creator
{
    /// <summary>
    /// Contains common methods for solution's creation process
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Gets the project's GUID
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="gvProjects"></param>
        /// <param name="nameIdTable"></param>
        /// <returns></returns>
        public static string GetProjectGUID(ProjectType projectType, 
            DataGridView gvProjects, Hashtable nameIdTable)
        {
            foreach (DataGridViewRow item in gvProjects.Rows)
            {
                if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)projectType)
                {
                    return nameIdTable[item.Cells["Name"].Value].ToString();
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// Gets the project's path
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="gvProjects"></param>
        /// <returns></returns>
        public static string GetProjectPath(ProjectType projectType, DataGridView gvProjects)
        {
            foreach (DataGridViewRow item in gvProjects.Rows)
            {
                if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)projectType)
                {
                    return item.Cells["Name"].Value + "\\" + item.Cells["Name"].Value + ".csproj";
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// Gets the project's name
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="gvProjects"></param>
        /// <returns></returns>
        public static string GetProjectName(ProjectType projectType, DataGridView gvProjects)
        {
            foreach (DataGridViewRow item in gvProjects.Rows)
            {
                if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)projectType)
                {
                    return item.Cells["Name"].Value.ToString();
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// Gets the project's namespace
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="gvProjects"></param>
        /// <returns></returns>
        public static string GetProjectNamespace(ProjectType projectType, DataGridView gvProjects)
        {
            foreach (DataGridViewRow item in gvProjects.Rows)
            {
                if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)projectType)
                {
                    return item.Cells["Namespace"].Value.ToString();
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// Gets the project's suffix
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="gvProjects"></param>
        /// <returns></returns>
        public static string GetProjectSuffix(ProjectType projectType, DataGridView gvProjects)
        {
            foreach (DataGridViewRow item in gvProjects.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["Suffix"].Value.ToString()))
                {
                    if (Convert.ToInt32(item.Cells["ProjectType"].Value) == (int)projectType)
                    {
                        return item.Cells["Suffix"].Value.ToString();
                    }
                }
            }
            return String.Empty;
        }
    }
}
