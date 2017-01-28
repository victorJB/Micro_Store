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
        public static int[] productosAdquiridos = new int[6];
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
                this.conectar.Close();
                this.conectar.Open();
                MySqlCommand comando1 = new MySqlCommand(String.Format("DELETE FROM codigoRegalo WHERE codigo_id = {0}", codigo), this.conectar);
                MySqlDataReader lector1 = comando1.ExecuteReader();
                lector1.Read();
                this.conectar.Close();

                int i = 0;

                for(i=0;i<6;i++)
                {
                    if(productosAdquiridos[i] == 8)
                    {

                        this.conectar.Open();
                        MySqlCommand comando2 = new MySqlCommand(String.Format("SELECT * FROM articulo WHERE articulo_id = {0}", i + 1), this.conectar);
                        MySqlDataReader lector2 = comando2.ExecuteReader();
                        
                        if(lector2.Read() == false)
                        {
                            MessageBox.Show("Error");
                        }

                        else
                        {
                            int disponibles = Convert.ToInt32(lector2.GetString(3));
                            disponibles = disponibles - 1;
                            this.conectar.Close();
                            this.conectar.Open();
                            MySqlCommand comando3 = new MySqlCommand(String.Format("UPDATE articulo set cantidadDisponible = {0} WHERE articulo_id = {1}", disponibles, i + 1), this.conectar);
                            MySqlDataReader lector3 = comando3.ExecuteReader();
                            lector3.Read();
                            this.conectar.Close();
                        }

                    }
                }


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
