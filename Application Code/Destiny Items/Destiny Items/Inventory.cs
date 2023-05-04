using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Destiny_Items
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        public void CharacterInventory(List<Character> characters)
        {
            foreach (Character character in characters)
            {

                lblForm2Display.Text = character.Name;
            }

        }

        public void SetInventory(string inventoryText)
        {
            lblForm2Display.Text = inventoryText;
        }
    }
}
