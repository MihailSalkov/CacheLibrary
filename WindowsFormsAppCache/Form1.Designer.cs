namespace WindowsFormsAppCache
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.buttonGet = new System.Windows.Forms.Button();
            this.buttonPut = new System.Windows.Forms.Button();
            this.radioButtonMethodLRU = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodMRU = new System.Windows.Forms.RadioButton();
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(26, 81);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(131, 20);
            this.textBoxKey.TabIndex = 0;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(172, 81);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(121, 20);
            this.textBoxValue.TabIndex = 1;
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(79, 65);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(25, 13);
            this.labelKey.TabIndex = 2;
            this.labelKey.Text = "Key";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(212, 65);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(34, 13);
            this.labelValue.TabIndex = 3;
            this.labelValue.Text = "Value";
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(55, 107);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(75, 23);
            this.buttonGet.TabIndex = 4;
            this.buttonGet.Text = "Get";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // buttonPut
            // 
            this.buttonPut.Location = new System.Drawing.Point(196, 107);
            this.buttonPut.Name = "buttonPut";
            this.buttonPut.Size = new System.Drawing.Size(75, 23);
            this.buttonPut.TabIndex = 5;
            this.buttonPut.Text = "Put";
            this.buttonPut.UseVisualStyleBackColor = true;
            this.buttonPut.Click += new System.EventHandler(this.buttonPut_Click);
            // 
            // radioButtonMethodLRU
            // 
            this.radioButtonMethodLRU.AutoSize = true;
            this.radioButtonMethodLRU.Checked = true;
            this.radioButtonMethodLRU.Location = new System.Drawing.Point(40, 27);
            this.radioButtonMethodLRU.Name = "radioButtonMethodLRU";
            this.radioButtonMethodLRU.Size = new System.Drawing.Size(47, 17);
            this.radioButtonMethodLRU.TabIndex = 6;
            this.radioButtonMethodLRU.Text = "LRU";
            this.radioButtonMethodLRU.UseVisualStyleBackColor = true;
            this.radioButtonMethodLRU.CheckedChanged += new System.EventHandler(this.radioButtonMethodLRU_CheckedChanged);
            // 
            // radioButtonMethodMRU
            // 
            this.radioButtonMethodMRU.AutoSize = true;
            this.radioButtonMethodMRU.Location = new System.Drawing.Point(120, 27);
            this.radioButtonMethodMRU.Name = "radioButtonMethodMRU";
            this.radioButtonMethodMRU.Size = new System.Drawing.Size(50, 17);
            this.radioButtonMethodMRU.TabIndex = 6;
            this.radioButtonMethodMRU.Text = "MRU";
            this.radioButtonMethodMRU.UseVisualStyleBackColor = true;
            this.radioButtonMethodMRU.CheckedChanged += new System.EventHandler(this.radioButtonMethodMRU_CheckedChanged);
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Location = new System.Drawing.Point(197, 27);
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size(109, 17);
            this.radioButtonCustom.TabIndex = 7;
            this.radioButtonCustom.TabStop = true;
            this.radioButtonCustom.Text = "Random (Custom)";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            this.radioButtonCustom.CheckedChanged += new System.EventHandler(this.radioButtonCustom_CheckedChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(125, 146);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "Clear cache";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select eviction strategy:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.radioButtonCustom);
            this.Controls.Add(this.radioButtonMethodMRU);
            this.Controls.Add(this.radioButtonMethodLRU);
            this.Controls.Add(this.buttonPut);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.textBoxKey);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example App for CacheLibrary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Button buttonPut;
        private System.Windows.Forms.RadioButton radioButtonMethodLRU;
        private System.Windows.Forms.RadioButton radioButtonMethodMRU;
        private System.Windows.Forms.RadioButton radioButtonCustom;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label1;
    }
}

