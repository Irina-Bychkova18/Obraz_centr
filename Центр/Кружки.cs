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
    public partial class Кружки : Form
    {
        public Кружки()
        {
            InitializeComponent();
        }

        public static int n = 0;
        private void FieldsForm_Fill()
        {
            
            кодtextBox1.Text = Главная.cdt.Tables["Курсы"].Rows[n]["Код"].ToString();
            названиеtextBox2.Text = Главная.cdt.Tables["Курсы"].Rows[n]["name"].ToString();
            comboBox1.Text = Главная.cdt.Tables["Курсы"].Rows[n]["Время работы"].ToString();
            textBox1.Text = Главная.cdt.Tables["Курсы"].Rows[n]["Длительность курса"].ToString();
            comboBox2.Text = Главная.cdt.Tables["Курсы"].Rows[n]["Сотрудник"].ToString();
            кружкиcomboBox1.Text = Главная.cdt.Tables["Курсы"].Rows[n]["Стоимость курса"].ToString();

            кодtextBox1.Enabled = false;
        }
        private void FieldsForm_Clear()
        {
            кодtextBox1.Text = "0";
            названиеtextBox2.Text = "";
            comboBox1.Text = "";
            textBox1.Text = "";
            comboBox2.Text = "";
            кружкиcomboBox1.Text = "";
            кодtextBox1.Enabled = true; кодtextBox1.Focus();
        }
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            Главная.Table_Fill("Курсы", "SELECT kursi.id_k AS \"Код\", kursi.name AS \"name\"," +
                " vrema.name AS \"Время работы\", kursi.dlitel AS \"Длительность курса\", " +
                "sotrudniki.fio AS \"Сотрудник\", stoimost.cena AS \"Стоимость курса\" FROM kursi," +
                " vrema, stoimost, sotrudniki where kursi.id_vr = vrema.id_vr and " +
                "kursi.id_st = stoimost.id_st and kursi.id_sot = sotrudniki.id_sot ORDER BY \"Код\"");
            
            comboBox1.DataSource = Главная.cdt.Tables["Время"].DefaultView;
            comboBox1.DisplayMember = "name";
            comboBox2.DataSource = Главная.cdt.Tables["Сотрудники"].DefaultView;
            comboBox2.DisplayMember = "ФИО";
            кружкиcomboBox1.DataSource = Главная.cdt.Tables["Стоимость"].DefaultView;
            кружкиcomboBox1.DisplayMember = "cena";
            if (Главная.cdt.Tables["Курсы"].Rows.Count > n)
                FieldsForm_Fill();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (n < Главная.cdt.Tables["Курсы"].Rows.Count) n++;
            if (Главная.cdt.Tables["Курсы"].Rows.Count > n)
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
            n = Главная.cdt.Tables["Курсы"].Rows.Count;
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
            if (Главная.cdt.Tables["Курсы"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string kod = Главная.cdt.Tables["Стоимость"].DefaultView[кружкиcomboBox1.SelectedIndex]["id_st"].ToString();
            string koda = Главная.cdt.Tables["Время"].DefaultView[comboBox1.SelectedIndex]["id_vr"].ToString();
            string kodi = Главная.cdt.Tables["Сотрудники"].DefaultView[comboBox2.SelectedIndex]["Код"].ToString();
            string sql;
            if (n < Главная.cdt.Tables["Курсы"].Rows.Count)
            {
                sql = "UPDATE kursi SET name='" + названиеtextBox2.Text + "', id_vr=" + koda + ", dlitel='"
                    + textBox1.Text + "', id_sot=" + kodi + ", id_st=" + kod + " WHERE id_k=" + кодtextBox1.Text;
                if (!Главная.Modification_Execute(sql))
                    return;
                Главная.cdt.Tables["Курсы"].Rows[n].ItemArray = new object[] { кодtextBox1.Text, названиеtextBox2.Text, 
                    comboBox1.Text, textBox1.Text , comboBox2.Text, кружкиcomboBox1.Text };
            }
            else
            {
                sql = "INSERT INTO kursi (id_k, name, id_vr, dlitel, id_sot, id_st) VALUES (" + кодtextBox1.Text + ",'"
                    + названиеtextBox2.Text + "'," + koda + ",'" + textBox1.Text + "'," + kodi + "," + kod + ")";
                if (!Главная.Modification_Execute(sql))
                    return;
                кодtextBox1.Enabled = false;
                Главная.cdt.Tables["Курсы"].Rows.Add(new object[] { кодtextBox1.Text, названиеtextBox2.Text, 
                    comboBox1.Text, textBox1.Text , comboBox2.Text, кружкиcomboBox1.Text });
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить из справочника курс с кодом " + кодtextBox1.Text + "?";
            string caption = "Удаление курса";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(message, caption, buttons);
            if (rezult == DialogResult.No) { return; }
            string sql = "DELETE FROM kursi WHERE id_k = " + кодtextBox1.Text;
            Главная.Modification_Execute(sql);
            Главная.cdt.Tables["Курсы"].Rows.RemoveAt(n);
            if (Главная.cdt.Tables["Курсы"].Rows.Count > n)
                FieldsForm_Fill();
            else
               FieldsForm_Clear();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Главная.tabControl1.Controls.Remove(Главная.tabControl1.SelectedTab);
        }

       
    }
}
