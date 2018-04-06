
namespace Model
{
    public class Template
    {
        #region 公有属性

        public int Id { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public ProjectType Type { get; set; }
        public string TextPattern { get; set; }

        #endregion
    }
}
