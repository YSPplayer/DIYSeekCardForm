using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using ICSharpCode.SharpZipLib.Zip;

namespace ZCGSeekCardForm
{
    /// <summary>
    /// 提供读取、写入流的扩展方法(来源网站)
    /// </summary>
    public static class StreamExtend
    {
        /// <summary>
        /// stream 、 string 、byte[] 间的转换扩展方法类
        /// </summary>

        #region Stream 扩展
        /// <summary>
        /// Stream Stream 转换为 byte 数组
        /// </summary>
        /// <returns></returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
        /// <summary>
        /// Stream 转换为 image 图片
        /// </summary>
        /// <returns></returns>
        public static Image ToImage(this Stream stream)
        {
            Image img = new Bitmap(stream);
            return img;
        }
        /// <summary>
        /// Stream 转换为 string ,使用 Encoding.Default 编码
        /// </summary>
        /// <returns></returns>
        public static string ToStr(this Stream stream)
        {
            return System.Text.Encoding.Default.GetString(stream.ToByteArray());
        }
        /// <summary>
        ///  在当前流中搜索指定的 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="beginPosition"></param>
        /// <param name="key">搜索关键字</param>
        /// <param name="indexId">搜索开始位置，从0开始</param>
        /// <returns>如果存在则返回byte[]在流中指定索引次数出现的位置，否则返回 -1</returns>
        public static long Search(this Stream stream, long beginPosition, byte[] key, int indexId)
        {
            if (stream == null || stream.Length <= beginPosition)
                return -1;

            if (key == null || stream.Length < key.Length)
                return -1;

            long i = -1;
            long j = -1;
            int times = 0;
            int currentByte = int.MinValue;
            for (i = beginPosition; i < stream.Length; i++)
            {
                if (stream.Length < key.Length + i)
                    break;

                stream.Seek(i, SeekOrigin.Begin);
                for (j = 0; j < key.Length; j++)
                {
                    currentByte = stream.ReadByte();
                    if (currentByte != key[j])
                        break;
                }

                if (j == key.Length && times < indexId)
                {
                    ++times;
                }
                else if (j == key.Length && times == indexId)
                {
                    return i;
                }

                if (currentByte == -1 || times > indexId)
                    break;
            }
            return -1;

        }
        /// <summary>
        ///c
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key">搜索关键字</param>
        /// <param name="beginPosition">搜索开始位置</param>
        /// <returns>如果存在则返回byte[]在流中首次出现的位置，否则返回 -1</returns>
        public static long Search(this Stream stream, long beginPosition, byte[] key)
        {
            if (stream == null || stream.Length <= beginPosition)
                return -1;

            if (key == null || stream.Length < key.Length)
                return -1;

            long i = -1;
            long j = -1;
            int currentByte = int.MinValue;
            for (i = beginPosition; i < stream.Length; i++)
            {
                if (stream.Length < key.Length + i)
                    break;

                stream.Seek(i, SeekOrigin.Begin);
                for (j = 0; j < key.Length; j++)
                {
                    currentByte = stream.ReadByte();
                    if (currentByte != key[j])
                        break;
                }
                if (j == key.Length)
                    return i;

                if (currentByte == -1)
                    break;
            }
            return -1;
        }
        #endregion

        #region byte[] 扩展
        /// <summary>
        /// byte[] 转换为 stream 流
        /// </summary>
        /// <returns></returns>
        public static Stream ToStream(this byte[] arr)
        {
            Stream stream = new MemoryStream(arr);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
        /// <summary>
        /// byte[] 转换为 Image
        /// </summary>
        /// <returns></returns>
        public static Image ToImage(this byte[] arr)
        {
            return Image.FromStream(arr.ToStream());
        }
        /// <summary>
        /// 转换为 string，使用 Encoding.Default 编码
        /// </summary>
        /// <returns></returns>
        public static string ToStr(this byte[] arr)
        {
            return System.Text.Encoding.Default.GetString(arr);
        }
        /// <summary>
        ///  在当前流中搜索指定的 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="beginPosition"></param>
        /// <param name="key">搜索关键字</param>
        /// <param name="indexId">搜索开始位置，从0开始</param>
        /// <returns>如果存在则返回byte[]在流中指定索引次数出现的位置，否则返回 -1</returns>
        public static int Search(this Stream stream, int beginPosition, byte[] key, int indexId)
        {
            if (stream == null || stream.Length <= beginPosition)
                return -1;

            if (key == null || stream.Length < key.Length)
                return -1;

            int i = -1;
            int j = -1;
            int times = 0;
            int currentByte = int.MinValue;
            for (i = beginPosition; i < stream.Length; i++)
            {
                if (stream.Length < key.Length + i)
                    break;

                stream.Seek(i, SeekOrigin.Begin);
                for (j = 0; j < key.Length; j++)
                {
                    currentByte = stream.ReadByte();
                    if (currentByte != key[j])
                        break;
                }

                if (j == key.Length && times < indexId)
                {
                    ++times;
                }
                else if (j == key.Length && times == indexId)
                {
                    return i;
                }

                if (currentByte == -1 || times > indexId)
                    break;
            }
            return -1;

        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="key">搜索关键字</param>
        /// <param name="beginPos">搜索开始位置</param>
        /// <returns></returns>
        public static int Search(this byte[] arr, int beginPosition, byte[] key)
        {
            if (arr == null || arr.Length <= beginPosition)
                return -1;

            if (key == null || arr.Length < key.Length)
                return -1;

            int i = -1;
            int j = -1;
            for (i = beginPosition; i < arr.Length; i++)
            {
                if (arr.Length < key.Length + i)
                    break;

                for (j = 0; j < key.Length; j++)
                {
                    if (arr[i + j] != key[j])
                        break;
                }
                if (j == key.Length)
                    return i;
            }
            return -1;
        }
        #endregion

        #region string 扩展
        /// <summary>
        /// string 转换为 byte[]
        /// </summary>
        /// <returns></returns>
        public static byte[] ToByteArray(this string str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }
        /// <summary>
        /// string 转换为 Stream
        /// </summary>
        /// <returns></returns>
        public static Stream ToStream(this string str)
        {
            Stream stream = new MemoryStream(str.ToByteArray());
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
        #endregion
        /// <summary>
        /// 获取文件的真实类型
        /// </summary>
        /// <param name="path"></param>
        public static bool CheckFileRealType(string path, FileTypeCode code)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            // 文件类型编码
            string fileTypeCode = string.Empty;

            try
            {
                byte buffer = r.ReadByte();
                fileTypeCode = buffer.ToString();
                buffer = r.ReadByte();
                fileTypeCode += buffer.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            r.Close();
            fs.Close();

            return fileTypeCode == code.ToString();
        }
        /// <summary>
        /// 获取文件的真实类型(仅限图片)
        /// </summary>
        /// <param name="path"></param>
        public static bool CheckFileRealType(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            // 文件类型编码
            string fileTypeCode = string.Empty;

            try
            {
                byte buffer = r.ReadByte();
                fileTypeCode = buffer.ToString();
                buffer = r.ReadByte();
                fileTypeCode += buffer.ToString();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            r.Close();
            fs.Close();
            return fileTypeCode == ((int)FileTypeCode.JPG).ToString()
                   || fileTypeCode == ((int)FileTypeCode.GIF).ToString()
                   || fileTypeCode == ((int)FileTypeCode.PNG).ToString();
        }
        private static string SetZip(bool res)
        {
            return res == true ?  "/\res" : "\\res";
        }
        /// <summary>
        /// 从压缩包中获取文件流，转为String
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileFromZIP(String file, String fileName, String fileName2)
        {
            //新建一个压缩包类
            ZipFile zip = new ZipFile(file);
            try
            {
                zip.Password = Properties.Settings.Default.Name+ SetZip(false);
            }
            catch
            {
                return null;
            }
            //获取压缩包内的指定名称的文件夹
            ZipEntry ze = zip.GetEntry(fileName);
            if (ze == null)
            {
                ze= zip.GetEntry(fileName2);
            }
            try
            {
                //根据这个文件夹创建流
                Stream zipStream = zip.GetInputStream(ze);
                using (StreamReader sr = new StreamReader(zipStream, Encoding.UTF8))
                {
                    //获取目标字符串
                    String result = sr.ReadToEnd();
                    //释放相关资源
                    sr.Close();
                    return result;
                }
            }
            catch
            {
                MessageBox.Show("当前卡片脚本不存在/通常怪兽没有脚本实现/暂不提供作者DIY之外的实现脚本");
                return null;
            }
        }
    }



    /// <summary>
    /// 文件类型枚举
    /// </summary>
    public enum FileTypeCode
    {
            JPG = 255216,
            GIF = 7173,
            BMP = 6677,
            PNG = 13780,
            COM = 7790,
            EXE = 7790,
            DLL = 7790,
            RAR = 8297,
            ZIP = 8075,
            XML = 6063,
            HTML = 6033,
            ASPX = 239187,
            CS = 117115,
            JS = 119105,
            TXT = 210187,
            SQL = 255254,
            BAT = 64101,
            BTSEED = 10056,
            RDP = 255254,
            PSD = 5666,
            PDF = 3780,
            CHM = 7384,
            LOG = 70105,
            REG = 8269,
            HLP = 6395,
            DOC = 208207,
            XLS = 208207,
            DOCX = 208207,
            XLSX = 208207,
        
    }
}


