using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UmlElementLink
{
  public partial class ChooseReferenceForm : Form
  {
    public ChooseReferenceForm()
    {
      InitializeComponent();
      
    }

    public ChooseReferenceForm(IEnumerable<string> items)
      : this()
    {
      listBox1.Items.AddRange(items.ToArray());
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    void listBox1_DoubleClick(object sender, System.EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    public string Selection
    {
      get
      {
        return listBox1.SelectedItem as string;
      }
    }
  }
}
