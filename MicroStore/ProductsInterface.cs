using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroStore
{
    public partial class ProductsInterface : Form
    {
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
    }
}
