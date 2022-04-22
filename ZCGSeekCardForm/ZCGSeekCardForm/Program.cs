using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZCGSeekCardForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("异常！" + ex.Message);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return;
            }
        }
    }
}
