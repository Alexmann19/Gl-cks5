using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Glücks5
{
    public partial class Form2 : Form
    {

        public static String pfad1 = @"C:\Lottodaten\";
        public static String pfad2 = ".ini";

        public Form2()
        {
            InitializeComponent();
        }

        Random zufall = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            tbzahl1.Text = Convert.ToString(zufall.Next(1, 11));

            tbzahl2.Text = Convert.ToString(zufall.Next(1, 11));

            tbzahl3.Text = Convert.ToString(zufall.Next(1, 11));

            tbzahl4.Text = Convert.ToString(zufall.Next(1, 11));

            tbzahl5.Text = Convert.ToString(zufall.Next(1, 11));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbdatum.Text == String.Empty)
            {
                MessageBox.Show("Sie haben nichts eingegeben!", "Fehler", MessageBoxButtons.OK);
            }
            else
            if (!Directory.Exists(pfad1))
            {
                System.IO.Directory.CreateDirectory(pfad1);
            }
            else
            if (File.Exists(pfad1 + tbdatum.Text + pfad2))
            {
                File.Delete(pfad1 + tbdatum.Text + pfad2);
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pfad1 + tbdatum.Text + pfad2, true))
            {
                file.WriteLine(tbzahl1.Text);
                file.WriteLine(tbzahl2.Text);
                file.WriteLine(tbzahl3.Text);
                file.WriteLine(tbzahl4.Text);
                file.WriteLine(tbzahl5.Text);
            }
            if (tbdatum.Text != String.Empty)
            {
                MessageBox.Show("Sie haben die Zahlen erfoldreich gespeichert", "Erfolg", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] eingabe = null;
            try
            {
                // einlesen der Datei in ein String-Array
                eingabe = File.ReadAllLines(pfad1 + tbladen.Text + pfad2, Encoding.Default);
            }
            catch (Exception ex)
            {
                // Datei nicht vorhanden ...
                MessageBox.Show("Fehler beim Einlesen:\r\n", ex.Message);
                return;
            }
            tbzahl1.Text = eingabe[0];
            tbzahl2.Text = eingabe[1];
            tbzahl3.Text = eingabe[2];
            tbzahl4.Text = eingabe[3];
            tbzahl5.Text = eingabe[4];
            MessageBox.Show("Sie haben die Zahlen erfolgreich geladen", "Laden erfolgreich", MessageBoxButtons.OK);
        }
    }
}