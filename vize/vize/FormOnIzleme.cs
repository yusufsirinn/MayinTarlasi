using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vize
{
    public partial class FormOnIzleme : Form
    {
        public FormOnIzleme()
        {
            InitializeComponent();
        }
        public List<bool> MinesList;
        public List<int> NeighboringMines;
        private void FormOnIzleme_Load(object sender, EventArgs e)
        {
            foreach (Button item in panelButton2.Controls)
            {
                Button btn = (Button)item;
                int btnNo = (Convert.ToInt32(btn.Name.Substring(6))) - 1;
                btn.Enabled = false;
                btn.Text = NeighboringMines[btnNo].ToString();
                if (MinesList[btnNo] == true)
                {
                    btn.BackColor = Color.Red;
                }
                else
                {
                    btn.BackColor = Color.Green;
                }
            }

        }
    }
}
