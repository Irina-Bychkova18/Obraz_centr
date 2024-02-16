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
    public partial class Виды_кружков : Form
    {
        public Виды_кружков()
        {
            InitializeComponent();
        }
        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            string sql = "SELECT kursi.id_k AS \"Код\", kursi.name AS \"Название\", " +
                "vrema.name AS \"Время работы\", stoimost.cena AS \"Стоимость курса\" " +
                "FROM kursi, vrema, stoimost where kursi.id_vr = vrema.id_vr and kursi.id_st = stoimost.id_st ORDER BY \"Код\"";
            Главная.Table_Fill("Курс", sql);
            Главная.cdt.Tables["Курс"].DefaultView.Sort = "Название";

            dataGridView1.DataSource = Главная.cdt.Tables["Курс"].DefaultView;
            dataGridView1.Columns["Код"].Visible = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin")
            {
                if (textBox4.Text == "Admin")
                {
                    Главная.Table_Fill("Учащиеся", "SELECT uchashiesa.id_uch AS \"Код\",uchashiesa.fio AS \"ФИО\"," +
                        " uchashiesa.data_r AS \"Дата рождения\", uchashiesa.adres_projivania AS \"Адрес\", " +
                        "kursi.name as \"name\" ,  uchashiesa.login  AS \"Логин\", uchashiesa.parol  AS \"Пароль\"" +
                        " FROM uchashiesa left join kursi on  uchashiesa.id_k = kursi.id_k ORDER BY \"Код\"");
                    Главная.Table_Fill("Стоимость", "SELECT * FROM stoimost");
                    Главная.Table_Fill("Время", "SELECT * FROM vrema");
                    Главная.Table_Fill("Курсы", "SELECT kursi.id_k AS \"Код\", kursi.name AS \"name\", " +
                        "vrema.name AS \"Время работы\", kursi.dlitel AS \"Длительность курса\", " +
                        "sotrudniki.fio AS \"Сотрудник\", stoimost.cena AS \"Стоимость курса\" FROM kursi, vrema," +
                        " stoimost, sotrudniki where kursi.id_vr = vrema.id_vr and kursi.id_st = stoimost.id_st" +
                        " and kursi.id_sot = sotrudniki.id_sot ORDER BY \"Код\"");
                    Главная.cdt.Tables["Курсы"].DefaultView.Sort = "name";

                    Главная.Table_Fill("Сотрудники", "SELECT sotrudniki.id_sot AS \"Код\",sotrudniki.fio AS \"ФИО\"," +
                        " sotrudniki.vozrast AS \"Возраст\", sotrudniki.telephon AS \"Телефон\", " +
                        "sotrudniki.login  AS \"Логин\", sotrudniki.parol  AS \"Пароль\" FROM sotrudniki ORDER BY \"Код\"");
                    Меню меню = new Меню();
                    Главная.tabControl1.TabPages.RemoveAt(0);
                    Главная.tabControl1.Controls.Add(меню.tabControl1.TabPages[0]);
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox1.UseSystemPasswordChar = false;
            else
                textBox1.UseSystemPasswordChar = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Виды_кружков_Load(object sender, EventArgs e)
        {

        }
    }
}
