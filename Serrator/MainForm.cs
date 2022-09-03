namespace Serrator;

using System.IO.Ports;

public partial class MainForm : Form
{
    private readonly SerialPort _serialPort = new();
    private bool _showTimestamp;

    public MainForm()
    {
        InitializeComponent();

        _serialPort.DataReceived += SerialPortOnDataReceived;
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

    private void AppendText(string text)
    {
        if (serialOutputTxt.InvokeRequired)
            Invoke(new AppendTextCallback(AppendText), text);
        else
            serialOutputTxt.AppendText(text);
    }

    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        AppendText($"{(_showTimestamp ? $"[{DateTime.Now:HH:mm:ss}] " : "")}{((SerialPort)sender).ReadExisting() + Environment.NewLine}");
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
        var offset = serialOutputTxt.Lines.Sum(x => x.Length + Environment.NewLine.Length);

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
        _showTimestamp = !_showTimestamp;

        var lines = serialOutputTxt.Lines;

        if (_showTimestamp)
        {
            for (var i = 0; i < serialOutputTxt.Lines.Length; i++)
                lines[i] = $"[{DateTime.Now:HH:mm:ss}] {lines[i]}";
        }
        else
        {
            for (var i = 0; i < serialOutputTxt.Lines.Length; i++)
                lines[i] = lines[i][11 /* [aa:bb:cc] */..];
        }

        serialOutputTxt.Lines = lines;
    }

    private void SaveOutput(object sender, EventArgs e)
    {
        var saveDialog = new SaveFileDialog
        {
            CreatePrompt = true,
            OverwritePrompt = true,
            Filter = "Text files|*.txt"
        };

        var result = saveDialog.ShowDialog();

        if (result != DialogResult.OK)
            return;

        var lines = serialOutputTxt.Lines;
        if (_showTimestamp)
        {
            for (var i = 0; i < serialOutputTxt.Lines.Length; i++)
                lines[i] = lines[i][11 /* [aa:bb:cc] */..];
        }

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
}
