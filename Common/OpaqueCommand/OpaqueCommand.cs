using System;
using System.Windows.Forms;

namespace Common
{
    public class OpaqueCommand
    {
        private MyOpaqueLayer m_OpaqueLayer = null;//半透明蒙板层

        public OpaqueCommand(int alpha, bool isShowLoadingImage)
        {
            if (m_OpaqueLayer == null)
            {
                m_OpaqueLayer = new MyOpaqueLayer(alpha, isShowLoadingImage);
            }
        }
        /// <summary>
        /// 显示遮罩层
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="alpha">透明度</param>
        /// <param name="isShowLoadingImage">是否显示图标</param>
        public void ShowOpaqueLayer(Control control)
        {
            try
            {
                if (!control.Controls.Contains(this.m_OpaqueLayer))
                {
                    this.m_OpaqueLayer.Dock = DockStyle.Fill;
                    control.Controls.Add(this.m_OpaqueLayer);
                    this.m_OpaqueLayer.BringToFront();
                }
                this.m_OpaqueLayer.Enabled = true;
                this.m_OpaqueLayer.Visible = true;
            }
            catch (Exception e){ }
        }

        /// <summary>
        /// 隐藏遮罩层
        /// </summary>
        public void HideOpaqueLayer()
        {
            try
            {
                if (this.m_OpaqueLayer != null)
                {
                    this.m_OpaqueLayer.Visible = false;
                    this.m_OpaqueLayer.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("HideOpaqueLayer", "HideOpaqueLayer", ex.ToString()); ;
            }
        }

    }
}
