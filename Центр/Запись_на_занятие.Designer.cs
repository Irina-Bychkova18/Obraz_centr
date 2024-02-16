
namespace Центр
{
    partial class Запись_на_занятие
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.датаdateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.адресtextBox3 = new System.Windows.Forms.TextBox();
            this.фиоtextBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.закрытьbutton2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.номерtextBox1 = new System.Windows.Forms.TextBox();
            this.выполненcheckBox2 = new System.Windows.Forms.CheckBox();
            this.подтвержденcheckBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.датаdateTimePicker1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.адресtextBox3);
            this.tabPage1.Controls.Add(this.фиоtextBox2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.закрытьbutton2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.номерtextBox1);
            this.tabPage1.Controls.Add(this.выполненcheckBox2);
            this.tabPage1.Controls.Add(this.подтвержденcheckBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(767, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Содержимое записи";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // датаdateTimePicker1
            // 
            this.датаdateTimePicker1.Location = new System.Drawing.Point(85, 44);
            this.датаdateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.датаdateTimePicker1.Name = "датаdateTimePicker1";
            this.датаdateTimePicker1.Size = new System.Drawing.Size(104, 20);
            this.датаdateTimePicker1.TabIndex = 15;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(432, 257);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.BindingContextChanged += new System.EventHandler(this.dataGridView1_BindingContextChanged);
            // 
            // адресtextBox3
            // 
            this.адресtextBox3.Location = new System.Drawing.Point(506, 132);
            this.адресtextBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.адресtextBox3.Multiline = true;
            this.адресtextBox3.Name = "адресtextBox3";
            this.адресtextBox3.Size = new System.Drawing.Size(236, 45);
            this.адресtextBox3.TabIndex = 13;
            // 
            // фиоtextBox2
            // 
            this.фиоtextBox2.Location = new System.Drawing.Point(507, 99);
            this.фиоtextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.фиоtextBox2.Name = "фиоtextBox2";
            this.фиоtextBox2.Size = new System.Drawing.Size(236, 20);
            this.фиоtextBox2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Адрес:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "ФИО:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Учащийся:";
            // 
            // закрытьbutton2
            // 
            this.закрытьbutton2.Location = new System.Drawing.Point(628, 13);
            this.закрытьbutton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.закрытьbutton2.Name = "закрытьbutton2";
            this.закрытьbutton2.Size = new System.Drawing.Size(114, 26);
            this.закрытьbutton2.TabIndex = 8;
            this.закрытьbutton2.Text = "Закрыть";
            this.закрытьbutton2.UseVisualStyleBackColor = true;
            this.закрытьbutton2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // номерtextBox1
            // 
            this.номерtextBox1.Location = new System.Drawing.Point(84, 15);
            this.номерtextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.номерtextBox1.Name = "номерtextBox1";
            this.номерtextBox1.Size = new System.Drawing.Size(104, 20);
            this.номерtextBox1.TabIndex = 5;
            // 
            // выполненcheckBox2
            // 
            this.выполненcheckBox2.AutoSize = true;
            this.выполненcheckBox2.Location = new System.Drawing.Point(192, 44);
            this.выполненcheckBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.выполненcheckBox2.Name = "выполненcheckBox2";
            this.выполненcheckBox2.Size = new System.Drawing.Size(82, 17);
            this.выполненcheckBox2.TabIndex = 3;
            this.выполненcheckBox2.Text = "выполнена";
            this.выполненcheckBox2.UseVisualStyleBackColor = true;
            // 
            // подтвержденcheckBox1
            // 
            this.подтвержденcheckBox1.AutoSize = true;
            this.подтвержденcheckBox1.Location = new System.Drawing.Point(192, 16);
            this.подтвержденcheckBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.подтвержденcheckBox1.Name = "подтвержденcheckBox1";
            this.подтвержденcheckBox1.Size = new System.Drawing.Size(99, 17);
            this.подтвержденcheckBox1.TabIndex = 2;
            this.подтвержденcheckBox1.Text = "подтверждена";
            this.подтвержденcheckBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата записи:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер записи:";
            // 
            // Запись_на_занятие
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Запись_на_занятие";
            this.Text = "Запись_на_занятие";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox выполненcheckBox2;
        private System.Windows.Forms.CheckBox подтвержденcheckBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox номерtextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox адресtextBox3;
        private System.Windows.Forms.TextBox фиоtextBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button закрытьbutton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker датаdateTimePicker1;
    }
}