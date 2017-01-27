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
    public partial class PaymentInterface : Form
    {
        public PaymentInterface()
        {
            InitializeComponent();
            comboBox1.Items.Insert(0, "Credit/Debit Card");
            comboBox1.Items.Insert(1, "Gift code");
            
        }

        private void PaymentInterface_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sucessful payment");
            ProductsInterface nuevo = new ProductsInterface();
            this.Hide();
            nuevo.ShowDialog();
            this.Close();
        }
    }
}
