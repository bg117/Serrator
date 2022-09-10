using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serrator
{
    public partial class FilterOutputForm : Form
    {
        private readonly MainForm? _refForm;

        internal Regex Pattern { get; private set; } = new(@".*", RegexOptions.IgnoreCase);

        public FilterOutputForm()
        {
            InitializeComponent();
        }

        public FilterOutputForm(MainForm mainForm)
        {
            _refForm = mainForm;

            InitializeComponent();
        }

        private void ApplyFilter(object sender, EventArgs e)
        {
            try
            {
                var pattern = new Regex(patternTxt.Text, RegexOptions.IgnoreCase);
                IEnumerable<string> lines;

                if (_refForm?.ShowTimestamp == false)
                    lines = _refForm?.RawLines.Where(x => pattern.IsMatch(x)) ?? Enumerable.Empty<string>();
                else
                    lines = _refForm?.RawLinesWithTimestamps.Where(x => pattern.IsMatch(x)) ?? Enumerable.Empty<string>();

                Pattern = pattern;

                if (_refForm != null)
                    _refForm.Lines = lines.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to filter output. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }
    }
}
