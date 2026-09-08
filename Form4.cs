using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sacred_Launcher
{
    public partial class Form4 : Form
    {
        private readonly Form3 form;
        public Form4(Form3 form)
        {
            InitializeComponent();
            this.form = form;
        }
    }
}
