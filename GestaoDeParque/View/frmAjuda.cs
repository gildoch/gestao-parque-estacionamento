﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestaoDeParque.View
{
    public partial class frmAjuda : Form
    {
        public frmAjuda()
        {
            InitializeComponent();
        }

        private static frmAjuda f;
        public static frmAjuda GetInstance()
        {
            if (f == null || f.IsDisposed)
            {
                f = new frmAjuda();
            }
            return f;
        }


        private void frmAjuda_Load(object sender, EventArgs e)
        {

        }
    }
}
