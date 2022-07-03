using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestaoDeParque.View
{
    public partial class frmVisualizaViatura : Form
    {
        public frmVisualizaViatura()
        {
            InitializeComponent();
        }

        private static frmVisualizaViatura f;
        public static frmVisualizaViatura GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmVisualizaViatura();
            }
            return f;
        }

        private void frmVisualizaViatura_Load(object sender, EventArgs e)
        {

        }
    }
}
