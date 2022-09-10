namespace Serrator;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.comStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.comPortsList = new System.Windows.Forms.ComboBox();
            this.baudRatesList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.showTmChk = new System.Windows.Forms.CheckBox();
            this.dataTxt = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.clearSerialOutputBtn = new System.Windows.Forms.Button();
            this.filterOutputBtn = new System.Windows.Forms.Button();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.serialOutputTxt = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comStatusLbl});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // comStatusLbl
            // 
            this.comStatusLbl.Name = "comStatusLbl";
            resources.ApplyResources(this.comStatusLbl, "comStatusLbl");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comPortsList
            // 
            this.comPortsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortsList.FormattingEnabled = true;
            resources.ApplyResources(this.comPortsList, "comPortsList");
            this.comPortsList.Name = "comPortsList";
            // 
            // baudRatesList
            // 
            this.baudRatesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRatesList.FormattingEnabled = true;
            this.baudRatesList.Items.AddRange(new object[] {
            resources.GetString("baudRatesList.Items"),
            resources.GetString("baudRatesList.Items1"),
            resources.GetString("baudRatesList.Items2"),
            resources.GetString("baudRatesList.Items3"),
            resources.GetString("baudRatesList.Items4"),
            resources.GetString("baudRatesList.Items5"),
            resources.GetString("baudRatesList.Items6"),
            resources.GetString("baudRatesList.Items7"),
            resources.GetString("baudRatesList.Items8"),
            resources.GetString("baudRatesList.Items9"),
            resources.GetString("baudRatesList.Items10"),
            resources.GetString("baudRatesList.Items11"),
            resources.GetString("baudRatesList.Items12"),
            resources.GetString("baudRatesList.Items13")});
            resources.ApplyResources(this.baudRatesList, "baudRatesList");
            this.baudRatesList.Name = "baudRatesList";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // connectBtn
            // 
            resources.ApplyResources(this.connectBtn, "connectBtn");
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.ConnectToPort);
            // 
            // showTmChk
            // 
            resources.ApplyResources(this.showTmChk, "showTmChk");
            this.showTmChk.Name = "showTmChk";
            this.showTmChk.UseVisualStyleBackColor = true;
            this.showTmChk.Click += new System.EventHandler(this.ToggleTimestamp);
            // 
            // dataTxt
            // 
            resources.ApplyResources(this.dataTxt, "dataTxt");
            this.dataTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataTxt.Name = "dataTxt";
            // 
            // sendBtn
            // 
            resources.ApplyResources(this.sendBtn, "sendBtn");
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.SendData);
            // 
            // clearSerialOutputBtn
            // 
            resources.ApplyResources(this.clearSerialOutputBtn, "clearSerialOutputBtn");
            this.clearSerialOutputBtn.Name = "clearSerialOutputBtn";
            this.clearSerialOutputBtn.UseVisualStyleBackColor = true;
            this.clearSerialOutputBtn.Click += new System.EventHandler(this.ClearSerialOutput);
            // 
            // filterOutputBtn
            // 
            resources.ApplyResources(this.filterOutputBtn, "filterOutputBtn");
            this.filterOutputBtn.Name = "filterOutputBtn";
            this.filterOutputBtn.UseVisualStyleBackColor = true;
            this.filterOutputBtn.Click += new System.EventHandler(this.FilterOutput);
            // 
            // disconnectBtn
            // 
            resources.ApplyResources(this.disconnectBtn, "disconnectBtn");
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.DisconnectFromPort);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.SaveOutput);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.Exit);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // serialOutputTxt
            // 
            resources.ApplyResources(this.serialOutputTxt, "serialOutputTxt");
            this.serialOutputTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialOutputTxt.Name = "serialOutputTxt";
            this.serialOutputTxt.ReadOnly = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.serialOutputTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.filterOutputBtn);
            this.Controls.Add(this.clearSerialOutputBtn);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.dataTxt);
            this.Controls.Add(this.showTmChk);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.baudRatesList);
            this.Controls.Add(this.comPortsList);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeinitControls);
            this.Load += new System.EventHandler(this.InitControls);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private StatusStrip statusStrip1;
    private ToolStripStatusLabel comStatusLbl;
    private Label label1;
    private ComboBox comPortsList;
    private ComboBox baudRatesList;
    private Label label2;
    private Button connectBtn;
    private CheckBox showTmChk;
    private TextBox dataTxt;
    private Button sendBtn;
    private Button clearSerialOutputBtn;
    private Button filterOutputBtn;
    private Button disconnectBtn;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem1;
    private ToolStripSeparator toolStripSeparator1;
    private Label label3;
    private TextBox serialOutputTxt;
}
