using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ado_net
{
    //-----------------------Business Access Layer BAL--------------------
    class Region
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }
        public DataAccess da;
        public String InsertRegion()
        {
            Console.WriteLine("Enter Region ID");
            RegionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Region Description");
            RegionDescription = Console.ReadLine();
            String retval = DataAccess.InsertRegion(RegionId, RegionDescription);
            return retval;
        }
        public SqlDataReader DisplayRegion()
        {
            SqlDataReader sdr = DataAccess.DisplayRegion();
            return sdr;
        }
    }
    public class DataAccess
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlConnection getcon()
        {
            con = new SqlConnection("data source =ICS-LT-4B6RQ73\\SQLEXPRESS01; initial catalog = Northwind;" +
               "integrated security = true;");
            con.Open();
            return con;
        }
        public static String InsertRegion(int Rid, string rdesc)
        {
            con = getcon();
            cmd = new SqlCommand("insert into region values(@rid,@rdesc)", con);
            cmd.Parameters.AddWithValue("@rid", Rid);
            cmd.Parameters.AddWithValue("@rdesc", rdesc);
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                return "Success";
            else
                return "Failure";
        }
        public static SqlDataReader DisplayRegion()
        {
            con = getcon();
            cmd = new SqlCommand("Select * from region", con);
            dr = cmd.ExecuteReader();
            return dr;
        }
    }
    class Client
    {
        static void Main()
        {
            Region region = new Region();
            // Insert new region
            string Result = region.InsertRegion();
            Console.WriteLine("Insert Result: " + Result);
            SqlDataReader myreader = region.DisplayRegion();
            while (myreader.Read())
            {
                Console.WriteLine(myreader[0] + " " + myreader[1]);
            }
            Console.ReadLine();
        }
    }
}
