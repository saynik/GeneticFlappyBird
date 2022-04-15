namespace GeneticFlappyBird {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.RunBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.PopulationSizeBox = new System.Windows.Forms.NumericUpDown();
            this.TopCountBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.MutationProbabilityBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MutationProbabilityBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.Location = new System.Drawing.Point(173, 2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(480, 640);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(9, 90);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(158, 31);
            this.RunBtn.TabIndex = 1;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Population size";
            // 
            // PopulationSizeBox
            // 
            this.PopulationSizeBox.Location = new System.Drawing.Point(120, 12);
            this.PopulationSizeBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PopulationSizeBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PopulationSizeBox.Name = "PopulationSizeBox";
            this.PopulationSizeBox.Size = new System.Drawing.Size(47, 20);
            this.PopulationSizeBox.TabIndex = 3;
            this.PopulationSizeBox.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // TopCountBox
            // 
            this.TopCountBox.Location = new System.Drawing.Point(120, 38);
            this.TopCountBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TopCountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TopCountBox.Name = "TopCountBox";
            this.TopCountBox.Size = new System.Drawing.Size(47, 20);
            this.TopCountBox.TabIndex = 5;
            this.TopCountBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of the best";
            // 
            // MutationProbabilityBox
            // 
            this.MutationProbabilityBox.DecimalPlaces = 2;
            this.MutationProbabilityBox.Location = new System.Drawing.Point(120, 64);
            this.MutationProbabilityBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MutationProbabilityBox.Name = "MutationProbabilityBox";
            this.MutationProbabilityBox.Size = new System.Drawing.Size(47, 20);
            this.MutationProbabilityBox.TabIndex = 7;
            this.MutationProbabilityBox.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mutation probability";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 644);
            this.Controls.Add(this.MutationProbabilityBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TopCountBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PopulationSizeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.Text = "Genetic Flappy Bird C# NPRG035";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopulationSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MutationProbabilityBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PopulationSizeBox;
        private System.Windows.Forms.NumericUpDown TopCountBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown MutationProbabilityBox;
        private System.Windows.Forms.Label label3;
    }
}

