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

            for (i=1;i<7;i++)
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
            int productos = 0;
            int i = 0;
            double[] total = new double[6];
            int[] articulosSeleccionados = new int[6];
            PaymentInterface nuevo = new PaymentInterface();

            articulosSeleccionados[0] = 9;
            articulosSeleccionados[1] = 9;
            articulosSeleccionados[2] = 9;
            articulosSeleccionados[3] = 9;
            articulosSeleccionados[4] = 9;
            articulosSeleccionados[5] = 9;
            PaymentInterface.productosAdquiridos[0] = 9;
            PaymentInterface.productosAdquiridos[1] = 9;
            PaymentInterface.productosAdquiridos[2] = 9;
            PaymentInterface.productosAdquiridos[3] = 9;
            PaymentInterface.productosAdquiridos[4] = 9;
            PaymentInterface.productosAdquiridos[5] = 9;


            if (checkBox1.Checked == true)
            {
                productos = productos + 1;
                articulosSeleccionados[0] = 8;
                PaymentInterface.productosAdquiridos[0] = 8;

            }

            if (checkBox2.Checked == true)
            {
                productos = productos + 1;
                articulosSeleccionados[1] = 8;
                PaymentInterface.productosAdquiridos[1] = 8;
            }

            if (checkBox3.Checked == true)
            {
                productos = productos + 1;
                articulosSeleccionados[2] = 8;
                PaymentInterface.productosAdquiridos[2] = 8;
            }

            if (checkBox4.Checked == true)
            {
                productos = productos + 1;
                articulosSeleccionados[3] = 8;
                PaymentInterface.productosAdquiridos[3] = 8;
            }

            if (checkBox5.Checked == true)
            {
                productos = productos + 1;
                articulosSeleccionados[4] = 8;
                PaymentInterface.productosAdquiridos[4] = 8;
            }

            if (checkBox6.Checked == true)
            {
                productos = productos + 1;
                articulosSeleccionados[5] = 8;
                PaymentInterface.productosAdquiridos[5] = 8;
            }

           
            if(productos == 0)
            {
                MessageBox.Show("Selecciona un producto por favor");
                this.conectar.Close();
            }

            else
            {
                for (i = 1; i < 7; i++)
                {
                    if (articulosSeleccionados[i - 1] == 8)
                    {
                        this.conectar.Open();
                        MySqlCommand comando = new MySqlCommand(String.Format("SELECT * FROM articulo WHERE articulo_id = {0}", i), this.conectar);
                        MySqlDataReader lector = comando.ExecuteReader();
                        lector.Read();
                        total[0] = total[0] + Convert.ToDouble(lector.GetString(2));
                        this.conectar.Close();
                    }

                }

                this.conectar.Close();
                this.Hide();
                PaymentInterface.nombreCliente = nombreCliente;
                nuevo.LabelText2 = "Total amount of selected products: " + productos.ToString();
                nuevo.LabelText3 = "Total: $" + total[0];
                nuevo.ShowDialog();
                this.Close();
            }
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
