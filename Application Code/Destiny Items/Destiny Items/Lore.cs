using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Destiny_Items
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public void SetLore(string inventoryText, Image picture)
        {
            lblLoreDisplay.Text = inventoryText;
            pbUno.Image = picture;
        }
    }
}
