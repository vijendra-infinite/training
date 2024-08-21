<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADO_CC1
{
    class Program
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            InsertData();
            SelectData();
            Console.Read();
        }
        // connection to sql
        public static SqlConnection GetConnection()
        {
            con = new SqlConnection("data source = ICS-LT-4B6RQ73\\SQLEXPRESS01; initial catalog = Employeemanagement;" +
                  "integrated security = true;");
            con.Open();
            return con;

        }



        // method for selecting data from table
        public static void SelectData()
        {
            con = GetConnection();
            cmd = new SqlCommand("select * from Employee_Details");
            cmd.Connection = con;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Empno : " + dr[0]);
                Console.WriteLine("EmpName : " + dr[1]);
                Console.WriteLine("Emp_sal : " + dr[2]);
                Console.WriteLine("Emptype : " + dr[3]);
            }
        }

        //method for inserting a row
        public static void InsertData()
        {
            con = GetConnection();
    
            string EmpName;
            int Emp_sal;
            char Emptype;

            
                
                Console.Write("Enter employee Name: ");
                EmpName = Console.ReadLine();

                Console.Write("Enter employee salary: ");
                Emp_sal = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter employee type  ");
                Emptype = char.ToUpper(Console.ReadKey().KeyChar);



                // Add Rows
                cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpName", EmpName);
                cmd.Parameters.AddWithValue("@Emp_sal", Emp_sal);
                cmd.Parameters.AddWithValue("@Emptype", Emptype);

                
                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                    Console.WriteLine("Updation success");
                else
                    Console.WriteLine("Could not update data");
              

              
                

            
            
        }
        //-------------------------------------------------------------------
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADO_CC1
{
    class Program
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            InsertData();
            SelectData();
            Console.Read();
        }
        // connection to sql
        public static SqlConnection GetConnection()
        {
            con = new SqlConnection("data source = ICS-LT-4B6RQ73\\SQLEXPRESS01; initial catalog = Employeemanagement;" +
                  "integrated security = true;");
            con.Open();
            return con;

        }



        // method for selecting data from table
        public static void SelectData()
        {
            con = GetConnection();
            cmd = new SqlCommand("select * from Employee_Details");
            cmd.Connection = con;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Empno : " + dr[0]);
                Console.WriteLine("EmpName : " + dr[1]);
                Console.WriteLine("Emp_sal : " + dr[2]);
                Console.WriteLine("Emptype : " + dr[3]);
            }
        }

        //method for inserting a row
        public static void InsertData()
        {
            con = GetConnection();
    
            string EmpName;
            int Emp_sal;
            char Emptype;

            
                
                Console.Write("Enter employee Name: ");
                EmpName = Console.ReadLine();

                Console.Write("Enter employee salary: ");
                Emp_sal = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter employee type  ");
                Emptype = char.ToUpper(Console.ReadKey().KeyChar);



                // Add Rows
                cmd = new SqlCommand("AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpName", EmpName);
                cmd.Parameters.AddWithValue("@Emp_sal", Emp_sal);
                cmd.Parameters.AddWithValue("@Emptype", Emptype);

                
                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                    Console.WriteLine("Updation success");
                else
                    Console.WriteLine("Could not update data");
              

              
                

            
            
        }
        //-------------------------------------------------------------------
    }
>>>>>>> b085a125942dd55cc881c5d912888ae618f5dee9
}