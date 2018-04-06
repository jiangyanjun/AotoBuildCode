using System;
using System.IO;

namespace Business
{
    public class LogHelper
    {
        /// <summary>
        /// 写入系统日志
        /// </summary>
        /// <param name="strLog">记录到日志文件的信息</param>
        public static void WriteLog(string module, string function, string strLog)
        {
            try
            {
                    string DateTimeToTxt = DateTime.Now.ToString("yyyy-MM") + ".txt";
                    string strPath = string.Empty;

                    strPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"log";

                    if (!Directory.Exists(strPath))
                    {
                        Directory.CreateDirectory(strPath);
                    }
                    strPath = strPath + "\\" + DateTimeToTxt;
                    FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter thisStreamWriter = new StreamWriter(fs);
                    thisStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    // thisStreamWriter.WriteLine("");
                    thisStreamWriter.WriteLine(string.Format("Module Name: {0}, Function Name: {1}, Issue Time: {2},    Message:    {3}", module.Trim(), function.Trim(), DateTime.Now.ToString("yy-MM-dd HH:mm:ss:ffff"), strLog));
                    // thisStreamWriter.WriteLine(string.Format("Message: {0}", strLog));
                    //thisStreamWriter.WriteLine(string.Format("Module Name: {0}, Function Name: {1}", module, function));
                    //thisStreamWriter.WriteLine(string.Format("Issue Time: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")));
                    //thisStreamWriter.WriteLine(string.Format("Message: {0}", strLog));
                    thisStreamWriter.WriteLine("");
                    thisStreamWriter.Flush();
                    thisStreamWriter.Close();
                    fs.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}
