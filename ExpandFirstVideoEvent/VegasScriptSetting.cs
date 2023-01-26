using System.Windows.Forms;

namespace ExpandFirstVideoEvent
{
    public partial class VegasScriptSettingDialog : Form
    {
        public VegasScriptSettingDialog()
        {
            InitializeComponent();
        }

        public double ExpandMargin
        {
            get { return double.Parse(marginBox.Text); }
            set { marginBox.Text = value.ToString(); }
        }
    }
}
