namespace Youtube_Looper;

partial class mainForm
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
        titleLbl = new Label();
        urlLbl = new Label();
        urlTxt = new TextBox();
        loopLbl = new Label();
        loopTxt = new TextBox();
        playBtn = new Button();
        stopBtn = new Button();
        statusStrip1 = new StatusStrip();
        downloadStatus = new ToolStripStatusLabel();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // titleLbl
        // 
        titleLbl.AutoSize = true;
        titleLbl.Font = new Font("UD Digi Kyokasho NK-B", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
        titleLbl.Location = new Point(300, 20);
        titleLbl.Name = "titleLbl";
        titleLbl.Size = new Size(203, 28);
        titleLbl.TabIndex = 0;
        titleLbl.Text = "Youtube Looper";
        // 
        // urlLbl
        // 
        urlLbl.AutoSize = true;
        urlLbl.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        urlLbl.Location = new Point(20, 100);
        urlLbl.Name = "urlLbl";
        urlLbl.Size = new Size(114, 21);
        urlLbl.TabIndex = 1;
        urlLbl.Text = "Youtube URL";
        // 
        // urlTxt
        // 
        urlTxt.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        urlTxt.Location = new Point(180, 97);
        urlTxt.Name = "urlTxt";
        urlTxt.Size = new Size(580, 29);
        urlTxt.TabIndex = 2;
        // 
        // loopLbl
        // 
        loopLbl.AutoSize = true;
        loopLbl.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        loopLbl.Location = new Point(20, 160);
        loopLbl.Name = "loopLbl";
        loopLbl.Size = new Size(138, 21);
        loopLbl.TabIndex = 1;
        loopLbl.Text = "Number of loops";
        // 
        // loopTxt
        // 
        loopTxt.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        loopTxt.Location = new Point(180, 157);
        loopTxt.Name = "loopTxt";
        loopTxt.Size = new Size(80, 29);
        loopTxt.TabIndex = 2;
        // 
        // playBtn
        // 
        playBtn.BackColor = Color.FromArgb(128, 255, 128);
        playBtn.Font = new Font("UD Digi Kyokasho NK-B", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
        playBtn.Location = new Point(500, 240);
        playBtn.Name = "playBtn";
        playBtn.Size = new Size(120, 55);
        playBtn.TabIndex = 3;
        playBtn.Text = "Play";
        playBtn.UseVisualStyleBackColor = false;
        playBtn.Click += playBtn_Click;
        // 
        // stopBtn
        // 
        stopBtn.BackColor = Color.Tomato;
        stopBtn.Font = new Font("UD Digi Kyokasho NK-B", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
        stopBtn.Location = new Point(180, 240);
        stopBtn.Name = "stopBtn";
        stopBtn.Size = new Size(120, 55);
        stopBtn.TabIndex = 3;
        stopBtn.Text = "Stop";
        stopBtn.UseVisualStyleBackColor = false;
        stopBtn.Click += stopBtn_Click;
        // 
        // statusStrip1
        // 
        statusStrip1.Items.AddRange(new ToolStripItem[] { downloadStatus });
        statusStrip1.Location = new Point(0, 335);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(784, 26);
        statusStrip1.TabIndex = 4;
        statusStrip1.Text = "statusStrip1";
        // 
        // downloadStatus
        // 
        downloadStatus.BackColor = Color.Transparent;
        downloadStatus.Font = new Font("Yu Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        downloadStatus.Name = "downloadStatus";
        downloadStatus.Size = new Size(146, 21);
        downloadStatus.Text = "Download status...";
        // 
        // mainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 361);
        Controls.Add(statusStrip1);
        Controls.Add(stopBtn);
        Controls.Add(playBtn);
        Controls.Add(loopTxt);
        Controls.Add(urlTxt);
        Controls.Add(loopLbl);
        Controls.Add(urlLbl);
        Controls.Add(titleLbl);
        Name = "mainForm";
        Text = "Youtube Looper";
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label titleLbl;
    private Label urlLbl;
    private TextBox urlTxt;
    private Label loopLbl;
    private TextBox loopTxt;
    private Button playBtn;
    private Button stopBtn;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel downloadStatus;
}
