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

namespace FileEncrypter
{
    public partial class Form1 : Form
    {
        AesCrypter aes;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("key") && File.Exists("iv"))
            {
                aes = new AesCrypter();
            }
            else
            {
                DialogResult result = MessageBox.Show("Please copy your KEY and IV or generate new!\n Do you want to generate new?", "Error",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    AesCrypter.GenerateNewKeyAndIV();
                    aes = new AesCrypter();
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            //generate new key
            AesCrypter.GenerateNewKeyAndIV();
            aes = new AesCrypter();
        }

        private void Button1_Click(object sender, EventArgs e) // encrypt
        {
            Encrypt en = new Encrypt(aes);
            en.Show();
            //en.Close();
        }

        private void Button3_Click(object sender, EventArgs e) // decrypt button
        {
            DecryptForm df = new DecryptForm(aes);
            df.Show();
            //df.Close();
        }
    }
}
