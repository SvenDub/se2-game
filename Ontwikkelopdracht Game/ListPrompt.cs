using System.Collections.Generic;
using System.Windows.Forms;

namespace Ontwikkelopdracht_Game
{
    public partial class ListPrompt : Form
    {
        public ListPrompt(string caption, List<string> options)
        {
            InitializeComponent();

            Text = caption;
            options.ForEach(s => lstOptions.Items.Add(s));
        }

        public string SelectedItem => lstOptions.SelectedItem.ToString();

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            if (lstOptions.SelectedIndex > -1)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
