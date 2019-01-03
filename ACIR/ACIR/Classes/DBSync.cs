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

        #region Insert

        public static int CreateOccurence(CrashInfo crash, int flag_id)
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
                Command.Parameters.AddWithValue("@flag_id", flag_id);
                Command.Parameters.AddWithValue("@category", crash.Cat);
                Command.Parameters.AddWithValue("@link", crash.Link);

                int value = Convert.ToInt32(Command.ExecuteScalar());

                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        public static void CreateOccurrenceInfo(CrashDetails cd, int occ_id, int img_id)
        {
            try
            {
                BDConnect("CreateOccurrenceInfo");

                Command.Parameters.AddWithValue("@img", img_id);
                Command.Parameters.AddWithValue("@model", cd._Model != null ? cd._Model : Convert.DBNull);
                Command.Parameters.AddWithValue("@date", cd._Date);
                Command.Parameters.AddWithValue("@time", cd._Time != null ? cd._Time : Convert.DBNull);
                Command.Parameters.AddWithValue("@status", cd._Status);
                Command.Parameters.AddWithValue("@oper", cd._Operator != null ? cd._Operator : Convert.DBNull);
                Command.Parameters.AddWithValue("@reg", cd._Registration != null ? cd._Registration : Convert.DBNull);
                Command.Parameters.AddWithValue("@firstFlight", cd._FirstFlight != null ? cd._FirstFlight : Convert.DBNull);
                Command.Parameters.AddWithValue("@crew", cd._Crew != null ? cd._Crew : Convert.DBNull);
                Command.Parameters.AddWithValue("@pass", cd._Passengers != null ? cd._Passengers : Convert.DBNull);
                Command.Parameters.AddWithValue("@total", cd._Total != null ? cd._Total : Convert.DBNull);
                Command.Parameters.AddWithValue("@dmg", cd._Damage != null ? cd._Damage : Convert.DBNull);
                Command.Parameters.AddWithValue("@loc", cd._Location != null ? cd._Location : Convert.DBNull);
                Command.Parameters.AddWithValue("@phase", cd._Phase != null ? cd._Phase : Convert.DBNull);
                Command.Parameters.AddWithValue("@nature", cd._Nature != null ? cd._Nature : Convert.DBNull);
                Command.Parameters.AddWithValue("@dep", cd._Departure != null ? cd._Departure : Convert.DBNull);
                Command.Parameters.AddWithValue("@dest", cd._Destination != null ? cd._Destination : Convert.DBNull);
                Command.Parameters.AddWithValue("@number", cd._FlightNumber != null ? cd._FlightNumber : Convert.DBNull);
                Command.Parameters.AddWithValue("@summary", cd._Summary != null ? cd._Summary : Convert.DBNull);
                Command.Parameters.AddWithValue("@cycles", cd._Cycles != null ? cd._Cycles : Convert.DBNull);
                Command.Parameters.AddWithValue("@engines", cd._Engines != null ? cd._Engines : Convert.DBNull);
                Command.Parameters.AddWithValue("@airframe", cd._AirframeHours != null ? cd._AirframeHours : Convert.DBNull);
                Command.Parameters.AddWithValue("@fate", cd._AircraftFate != null ? cd._AircraftFate : Convert.DBNull);
                Command.Parameters.AddWithValue("@map", cd._MapURL != null ? cd._MapURL : Convert.DBNull);
                Command.Parameters.AddWithValue("@occurrence_id", occ_id);

                int value = Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        public static int CreatePlaneImage(string model, byte[] img) //Image is already in bytes
        {
            try
            {
                BDConnect("CreatePlaneImage");

                Command.Parameters.AddWithValue("@model", model);
                Command.Parameters.AddWithValue("@img", img != null ? img : Convert.DBNull);

                return Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        public static int CreateFlagImage(string name, byte[] img)
        {
            if (name == null)
                return 0;

            try
            {
                BDConnect("CreateFlag");

                Command.Parameters.AddWithValue("@name", name);
                Command.Parameters.AddWithValue("@img", img != null ? img : Convert.DBNull);

                return Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

        #region Select

        public static int GetOccurrenceIDByLink(string link)
        {
            try
            {
                BDConnect("SelectOccurrenceByLink");

                Command.Parameters.AddWithValue("@link", link);

                return Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        public static int GetOccurrenceInfoByID(int id)
        {
            try
            {
                BDConnect("SelectOccurrenceInfoByOccurrenceID");

                Command.Parameters.AddWithValue("@occ_id", id);

                return Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        public static int GetPlaneImageIDByPlaneModel(string model)
        {
            try
            {
                BDConnect("SelectPlaneImageIDByPlaneModel");

                Command.Parameters.AddWithValue("@model", model.Trim());

                return Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        public static int GetFlagByFlagName(string name)
        {
            if (name == null)
                return 0;

            try
            {
                BDConnect("SelectFlagByFlagName");

                Command.Parameters.AddWithValue("@name", name);

                return Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BDDisconnect();
            }
        }

        #endregion

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
            img.Save(ms, ImageFormat.Gif);
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
