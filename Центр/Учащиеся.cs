using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Центр
{
    public partial class Учащиеся : Form
    {
        public Учащиеся()
        {
            InitializeComponent();
        }
        public static int n = 0;
        private void FieldsForm_Fill()
        {
             
            кодtextBox1.Text = Главная.cdt.Tables["Учащиеся"].Rows[n]["Код"].ToString();
            фиоtextBox4.Text = Главная.cdt.Tables["Учащиеся"].Rows[n]["ФИО"].ToString();
            датаdateTimePicker1.Text = Главная.cdt.Tables["Учащиеся"].Rows[n]["Дата рождения"].ToString();
            адресtextBox5.Text = Главная.cdt.Tables["Учащиеся"].Rows[n]["Адрес"].ToString();
            кружкиcomboBox1.Text = Главная.cdt.Tables["Учащиеся"].Rows[n]["name"].ToString();
            логинtextBox2.Text = Главная.cdt.Tables["Учащиеся"].Rows[n]["Логин"].ToString();
            парольtextBox3.Text = Главная.cdt.Tables["Учащиеся"].Rows[n]["Пароль"].ToString();
            кодtextBox1.Enabled = false;
        }
        private void FieldsForm_Clear()
        {
            кодtextBox1.Text = "0";
            фиоtextBox4.Text = "";
            датаdateTimePicker1.ResetText();
            адресtextBox5.Text = "";
            кружкиcomboBox1.Text = "";
            логинtextBox2.Text = "";
            парольtextBox3.Text = "";
            кодtextBox1.Enabled = true; кодtextBox1.Focus();
            
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            Главная.Table_Fill("Учащиеся", "SELECT uchashiesa.id_uch AS \"Код\",uchashiesa.fio AS \"ФИО\", uchashiesa.data_r AS \"Дата рождения\", uchashiesa.adres_projivania AS \"Адрес\", kursi.name as\"name\" ,  uchashiesa.login  AS \"Логин\", uchashiesa.parol  AS \"Пароль\" FROM uchashiesa left join kursi on  uchashiesa.id_k = kursi.id_k ORDER BY \"Код\"");
           
            кружкиcomboBox1.DataSource = Главная.cdt.Tables["Курсы"].DefaultView;
            кружкиcomboBox1.DisplayMember = "name";

            if (Главная.cdt.Tables["Учащиеся"].Rows.Count > n)
                FieldsForm_Fill();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (n < Главная.cdt.Tables["Учащиеся"].Rows.Count) n++;
            if (Главная.cdt.Tables["Учащиеся"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FieldsForm_Clear();
            n = Главная.cdt.Tables["Учащиеся"].Rows.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Главная.cdt.Tables["Учащиеся"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kod = Главная.cdt.Tables["Курсы"].DefaultView[кружкиcomboBox1.SelectedIndex]["Код"].ToString();
            string sql;
           if (n < Главная.cdt.Tables["Учащиеся"].Rows.Count)
            {
                 sql = "UPDATE uchashiesa SET fio='" + фиоtextBox4.Text + "', data_r='" + датаdateTimePicker1.Value.ToString("yyyy-MM-dd") + "', adres_projivania='" + адресtextBox5.Text + "', id_k=" + kod + " WHERE id_uch=" + кодtextBox1.Text;
                 if (!Главная.Modification_Execute(sql))
                    return;
                Главная.cdt.Tables["Учащиеся"].Rows[n].ItemArray = new object[] { кодtextBox1.Text, фиоtextBox4.Text, датаdateTimePicker1.Value.ToString("yyyy-MM-dd"), адресtextBox5.Text, кружкиcomboBox1.Text, логинtextBox2.Text, парольtextBox3.Text };

            }

            else
            {
                sql = "INSERT INTO uchashiesa (id_uch, fio, data_r, adres_projivania, id_k) VALUES (" + кодtextBox1.Text + ",'" + фиоtextBox4.Text + "','" + датаdateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + адресtextBox5.Text + "'," + kod + ")";
                if (!Главная.Modification_Execute(sql))
                    return;
                кодtextBox1.Enabled = false;
                Главная.cdt.Tables["Учащиеся"].Rows.Add(new object[] { кодtextBox1.Text, фиоtextBox4.Text, датаdateTimePicker1.Value.ToString("yyyy-MM-dd"), адресtextBox5.Text, кружкиcomboBox1.Text, логинtextBox2.Text, парольtextBox3.Text });


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Главная.tabControl1.Controls.Remove(Главная.tabControl1.SelectedTab);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника учащегося с кодом " + кодtextBox1.Text + "?";
            string caption = "Удаление учащегося";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(message, caption, buttons);
            if (rezult == DialogResult.No) { return; }
            string sql = "DELETE FROM uchashiesa WHERE id_uch=" + кодtextBox1.Text;
            Главная.Modification_Execute(sql);
            Главная.cdt.Tables["Учащиеся"].Rows.RemoveAt(n);
            if (Главная.cdt.Tables["Учащиеся"].Rows.Count > n)
                FieldsForm_Fill();
            else
                FieldsForm_Clear();
        }
    }
}
