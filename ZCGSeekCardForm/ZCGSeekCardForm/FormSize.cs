using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.ExceptionServices;

namespace ZCGSeekCardForm
{
    public class FormSize
    {
        public static Single currentSize;
        public float X { get; set; }//当前窗体的宽度
        public float Y { get; set; }//当前窗体的高度

        /// <summary>
        /// 将控件的宽，高，左边距，顶边距和字体大小暂存到tag属性中
        /// </summary>
        /// <param name="cons">递归控件中的控件</param>
        public void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        //设置控件尺寸
        private void SetComBoxSize(string[] mytag, float newx, float newy, Control con)
        {
            float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
            con.Width = (int)a;//宽度
            a = System.Convert.ToSingle(mytag[1]) * newy;//高度
            con.Height = (int)(a);
            a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
            con.Left = (int)(a);
            a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
            con.Top = (int)(a);
        }
        //根据窗体大小调整控件大小
        public void setControls(float newx, float newy, Control cons, FontType fontType)
        {
            bool IsFirst = false;
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//获取控件的Tag属性值，并分割后存储字符串数组
                try
                {
                    //ComboBox大小是随内部字体的大小而自动变化的，如果设置尺寸时（字体被释放后）会出错：参数无效
                    if (typeof(ComboBox) != con.GetType())
                    {
                        float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                        con.Width = (int)a;//宽度
                        a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                        con.Height = (int)(a);
                        a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
                        con.Left = (int)(a);
                        a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                        con.Top = (int)(a);
                    }

                    //这是获取需要修改字体控件的控件大小数据，只获取一个值即可，因为都相同
                    if (!IsFirst && (typeof(TextBox) == con.GetType()
                        || typeof(Button) == con.GetType()
                        || typeof(ListBox) == con.GetType()
                        || typeof(ComboBox) == con.GetType()
                        || typeof(Panel) == con.GetType()
                        || typeof(MenuStrip) == con.GetType()))
                    {
                        currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                        IsFirst = true;
                    }
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con, fontType);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("异常！" + ex.Message);
                    continue;
                }

            }
            switch (fontType)
            {
                case FontType.Lishu:
                    string path = @".\Font\方正隶书简体.TTF";
                    using (Font font = NewFont.FontSet(path, currentSize, FontStyle.Regular), font2 = NewFont.FontSet(path, currentSize, FontStyle.Bold))
                    {
                        SetFont(newx, newy, font, font2, cons);
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case FontType.Heiti:
                    string path2 = @".\Font\方正黑体简体.TTF";
                    using (Font font = NewFont.FontSet(path2, currentSize, FontStyle.Regular), font2 = NewFont.FontSet(path2, currentSize, FontStyle.Bold))
                    {
                        SetFont(newx, newy, font, font2, cons);
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case FontType.Youyuan:
                    string path3 = @".\Font\方正幼圆.TTF";
                    using (Font font = NewFont.FontSet(path3, currentSize, FontStyle.Regular), font2 = NewFont.FontSet(path3, currentSize, FontStyle.Bold))
                    {
                        SetFont(newx, newy, font, font2, cons);
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case FontType.Kaiti:
                    string path4 = @".\Font\方正楷体简体.ttf";
                    using (Font font = NewFont.FontSet(path4, currentSize, FontStyle.Regular), font2 = NewFont.FontSet(path4, currentSize, FontStyle.Bold))
                    {
                        SetFont(newx, newy, font, font2, cons);
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                default:
                    using (Font font = new Font("宋体", currentSize, FontStyle.Regular), font2 = new Font("宋体", currentSize, FontStyle.Bold))
                    {
                        SetFont(newx, newy, font, font2, cons);
                        fontType = FontType.Songti;
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
            }
        }

        //设置字体
        [HandleProcessCorruptedStateExceptions]
        private void SetFont(float newx, float newy, Font font, Font font2, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                if (typeof(TextBox) == con.GetType()
                        || typeof(Button) == con.GetType()
                        || typeof(ListBox) == con.GetType()
                        || typeof(Panel) == con.GetType()
                        || typeof(MenuStrip) == con.GetType())
                {
                    try
                    {
                        con.Font = font;
                    }
                    catch (AccessViolationException ex)
                    {
                        MessageBox.Show("读取异常！");
                        MessageBox.Show("AccessViolationException错误提示：" + ex.Message);
                        return;
                    }
                }
                else if (typeof(Label) == con.GetType())
                {
                    try
                    {
                        con.Font = font2;
                    }
                    catch (AccessViolationException ex)
                    {
                        MessageBox.Show("读取异常！");
                        MessageBox.Show("AccessViolationException错误提示：" + ex.Message);
                        return;
                    }
                }
                else if (typeof(ComboBox) == con.GetType())
                {
                    con.Font = font;
                    string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                    SetComBoxSize(mytag, newx, newy, con);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}