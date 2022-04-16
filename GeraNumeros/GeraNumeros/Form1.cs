using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraNumeros
{
    public partial class Form1 : Form
    {
        int[] listaNum = new int[1000]; //instanciando valor global das variaveis
        bool listaLimpa = true;
        string titulo;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPar_Click(object sender, EventArgs e)
        {
            int NumIni, i;
            NumIni = VerificaNumIni(); //chama método do tipo função que retorna
            if (NumIni>0)
            {
                titulo = "Lista de Números Pares a partir de " + NumIni + ":";
                if (NumIni % 2 == 1) // número inicial proposto não é par
                    NumIni += 1;
                for (i = 0; i < 1000; i++) //gera 1000 números pares desde o 0º
                    listaNum[i] = NumIni + i * 2;
                listaLimpa = false;
                MostraLista();
            }

        }

        public void MostraLista()
        {
            int i, qtditens = 0, maxitens = 1;
            string linha = "";
            if (!listaLimpa)
            {
                ltbLista.Items.Clear();
                if (rbt10.Checked) maxitens = 10;
                else if (rbt01.Checked) maxitens = 1;
                else if (rbt05.Checked) maxitens = 5;
                else if (rbt15.Checked) maxitens = 15;
                else maxitens = 20;
                ltbLista.Items.Add(titulo);
                for (i = 0; i < 1000; i++)
                {
                    linha = linha + " " + listaNum[i].ToString();
                    qtditens++;
                    if (qtditens == maxitens)
                    {
                        ltbLista.Items.Add(linha);
                        qtditens = 0;
                        linha = "";
                    }
                }
            }
        }

        public int VerificaNumIni()
        {
            int Num;
            if(!int.TryParse(txbNumInic.Text, out Num) || Num<1)
            {
                MessageBox.Show("Número inicial deve ser um número inteiro maior que zero!", "Erro de digitação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Num = 0;
                txbNumInic.Text = "";
            }
            return Num;
        }

        private void txbNumInic_TextChanged(object sender, EventArgs e)
        {


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ltbLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

      
    }
}
