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
