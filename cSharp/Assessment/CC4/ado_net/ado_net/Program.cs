using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sqlconnection1
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            UpdateData();
            //InsertData();
            //  SelectData();
            // Select_With_Parameters();
            Console.Read();

        }

        //let us create a common function to get the database connection
        private static SqlConnection getConnection()
        {
            con = new SqlConnection("data source = ICS-LT-4B6RQ73\\SQLEXPRESS01; initial catalog = Infinitedb;" +
                 "integrated security = true;");
            con.Open();
            return con;
        }

        //let us create a function to execute sql select statement
        public static void SelectData()
        {
            con = getConnection();
            // option 1
            // cmd = new SqlCommand("select * from tblemployees", con); command text with connection object
            //2 option 
            cmd = new SqlCommand("Select * from tblemployees"); //only command text


            cmd.Connection = con;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " | " + dr[1] + " | " + dr[2]);
            }
        }

        //select with a where predicate

        public static void Select_With_Parameters()
        {
            con = getConnection();
            int deptid;
            Console.WriteLine("Mention the DeptNo to select Employees Data :");
            deptid = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("select * from tblemployees where deptno = @did");

            //now we will associate the C# variable to that of sql variable along with data
            cmd.Parameters.AddWithValue("@did", deptid);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " | " + dr[1] + " | " + dr[2]);
            }
        }

        //insert a record
        public static void InsertData()
        {
            con = getConnection();
            int deptno;
            string deptname;
            float budget;
            Console.WriteLine("enter department details");
            deptno = Convert.ToInt32(Console.ReadLine());
            deptname = Console.ReadLine();
            budget = Convert.ToSingle(Console.ReadLine());
            

            cmd = new SqlCommand("Insert into tbldepartment values(@deptno,@deptname,@budget)", con);

            cmd.Parameters.AddWithValue("@deptno", deptno);
            cmd.Parameters.AddWithValue("@deptname", deptname);
            cmd.Parameters.AddWithValue("@budget", budget);

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
                Console.WriteLine("Insertion success");
            else
                Console.WriteLine("Could not insert data");

            SqlCommand cmd1 = new SqlCommand("select * from tbldepartment", con);
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " | " + dr[1] + " | " + dr[2]);
            }
        }
        public static void UpdateData()
        {
            con = getConnection();
            int deptid;
            float budget;

            Console.WriteLine("enter department number");
            deptid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter budget to be updated");
            budget = Convert.ToSingle(Console.ReadLine());


            cmd = new SqlCommand("update tbldepartment set budget=@budget where deptid=@deptid", con);

            cmd.Parameters.AddWithValue("@deptid", deptid);
            cmd.Parameters.AddWithValue("@budget", budget);

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
                Console.WriteLine("Updation success");
            else
                Console.WriteLine("Could not update data");

            SqlCommand cmd1 = new SqlCommand("select * from tbldepartment", con);
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " | " + dr[1] + " | " + dr[2]);

            }


        }
    }
}