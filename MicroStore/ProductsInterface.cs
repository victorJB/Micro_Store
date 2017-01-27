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
    public partial class ProductsInterface : Form
    {
        public static string nombreCliente;
        MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=microStore; Uid=root; pwd=123456;");

        public ProductsInterface()
        {
            InitializeComponent();
            
        }

        private void ProductsInterface_Load(object sender, EventArgs e)
        {
            int i = 0;
            int[] datos = new int[6];
            for(i=1;i<7;i++)
            {
                this.conectar.Open();
                MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM articulo WHERE articulo_id = {0}",i), this.conectar);
                MySqlDataReader lector = comando.ExecuteReader();
                lector.Read();
                datos[i-1] = Convert.ToInt32(lector.GetString(3));
                textBox1.Text = datos[0].ToString();
                textBox2.Text = datos[1].ToString();
                textBox3.Text = datos[2].ToString();
                textBox4.Text = datos[3].ToString();
                textBox5.Text = datos[4].ToString();
                textBox6.Text = datos[5].ToString();
                this.conectar.Close();
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaymentInterface nuevo = new PaymentInterface();
            this.Hide();
            PaymentInterface.nombreCliente = nombreCliente;
            nuevo.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login nuevo = new Login();
            this.Hide();
            nuevo.ShowDialog();
            this.Close();
        }


        public string LabelText3
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
