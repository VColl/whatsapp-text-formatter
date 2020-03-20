using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WhatsappTextFormatter.Business;

namespace WhatsappTextFormatter.WinForms
{
    public partial class TesterInterface : Form
    {
        private readonly TextFormatter _formatter;

        public TesterInterface()
        {
            InitializeComponent();

            _formatter = new TextFormatter();
            btFormat.Click += BtFormat_Click;

            rtbUnformattedText.Focus();
        }

        private void BtFormat_Click(object sender, EventArgs e)
        {
            var info = _formatter.GetTextFormatInfo(rtbUnformattedText.Text);
            
            rtbText.Text = info.Text;
            rtbFormatInfo.Text = JsonConvert.SerializeObject(info, Formatting.Indented);

            foreach (var pairs in info.Bolds)
            {
                var length = pairs.Item2 - pairs.Item1 + 1;
                rtbText.Select(pairs.Item1, length);

                rtbText.SelectionFont = new Font(rtbText.Font, FontStyle.Bold);
            }

            foreach (var pairs in info.Italics)
            {
                var length = pairs.Item2 - pairs.Item1 + 1;
                rtbText.Select(pairs.Item1, length);

                rtbText.SelectionFont = new Font(rtbText.Font, FontStyle.Italic);
            }

            foreach (var pairs in info.StrikeThroughs)
            {
                var length = pairs.Item2 - pairs.Item1 + 1;
                rtbText.Select(pairs.Item1, length);

                rtbText.SelectionFont = new Font(rtbText.Font, FontStyle.Strikeout);
            }
        }
    }
}
