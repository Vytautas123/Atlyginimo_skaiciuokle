using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlyginimo_skaičiuoklė
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // procentu  apsirasimas
            comboBoxProcent.Items.Add(10);            
            comboBoxProcent.Items.Add(21);
            comboBoxProcent.Items.Add(26);
            comboBoxProcent.Items.Add(18);

        }

        // kintamuju susikurimas
        double atlyginimas;
        double sodra;        
        double sveikdraudimas;
        double darbavsodra;
        double dimokos;
        double dismokos;
        double atlyg2;
        double NPD;
        double irankas;
        double sodra2;
        double pajamos;
        double pajamuProcent;
        double papilom;
        double papilsodra;
        
        private void btnSkaiciuti_Click(object sender, EventArgs e)
        {
            atlyginimas = double.Parse(texAtlyginimas.Text);

            // formules apskaiciuoti Atlyginimo i rankas 
            sodra = atlyginimas * 3 / 100;
            sveikdraudimas = atlyginimas * 6 / 100;
            darbavsodra = atlyginimas * 30.48 / 100;
            dimokos = atlyginimas * 0.2 / 100;
            dismokos = atlyginimas * 0.5 / 100;

            //  isvedimo funkcijos Atlyginimo i rankas
            textMokesciai.Text = sodra.ToString();           
            textSveikDraud.Text = sveikdraudimas.ToString();
            textDarbGarnt.Text = dimokos.ToString();
            textDarbSodr.Text = darbavsodra.ToString();
            textDarbIlgal.Text = dismokos.ToString();
        }

        private void btnSkaiciuti2_Click(object sender, EventArgs e)
        {
            atlyg2 = double.Parse(textRankas.Text);
                      
            // formules ir if else saliga Atliginimui ant popieriaus paskaiciuot
            if (atlyg2 >= 1200)
            {
              irankas = atlyg2 + 0;
              sodra2 = atlyg2 * 9 / 100;
            }
            else if(atlyg2 >= 600)
            {
                NPD = 380 - 0.5 * (atlyg2 - 402);
                irankas = atlyg2 + NPD;
                sodra2 = atlyg2 * 9 / 100;           

            }
            else
            {
                NPD = 380 - 0.6 * (atlyg2 - 10);
                irankas = atlyg2 + NPD;
                sodra2 = atlyg2 * 9 / 100;           

            }
            
            // isvedimo funkcijos Atlyginimui ant popieriaus
            textAtlyginimas2.Text = irankas.ToString();
            textSodra2.Text = sodra2.ToString();
        }

        private void checkBoxAutorSutart_CheckedChanged(object sender, EventArgs e)
        {
            //  pasirinktu objektu 1 formos Atoriniu teisiu aktivavimas pazimejus checkBox'a
            if (checkBoxAutorSutart.Checked == true)
            {
                label11.Enabled = true;
                label12.Enabled = true;
                label13.Enabled = true;
                textPajamos.Enabled = true;
                comboBoxProcent.Enabled = true;
                textPajamProcent.Enabled = true;
                btnSkaiciutiAutorin.Enabled = true;
            }
            if(checkBoxAutorSutart.Checked == false)
            {
                label11.Enabled = false;
                label12.Enabled = false;
                label13.Enabled = false; 
                textPajamos.Enabled = false;
                comboBoxProcent.Enabled = false;
                textPajamProcent.Enabled = false;
                btnSkaiciutiAutorin.Enabled = false;
            }
                        
        }

        private void btnSkaiciutiAutorin_Click(object sender, EventArgs e)
        {
            pajamos = double.Parse(textPajamos.Text);
            

            // procentu pasirinkimas pasirinku viena is keliu varijantu vikdoma if salyga
            // bei atitinkamai pasirinkus procentus pritaikoma matematine formule ir rezultato pateikimas
            if (comboBoxProcent.SelectedIndex == 0 || comboBoxProcent.SelectedIndex == 10)
            {
                pajamuProcent = pajamos * 10 / 100;
                textPajamProcent.Text = pajamuProcent.ToString();
            }
            else if (comboBoxProcent.SelectedIndex == 1 || comboBoxProcent.SelectedIndex == 21)
            {
                pajamuProcent = pajamos * 21 / 100;
                textPajamProcent.Text = pajamuProcent.ToString();
            }           
            else if (comboBoxProcent.SelectedIndex == 2 || comboBoxProcent.SelectedIndex == 26)
            {
                pajamuProcent = pajamos * 26 / 100;
                textPajamProcent.Text = pajamuProcent.ToString();
            }
            else if (comboBoxProcent.SelectedIndex == 3 || comboBoxProcent.SelectedIndex == 18)
            {
                pajamuProcent = pajamos * 18 / 100;
                textPajamProcent.Text = pajamuProcent.ToString();
            }

        }

        private void checkBoxPapildUzdarb_CheckedChanged(object sender, EventArgs e)
        {
            //  pasirinktu objektu Papildomu uzdarbiu aktivavimas pazimejus checkBox'a
            if (checkBoxPapildUzdarb.Checked == true)
            {
                label14.Enabled = true;
                label15.Enabled = true;
                textPapilom.Enabled = true;
                textUzmkSodr.Enabled = true;
                btnPapildomUzdarb.Enabled = true;
                
            }
            if (checkBoxPapildUzdarb.Checked == false)
            {
                label14.Enabled = false;
                label15.Enabled = false;
                textPapilom.Enabled = false;                
                textUzmkSodr.Enabled = false;
                btnPapildomUzdarb.Enabled = false;

            }
        }

        private void btnPapildomUzdarb_Click(object sender, EventArgs e)
        {
             papilom = double.Parse(textPapilom.Text);
             papilsodra = double.Parse(textUzmkSodr.Text);

            if (checkBoxPapildUzdarb.Checked ==true)
            {
                atlyg2 = papilom + papilsodra +irankas;

                textAtlyginimas2.Text = atlyg2.ToString();
            }
        }

        private void btnIseiti_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIseiti2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
