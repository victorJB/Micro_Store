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
    public partial class PaymentInterface : Form
    {
        public static string nombreCliente;
        MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=microStore; Uid=root; pwd=123456;");

        public PaymentInterface()
        {
            InitializeComponent();

        }

        private void PaymentInterface_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            this.conectar.Open();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM codigoRegalo WHERE codigo_id = {0}", codigo), this.conectar);
            MySqlDataReader lector = comando.ExecuteReader();

            if (lector.Read() == false)
            {
                MessageBox.Show("Codigo incorrecto");
                this.conectar.Close();

            }

            else
            {
                MessageBox.Show("Sucessful payment");
                ProductsInterface nuevo = new ProductsInterface();
                nuevo.LabelText3 = "Welcome ";
                nuevo.LabelText3 += nombreCliente;
                ProductsInterface.nombreCliente = nombreCliente;
                this.Hide();
                nuevo.ShowDialog();
                this.Close();
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductsInterface nuevo = new ProductsInterface();
            nuevo.LabelText3 = "Welcome ";
            nuevo.LabelText3 += nombreCliente;
            ProductsInterface.nombreCliente = nombreCliente;
            this.Hide();
            nuevo.ShowDialog();
            this.Close();
        }

        public string LabelText2
        {
            get
            {
                return this.label2.Text;
            }
            set
            {
                this.label2.Text = value;
            }
        }

        public string LabelText3
        {
            get
            {
                return this.label3.Text;
            }
            set
            {
                this.label3.Text = value;
            }
        }

       
    }
}
