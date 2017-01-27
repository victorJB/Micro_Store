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

namespace MicroStore
{
    public partial class Login : Form
    {
        MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=microStore; Uid=root; pwd=123456;");

        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            this.conectar.Open();
            this.conectar.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.conectar.Open();
            string Line1 = this.textBox1.Text;
            string Line2 = this.textBox2.Text;
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM usuario WHERE nombreUsuario = '{0}'", Line1), this.conectar);
            MySqlDataReader lector = comando.ExecuteReader();


             if (lector.Read() == false)
            {
                MessageBox.Show("Usuario incorrecto");
            }


           else if(Line2 == lector.GetString(2))
            {
                this.Hide();
                ProductsInterface nuevo = new ProductsInterface();
                nuevo.ShowDialog();
                this.conectar.Close();
                this.Close();
            }

           else
            {
                MessageBox.Show("Usuario incorrecto");
            }

            this.conectar.Close();
        }
    }
}
