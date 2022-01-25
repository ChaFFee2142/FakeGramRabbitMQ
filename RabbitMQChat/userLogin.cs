using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RabbitMQChat
{
    public partial class userLogin : UserControl
    {
        public event EventHandler<string> onLogin;
        myDBConnection con = new myDBConnection();
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;

        public userLogin()
        {
            InitializeComponent();
            con.Connect();
        }

        private void userLogin_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                cmd = new MySqlCommand(String.Format("SELECT * FROM users WHERE username=\"{0}\" AND password=\"{1}\"",textBox1.Text, textBox2.Text), con.cn);
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt); 
                
                if(dt.Rows[0] != null)
                {
                    //Form1.Instance.Content.Controls.Add(new userChat());
                    onLogin?.Invoke(this, textBox1.Text);
                    Form1.Instance.Content.Controls[0].SendToBack();
                }
                con.cn.Close();
            }
            catch (Exception ex)
            {
                con.cn.Close();
                MessageBox.Show("Login failed");
            }
            
        }
    }
}
