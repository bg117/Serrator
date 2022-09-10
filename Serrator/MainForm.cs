namespace Serrator;

using System.IO.Ports;

public partial class MainForm : Form
{
    private readonly SerialPort _serialPort = new();
    private readonly FilterOutputForm _filterOutputForm;

    internal string[] Lines { get => GetLines(); set => SetLines(value); }
    internal List<string> RawLines { get; } = new();
    internal List<string> RawLinesWithTimestamps { get; } = new();
    internal bool ShowTimestamp { get; private set; }

    public MainForm()
    {
        InitializeComponent();

        _serialPort.DataReceived += SerialPortOnDataReceived;
        _filterOutputForm = new FilterOutputForm(this);
    }

    private void InitControls(object sender, EventArgs e)
    {
        baudRatesList.SelectedIndex = 6;

        var comPorts = SerialPort.GetPortNames();
        foreach (var comPort in comPorts)
            comPortsList.Items.Add(comPort);

        if (comPortsList.Items.Count > 0)
            comPortsList.SelectedIndex = 0;
    }

    private void ConnectToPort(object sender, EventArgs e)
    {
        if (_serialPort.IsOpen)
            _serialPort.Close();

        serialOutputTxt.Clear();

        var com = comPortsList.SelectedItem?.ToString();
        var baudRate = int.Parse(baudRatesList.SelectedItem?.ToString() ?? "9600");

        if (string.IsNullOrWhiteSpace(com))
        {
            MessageBox.Show("Please select a serial port to connect to.", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        _serialPort.PortName = com;
        _serialPort.BaudRate = baudRate;
        _serialPort.Parity = Parity.None;

        try
        {
            _serialPort.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open serial port {com}. {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        comStatusLbl.Text = com;

        dataTxt.Enabled = true;
        sendBtn.Enabled = true;
        disconnectBtn.Enabled = true;
        clearSerialOutputBtn.Enabled = true;
        filterOutputBtn.Enabled = true;
    }

    private delegate void AppendTextCallback(string text);
    private delegate void SetLinesCallback(string[] lines);
    private delegate string[] GetLinesCallback();

    private void AppendText(string text)
    {
        if (serialOutputTxt.InvokeRequired)
            Invoke(new AppendTextCallback(AppendText), text);
        else
            serialOutputTxt.AppendText(text);
    }

    private void SetLines(string[] lines)
    {
        if (serialOutputTxt.InvokeRequired)
            Invoke(new SetLinesCallback(SetLines), new object[] { lines });
        else
            serialOutputTxt.Lines = lines;
    }

    private string[] GetLines()
    {
        if (serialOutputTxt.InvokeRequired)
            return (string[])Invoke(new GetLinesCallback(GetLines));

        return serialOutputTxt.Lines;
    }

    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        var data = ((SerialPort)sender).ReadExisting();
        var now = DateTime.Now;

        RawLines.Add(data);
        RawLinesWithTimestamps.Add($"[{now:HH:mm:ss}] {data}");

        if (!_filterOutputForm.Pattern.IsMatch(data))
            return;

        var tmp = Lines.ToList();
        tmp.Add(ShowTimestamp ? $"[{now:HH:mm:ss}] {data}" : data);

        Lines = tmp.ToArray();
    }

    private void DisconnectFromPort(object sender, EventArgs e)
    {
        if (_serialPort.IsOpen)
            _serialPort.Close();

        comStatusLbl.Text = "Disconnected";

        dataTxt.Enabled = false;
        sendBtn.Enabled = false;
        disconnectBtn.Enabled = false;
        clearSerialOutputBtn.Enabled = false;
        filterOutputBtn.Enabled = false;
    }

    private void DeinitControls(object sender, FormClosingEventArgs e)
    {
        if (_serialPort.IsOpen)
            _serialPort.Close();
    }

    private void SendData(object sender, EventArgs e)
    {
        var data = dataTxt.Text ?? string.Empty;
        var format = $"{data} <{Environment.NewLine}";
        var offset = Lines.Sum(x => x.Length + Environment.NewLine.Length);

        _serialPort.Write(data);

        //serialOutputTxt.AppendText(format);
        //serialOutputTxt.Select(offset, format.Length);
        //serialOutputTxt.SelectionAlignment = HorizontalAlignment.Right;
    }

    private void ClearSerialOutput(object sender, EventArgs e)
    {
        serialOutputTxt.Clear();
    }

    private void ToggleTimestamp(object sender, EventArgs e)
    {
        ShowTimestamp = !ShowTimestamp;
        var lines = ShowTimestamp ? RawLinesWithTimestamps : RawLines;

        Lines = lines.Where(x => _filterOutputForm.Pattern.IsMatch(x)).ToArray();
    }

    private void SaveOutput(object sender, EventArgs e)
    {
        var saveDialog = new SaveFileDialog
        {
            CreatePrompt = true,
            OverwritePrompt = true,
            Filter = "Text files|*.txt"
        };

        var result = saveDialog.ShowDialog(this);

        if (result != DialogResult.OK)
            return;

        var lines = ShowTimestamp ? RawLinesWithTimestamps : RawLines;
        var data = string.Join(Environment.NewLine, lines);
        using var sw = new StreamWriter(saveDialog.FileName);

        sw.Write(data);
    }

    private void Exit(object sender, EventArgs e)
    {
        Application.Exit();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        switch (keyData)
        {
            case Keys.Control | Keys.Enter:
                sendBtn.PerformClick();
                return true;
            default:
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    private void FilterOutput(object sender, EventArgs e)
    {
        _filterOutputForm.ShowDialog();
    }
}
