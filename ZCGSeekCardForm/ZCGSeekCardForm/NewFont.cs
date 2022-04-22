using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZCGSeekCardForm
{
    /// <summary>
    ///字体文件的读取方法 
    /// </summary>
    public static class NewFont
    {
        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="path">字体文件路径,包含字体文件名和后缀名</param>
        /// <param name="fontStyle">字形(常规/粗体/斜体/粗斜体)</param>
        /// <param name="size">大小</param>
        public static Font FontSet(string path, float size, FontStyle fontStyle)
        {
            try
            {
                Font myFont;
                using (PrivateFontCollection pfc = new PrivateFontCollection())
                {

                    pfc.AddFontFile(path);//字体文件的路径

                    myFont = new Font(pfc.Families[0], size, fontStyle);
                    pfc.Dispose();
                }
                return myFont;
            }
            catch (System.Exception)
            {
                MessageBox.Show("字体文件不存在或异常！");
                return null;
            }
        }
      


    }

}
