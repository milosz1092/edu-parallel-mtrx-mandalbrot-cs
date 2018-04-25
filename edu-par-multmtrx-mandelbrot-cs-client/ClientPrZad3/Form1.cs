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
using ClientPrZad3.ServiceReference1;

namespace ClientPrZad3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ToggleComputeButton()
        {
            if (pathMxA.Text.Length > 0 && pathMxB.Text.Length > 0)  {
                multMtrxBtn.Enabled = true;
            } else
            {
                multMtrxBtn.Enabled = false;
            }
        }

        private void browseMxA_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    pathMxA.Text = openFileDialog1.FileName;

                    VarStore.Global.fileMxA = text;
                    ToggleComputeButton();
                }
                catch (IOException)
                {
                }
            }
        }

        private void browseMxB_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    pathMxB.Text = openFileDialog1.FileName;

                    VarStore.Global.fileMxB = text;
                    ToggleComputeButton();
                }
                catch (IOException)
                {
                }
            }
        }

        private void multMtrxBtn_Click(object sender, EventArgs e)
        {
            WebService1SoapClient cl = new WebService1SoapClient();
            string idA = cl.SendMatrix(VarStore.Global.fileMxA);
            string idB = cl.SendMatrix(VarStore.Global.fileMxB);

            string idC = cl.MultipleMatrix(idA, idB);

            VarStore.Global.fileBytesMxC = cl.GetMatrix(idC);

            saveMtrxBtn.Enabled = true;
            multMtrxBtn.Enabled = false;

            pathMxA.Text = "";
            pathMxB.Text = "";
        }

        private void saveMtrxBtn_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text|*.txt";
            saveFileDialog1.Title = "Save a Matrix File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllBytes(saveFileDialog1.FileName, VarStore.Global.fileBytesMxC);

                saveMtrxBtn.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void genFractalBtn_Click(object sender, EventArgs e)
        {
            genFractalBtn.Enabled = false;
            saveFractalBtn.Enabled = false;
            int n;
            WebService1SoapClient cl = new WebService1SoapClient();

            int width = 0;
            if (int.TryParse(fractalWidth.Text, out n))
            {
                width = Int32.Parse(fractalWidth.Text);
            }

            int height = 0;
            if (int.TryParse(fractalHeight.Text, out n))
            {
                height = Int32.Parse(fractalHeight.Text);
            }

            int threads = 2;
            if (int.TryParse(fractalThreads.Text, out n))
            {
                threads = Int32.Parse(fractalThreads.Text);
            }

            string coloring = "threads";
            switch (fractalColoring.SelectedIndex)
            {
                case 0:
                    coloring = "threads";
                    break;
                case 1:
                    coloring = "cores";
                    break;
            }
            string id = cl.GenerateMandelbrot(width, height, threads, coloring);


            VarStore.Global.fileBytesFractal = cl.GetMandelbrot(id);

            saveFractalBtn.Enabled = true;
            genFractalBtn.Enabled = true;
        }

        private void saveFractalBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bitmap|*.bmp";
            saveFileDialog1.Title = "Save a Fractal File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllBytes(saveFileDialog1.FileName, VarStore.Global.fileBytesFractal);

                saveFractalBtn.Enabled = false;
            }
        }
    }
}

namespace VarStore
{
    static class Global
    {
        private static string _mxA = "";
        private static string _mxB = "";
        private static Byte[] _mxC;
        private static Byte[] _fractal;

        public static string fileMxA
        {
            get { return _mxA; }
            set { _mxA = value; }
        }

        public static string fileMxB
        {
            get { return _mxB; }
            set { _mxB = value; }
        }

        public static Byte[] fileBytesMxC
        {
            get { return _mxC; }
            set { _mxC = value; }
        }

        public static Byte[] fileBytesFractal
        {
            get { return _fractal; }
            set { _fractal = value; }
        }
    }
}