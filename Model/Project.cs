
namespace Model
{
    public class Project
    {
           #region 私有属性

        private string name;
        private string template;
        private string suffix;
        private string assemblyName;
        private string name_space;
        private ProjectType projectType;

        #endregion

        #region 公有属性

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Template
        {
            get { return template; }
            set { template = value; }
        }
        
        public string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }
        
        public string AssemblyName
        {
            get { return assemblyName; }
            set { assemblyName = value; }
        }

        public string NameSpace
        {
            get { return name_space; }
            set { name_space = value; }
        }

        public ProjectType ProjectType
        {
            get { return projectType; }
            set { projectType = value; }
        }
        #endregion
    }
}
