using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEncrypter
{
    public partial class Encrypt : Form
    {
        AesCrypter aes;

        public Encrypt(AesCrypter aesArg)
        {
            InitializeComponent();
            aes = aesArg;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            // countinue in OpenFileDialog1_FileOk func
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            saveFileDialog1.ShowDialog();
            // countinue in next
        }

        public void setProgress(int progress)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(setProgress), new object[] { progress });
                return;
            }
            progressBar1.Value = progress;
        }
        public void setColor(Color color)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Color>(setColor), new object[] { color });
                return;
            }
            progressBar1.BackColor = color;
        }

        async void doSomthingAsych()
        {
            try
            {
                FileStream data = (FileStream)openFileDialog1.OpenFile();
                
                setProgress(2); 
                Stream encrypted = aes.Encrypt(data);
                setProgress(4);
                FileStream s = (FileStream)saveFileDialog1.OpenFile();
                setProgress(6);
                encrypted.CopyTo(s);

                encrypted.Close();
                data.Close();
                s.Close();
                setProgress(10);
            }
            catch (Exception ex)
            {
                setColor(Color.Red);
                debugConsole.AppendText($"Error: {ex.ToString()}\n");
            }
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            progressBar1.BackColor = Color.Green;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            Task.Run( new Action(doSomthingAsych) );
        }
    }
}
