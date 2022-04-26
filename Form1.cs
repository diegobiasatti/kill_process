using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace killer_clock
{
    public partial class Form1 : Form
    {
        DateTime t1, t2;
        string hora;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //estas lineas estan agregadas para que arranque, ya seteado para Kill MP
            enabled.Checked = true;
            hora = "00:01:00";
            lbl_hora_cerrar.Text = hora;
            t1 = DateTime.Parse(hora);
            txt_file_path.Text = "Mercadopago";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            t1 = DateTime.Parse(dateTimePicker1.Text);
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            lbl_hora_cerrar.Text = t1.ToString("HH:mm:ss tt");
        }

        private void horario_Tick(object sender, EventArgs e)
        {
            hora = DateTime.Now.ToString("HH:mm:ss tt");
            
            lbl_hora.Text = hora;
            
            t2 = DateTime.Parse(hora);
            
            if(TimeSpan.Compare(t1.TimeOfDay, t2.TimeOfDay) == 0)
            {
                kill(txt_file_path.Text);
            }
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                txt_file_path.Text = openFileDialog1.SafeFileName.Replace(".exe","");
            }
        }

        private void enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (enabled.Checked)
            {
                btn_aceptar.Enabled = false;
                btn_file.Enabled = false;
                txt_file_path.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                btn_aceptar.Enabled = true;
                btn_file.Enabled = true;
                txt_file_path.Enabled = true;
                dateTimePicker1.Enabled =true;
            }
        }

        private void kill(string proceso)
        { int i;
            Process[] runingProcess = Process.GetProcesses();
            for (i = 0; i < runingProcess.Length; i++)
            {
               
                if (runingProcess[i].ProcessName == proceso)
                {
                    runingProcess[i].Kill();
                }

            }
        }

    }
}
