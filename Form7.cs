using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 期中專題_資策會南區_便當訂購系統
{
    public partial class Form7 : Form
    {


        SqlConnectionStringBuilder scsb;

        public string a;

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @"CR4-07\MSSQLSERVER2013";
            //scsb.DataSource = @"CHENG-PC\SQLEXPRESS";
            scsb.InitialCatalog = "FoodSystem";
            scsb.IntegratedSecurity = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbname.Text.Length > 0 && tbphone.Text.Length > 0)
            {

                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();


                SqlCommand cmda2 = new SqlCommand("Insert into student Values(@name,@phone,@class)", con);
                cmda2.Parameters.AddWithValue("@name", tbname.Text);
                cmda2.Parameters.AddWithValue("@phone", tbphone.Text);
                cmda2.Parameters.AddWithValue("@class", a);
                
                cmda2.ExecuteNonQuery(); ////執行SQL語法
                con.Close();
                MessageBox.Show("新增完成!!!!!");

                tbname.Clear();
                tbphone.Clear();

              
            }
            else
            {
                MessageBox.Show("有欄位沒有輸入 請再試一次!!!!", "提示視窗", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
