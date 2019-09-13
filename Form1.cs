using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FileEncrypter
{
    public partial class Form1 : Form
    {
        AesCrypter aes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) // encrypt
        {
            Encrypt en = new Encrypt(aes);
            en.Show();
        }

        private void Button3_Click(object sender, EventArgs e) // decrypt button
        {
            DecryptForm df = new DecryptForm(aes);
            df.Show();
        }

        private void DoneButton_Click(object sender, EventArgs e) // setbutton
        {
            aes = new AesCrypter(Tuple.Create<byte[],byte[]>(Convert.FromBase64String(keyBox.Text), Convert.FromBase64String(ivBox.Text)) );
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            Tuple<byte[], byte[]> t = AesCrypter.GenerateNewKeyAndIV();
            keyBox.Text = Convert.ToBase64String(t.Item1);
            ivBox.Text = Convert.ToBase64String(t.Item2);
            aes = new AesCrypter(t);
        }
    }
}
