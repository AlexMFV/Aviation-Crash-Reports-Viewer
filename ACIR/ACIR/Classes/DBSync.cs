using ACIR.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACIR
{
    public static class DBSync
    {
        public static SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()) + "\\DB.mdf;Integrated Security=True");
        public static SqlCommand Command; //static gracas ao uso delas nos metodos que estao static static

        public static void BDConnect(string Procedure)
        {//static para funcionar com os metodos que estao com static
            bool IsConnected = false;
            int cnt = 0;
            while (!IsConnected)
            {
                try
                {
                    Command = new SqlCommand(Procedure, Con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    Con.Open();
                    IsConnected = true;
                }
                catch (Exception ex)
                {
                    if (cnt == 25)
                        throw ex;

                    cnt++;
                    BDDisconnect();
                }
            }
        }

        public static void BDDisconnect()
        {//static para funcionar com os metodos que estao com static
            Con.Close();
            Command = null;
        }

        public static int CreateOccurence(CrashInfo crash)
        {
            try
            {
                BDConnect("CreateOccurrence");

                Command.Parameters.AddWithValue("@date", crash.Date);
                Command.Parameters.AddWithValue("@model", crash.Plane);
                Command.Parameters.AddWithValue("@reg", crash.Reg);
                Command.Parameters.AddWithValue("@oper", crash.Operator);
                Command.Parameters.AddWithValue("@fat", crash.Fat);
                Command.Parameters.AddWithValue("@loc", crash.Loc);
                Command.Parameters.AddWithValue("@flag", ImageToByteArray(crash.Img));
                Command.Parameters.AddWithValue("@category", crash.Cat);
                Command.Parameters.AddWithValue("@link", crash.Link);

                int value = Convert.ToInt32(Command.ExecuteNonQuery());

                return value;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        public static Image ByteArrayToImage(byte[] arr)
        {
            if (arr == null)
                return null;

            MemoryStream ms = new MemoryStream(arr);
            return Image.FromStream(ms);
        }

        public static byte[] ImageToByteArray(Image img)
        {
            if (img == null)
                return null;

            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            return ms.ToArray();
        }

        //public static int GetCurrentOccurences()
        //{
        //    BDConnect("teste");
        //    SqlDataReader rd;

        //    rd = Command.ExecuteReader();
        //    int count = 0;
        //    while (rd.Read())
        //    {
        //        count++;
        //    }

        //    BDDisconnect();

        //    return count;
        //}
    }
}
