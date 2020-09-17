using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACCServerManager
{
	public partial class UnsavedChangesForm : Form
	{
		private Form1 form1;
		internal bool SaveAndClose = false;
		internal bool CloseForm = false;
		internal bool Cancel = false;
		public UnsavedChangesForm()
		{
			InitializeComponent();
			
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveAndClose = true;
			this.Close();
		}

		private void UnsavedChangesForm_Load(object sender, EventArgs e)
		{
			form1 = new Form1();
		}

		private void btnDontSave_Click(object sender, EventArgs e)
		{
			CloseForm = true;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Cancel = true;
			this.Close();
		}
	}
}
