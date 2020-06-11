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
    public partial class FormOyunlar : Form
    {
        
        bool isActive = false;
        int counter,counterTemp,gameCounter, minesCounter;
        string remainingTimeText = "Kalan Süre:";
        List<bool> MinesList=new List<bool>();
        List<int> NeighboringMines = new List<int>();
        void closeForm()
        {
            foreach (FormOnIzleme frm in Application.OpenForms.OfType<FormOnIzleme>())
            {
                frm.Close(); return;
            }
        }
        private void startTheGame()
        {
            closeForm();
            MinesList.Clear();
            NeighboringMines.Clear();
            gameCounter = 25;
            minesCounter = (int)nudMayinSayisi.Value;
            Minefield.NumberMines = minesCounter;
            MinesList = Minefield.PlaceMines();
            NeighboringMines = Minefield.FindNeighboringMines();
            foreach (Control item in panelButton.Controls)
            {
                Button btn = (Button)item;
                btn.Text = "";
                btn.BackColor = Color.FromName("ActiveBorder");
                btn.Enabled = true;
            }
            counter = (int)nudSure.Value;
            counterTemp = (int)nudSure.Value;
            isActive = true;
            labelKalanSure.Text = remainingTimeText + " " + counterTemp;
            timer1.Start();

            FormOnIzleme foi = new FormOnIzleme();
            foi.MinesList = MinesList;
            foi.NeighboringMines = NeighboringMines;
            foi.Show();
        }
        private void gameFinishShow(string text)
        {
            isActive = false;
            timer1.Stop();
            panelButton.Enabled = false;
            MessageBox.Show(text);
        }

        public FormOyunlar()
        {
            InitializeComponent();
            foreach (Control item in panelButton.Controls)
            {
                Button btn = (Button)item;
                btn.Enabled = false;
            }
        }

        private void textBoxAltSinir_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxUstSinir_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int btnNo  =(Convert.ToInt32(btn.Name.Substring(6)))-1;
            btn.Enabled = false;
            counterTemp = counter;
            gameCounter--;
            btn.Text = NeighboringMines[btnNo].ToString();
            

            if (MinesList[btnNo] == true)
            {
                btn.BackColor = Color.Red;
                gameFinishShow("Oyun Bitti");
            }
            else
            {
                btn.BackColor = Color.Green;
            }
            if (minesCounter - gameCounter == 0)
            {
                gameFinishShow("Tebrikler Kazandınız...");
            }
        }
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Yeni oyun başlatmak istediğinizden emin misiniz?", "Yeni Oyun", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    startTheGame();
                }
                panelButton.Enabled = true;
            }
            else
            {
                startTheGame();
                panelButton.Enabled = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counterTemp <= 0)
            {
                gameFinishShow("Süre Bitti");
            }
            else
            {
                counterTemp--;
                labelKalanSure.Text = remainingTimeText + " " + counterTemp;
            }
        }
        private void btnBul_Click(object sender, EventArgs e)
        {
            if (textBoxUstSinir.Text!=""&& textBoxAltSinir.Text !="")
            {
                int upperLimit = Convert.ToInt32(textBoxUstSinir.Text);
                int lowerLimit = Convert.ToInt32(textBoxAltSinir.Text);
                listBox1.Items.Clear();
                List<int> armstrongNumbers = Armstrong.ArmstrongNumbersBetweenLimits(upperLimit, lowerLimit);
                foreach (var item in armstrongNumbers)
                {
                    listBox1.Items.Add(item);
                }
            }
        }
        
    }
}
