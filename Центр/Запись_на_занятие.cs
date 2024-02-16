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

    public partial class Запись_на_занятие : Form
    {
        
        public Запись_на_занятие()
        {
            InitializeComponent();
        }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Главная.tabControl1.Controls.Remove(Главная.tabControl1.SelectedTab);
            Главная.tabControl1.SelectedIndex = Главная.tabControl1.TabCount - 1; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (подтвержденcheckBox1.Checked == false && выполненcheckBox2.Checked == true)
            {
                MessageBox.Show("Запись № " + номерtextBox1.Text + " не подтвержденa!", "Ошибка");
                return;
            }
            string sql = "UPDATE zapis SET obrabotka = " + выполненcheckBox2.Checked + " WHERE id_z = " + номерtextBox1.Text;
            Главная.Modification_Execute(sql);
        }
        public static string n = null;
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            string sql = "SELECT zapis.id_z AS \"Номер записи\", zapis.data AS \"Дата записи\","
                + " uchashiesa.fio AS \"Учащийся\", uchashiesa.adres_projivania " +
                "AS \"Адрес проживания\", " + " kursi.name AS \"Курс\"," + " sotrudniki.fio AS" +
                " \"ФИО сотрудника\"," + " stoimost.cena AS \"Стоимость курса\"," + " podtver AS " +
                "\"Подтверждение\", obrabotka AS \"Обработка\"" + " FROM ((zapis INNER JOIN uchashiesa ON " +
                "uchashiesa.id_uch = zapis.id_uch)" + "LEFT JOIN kursi ON kursi.id_k = zapis.id_k " +
                "LEFT JOIN stoimost ON stoimost.id_st = kursi.id_st" + " LEFT JOIN sotrudniki ON " +
                "sotrudniki.id_sot = zapis.id_sot)" + "where zapis.id_k = kursi.id_k  and " +
                "uchashiesa.id_uch = zapis.id_uch and sotrudniki.id_sot = zapis.id_sot GROUP BY " +
                "zapis.id_z, data, uchashiesa.fio, uchashiesa.adres_projivania, name, sotrudniki.fio," +
                " stoimost.cena, podtver, obrabotka" + " ORDER BY \"Номер записи\"";
            Главная.Table_Fill("Журнал учаших", sql);

            int i = 0;
            while (Главная.cdt.Tables["Журнал учащихся"].Rows[i]["Номер записи"].ToString() != n) 
                i++;
            номерtextBox1.Text = Главная.cdt.Tables["Журнал учаших"].Rows[i]["Номер записи"].ToString();
            датаdateTimePicker1.Value = Convert.ToDateTime(Главная.cdt.Tables["Журнал учаших"].Rows[i]["Дата записи"]);
            подтвержденcheckBox1.Checked = Convert.ToBoolean(Главная.cdt.Tables["Журнал учаших"].Rows[i]["Подтверждение"]);
            выполненcheckBox2.Checked = Convert.ToBoolean(Главная.cdt.Tables["Журнал учаших"].Rows[i]["Обработка"]);
            фиоtextBox2.Text = Главная.cdt.Tables["Журнал учаших"].Rows[i]["Учащийся"].ToString();
            адресtextBox3.Text = Главная.cdt.Tables["Журнал учаших"].Rows[i]["Адрес проживания"].ToString();

            Главная.cdt.Tables["Журнал учаших"].DefaultView.RowFilter = "[Номер записи]=" + n;
            

            dataGridView1.DataSource = Главная.cdt.Tables["Журнал учаших"].DefaultView;
            dataGridView1.Columns["Номер записи"].Visible = false;
            dataGridView1.Columns["Дата записи"].Visible = false;
            dataGridView1.Columns["Учащийся"].Visible = false;
            dataGridView1.Columns["Адрес проживания"].Visible = false;
            dataGridView1.Columns["Стоимость курса"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["Подтверждение"].Visible = false;
            dataGridView1.Columns["Обработка"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;

            this.AcceptButton = закрытьbutton2;
        }
    }
}
