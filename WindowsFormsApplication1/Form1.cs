using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class monForm : Form
    {
        static Queue listeClients = new Queue();

        //affiche le client suivant en attente du prochain appelle
        static int lastClient;

        public monForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDernier.Clear();
            txtAfficheur.Clear();
            labTotale.Text = "_";
        }

        private void vnClient_Click(object sender, EventArgs e)
        {
                lastClient++;
                listeClients.Enqueue(lastClient);

                txtDernier.Text = lastClient.ToString();
                labTotale.Text = listeClients.Count.ToString();
        }

        private void nvAppel_Click(object sender, EventArgs e)
        {
            if (listeClients.Count > 0)
            {
                int appel;
                appel = (int) listeClients.Dequeue();

                Button caisse = new Button();
                caisse = (Button) sender;
                txtAfficheur.Text = caisse.Text + " appel le n° " + appel;
                labTotale.Text = listeClients.Count.ToString();
            }
            else
            {
                txtAfficheur.Text = "Aucun client en attente !";
            }
        }
    }
}
