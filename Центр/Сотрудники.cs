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
    public partial class Сотрудники : Form
    {
        public Сотрудники()
        {
            InitializeComponent();
        }
        public static int n = 0;
        private void FieldsForm_Fill()
        {
            string sql = "SELECT sotrudniki.id_sot AS \"Код\",sotrudniki.fio AS \"ФИО\", sotrudniki.vozrast AS \"Возраст\", sotrudniki.telephon AS \"Телефон\", sotrudniki.login  AS \"Логин\", sotrudniki.parol  AS \"Пароль\" FROM sotrudniki ORDER BY \"Код\"";
            Главная.Table_Fill("Сотрудники", sql);
            кодtextBox1.Text = Главная.cdt.Tables["Сотрудники"].Rows[n]["Код"].ToString();
            фиоtextBox4.Text = Главная.cdt.Tables["Сотрудники"].Rows[n]["ФИО"].ToString();
            textBox1.Text = Главная.cdt.Tables["Сотрудники"].Rows[n]["Возраст"].ToString();
            телефонtextBox5.Text = Главная.cdt.Tables["Сотрудники"].Rows[n]["Телефон"].ToString();
            логинtextBox2.Text = Главная.cdt.Tables["Сотрудники"].Rows[n]["Логин"].ToString();
            парольtextBox3.Text = Главная.cdt.Tables["Сотрудники"].Rows[n]["Пароль"].ToString();
            кодtextBox1.Enabled = false;
        }
        private void FieldsForm_Clear()
        {
            кодtextBox1.Text = "0";
            фиоtextBox4.Text = "";
            textBox1.Text = "";
            телефонtextBox5.Text = "";
            логинtextBox2.Text = "";
            парольtextBox3.Text = "";
            кодtextBox1.Enabled = true; кодtextBox1.Focus();

        }
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            Главная.Table_Fill("Сотрудники", "SELECT sotrudniki.id_sot AS \"Код\", sotrudniki.fio AS \"ФИО\", sotrudniki.vozrast AS \"Возраст\", sotrudniki.telephon AS \"Телефон\", sotrudniki.login  AS \"Логин\", sotrudniki.parol  AS \"Пароль\" FROM sotrudniki ORDER BY \"Код\"");
            if (Главная.cdt.Tables["Сотрудники"].Rows.Count > n)
                FieldsForm_Fill();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FieldsForm_Clear();
            n = Главная.cdt.Tables["Сотрудники"].Rows.Count;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (n < Главная.cdt.Tables["Сотрудники"].Rows.Count) n++;
            if (Главная.cdt.Tables["Сотрудники"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
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
            if (Главная.cdt.Tables["Сотрудники"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string sql;
            if (n < Главная.cdt.Tables["Сотрудники"].Rows.Count)
            {
                sql = "UPDATE sotrudniki SET fio='" + фиоtextBox4.Text + "', vozrast=" + textBox1.Text + ", telephon='" + телефонtextBox5.Text + "' WHERE id_sot=" + кодtextBox1.Text;
                if (!Главная.Modification_Execute(sql))
                    return;
                Главная.cdt.Tables["Сотрудники"].Rows[n].ItemArray = new object[] { кодtextBox1.Text, фиоtextBox4.Text, textBox1.Text, телефонtextBox5.Text, логинtextBox2.Text, парольtextBox3.Text };

            }
            else
            {
                sql = "INSERT INTO sotrudniki (id_sot, fio, vozrast, telephon) VALUES (" + кодtextBox1.Text + ",'" + фиоtextBox4.Text + "'," + textBox1.Text + ",'" + телефонtextBox5.Text + "')";
                if (!Главная.Modification_Execute(sql))
                    return;
                кодtextBox1.Enabled = false;
                Главная.cdt.Tables["Сотрудники"].Rows.Add(new object[] { кодtextBox1.Text, фиоtextBox4.Text, textBox1.Text, телефонtextBox5.Text, логинtextBox2.Text, парольtextBox3.Text });


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника сотрудника с кодом " + кодtextBox1.Text + "?";
            string caption = "Удаление сотрудника";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(message, caption, buttons);
            if (rezult == DialogResult.No) { return; }
            string sql = "DELETE FROM sotrudniki WHERE id_sot=" + кодtextBox1.Text;
            Главная.Modification_Execute(sql);
            Главная.cdt.Tables["Сотрудники"].Rows.RemoveAt(n);
            if (Главная.cdt.Tables["Сотрудники"].Rows.Count > n)
                FieldsForm_Fill();
            else
                FieldsForm_Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Главная.tabControl1.Controls.Remove(Главная.tabControl1.SelectedTab);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
