using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;
using WhatsappTextFormatter.Business;

namespace WhatsappTextFormatter.WinForms
{
    public partial class TesterInterface : Form
    {
        private readonly FullTextFormatter _formatter;

        public TesterInterface()
        {
            InitializeComponent();

            _formatter = new FullTextFormatter();
            btFormat.Click += BtFormat_Click;

            rtbUnformattedText.Focus();
        }

        private void BtFormat_Click(object sender, EventArgs e)
        {
            //var info = new TextFormatInfo
            //{
            //    Text = "___**T~~he~~ ***~~_**qu~ick*** bro***_wn *_fox ju*_m~ps o_ver the _*__*lazy__~~*_**** ~dog__~~____",
            //    Bolds = new Tuple<int, int>[] { Tuple.Create(50, 56), Tuple.Create(57, 66), Tuple.Create(70, 76), Tuple.Create(80, 80) },
            //    Italics = new Tuple<int, int>[] { Tuple.Create(5, 17), Tuple.Create(21, 33), Tuple.Create(36, 41), Tuple.Create(50, 56), Tuple.Create(70, 74), Tuple.Create(77, 79), Tuple.Create(81, 81), Tuple.Create(84, 89) },
            //    StrikeThroughs = new Tuple<int, int>[] { Tuple.Create(80, 80) },
            //};
            var info = _formatter.GetTextFormatInfo(rtbUnformattedText.Text);

            rtbText.Text = info.Text;
            rtbFormatInfo.Text = JsonConvert.SerializeObject(info, Formatting.Indented);

            foreach (var pairs in info.Bolds)
            {
                var length = pairs.Item2 - pairs.Item1 + 1;
                rtbText.Select(pairs.Item1, length);

                rtbText.SelectionFont = new Font(rtbText.Font, rtbText.SelectionFont.Style | FontStyle.Bold);
            }

            foreach (var pairs in info.Italics)
            {
                var length = pairs.Item2 - pairs.Item1 + 1;
                rtbText.Select(pairs.Item1, length);

                rtbText.SelectionFont = new Font(rtbText.Font, rtbText.SelectionFont.Style | FontStyle.Italic);
            }

            foreach (var pairs in info.StrikeThroughs)
            {
                var length = pairs.Item2 - pairs.Item1 + 1;
                rtbText.Select(pairs.Item1, length);

                rtbText.SelectionFont = new Font(rtbText.Font, rtbText.SelectionFont.Style | FontStyle.Strikeout);
            }
        }
    }
}
