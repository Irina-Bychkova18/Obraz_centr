using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;




namespace Центр
{
    public partial class Журнал_учащихся : Form
    {
        public Журнал_учащихся()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Главная.tabControl1.Controls.Remove(Главная.tabControl1.SelectedTab);
        }

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
            Главная.Table_Fill("Журнал учащихся", sql);

            dataGridView1.DataSource = Главная.cdt.Tables["Журнал учащихся"];
            dataGridView1.Columns["Адрес проживания"].Visible = false;
            dataGridView1.Columns["Стоимость курса"].DefaultCellStyle.Format = "C2";
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;


        }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Excel.Application Excel_ = new Excel.Application();
            Excel_.Visible = true;
            Excel.Workbook Workbook_ = Excel_.Workbooks.Add();
            Excel.Worksheet Sheet_ = (Excel.Worksheet)Workbook_.Sheets[1];

            Sheet_.Cells[1, 1].Value = "Журнал учащихся";
            Sheet_.Range[Sheet_.Cells[1, 1], Sheet_.Cells[1, 8]].Merge();
            Sheet_.Cells[1, 1].HorizontalAlignment = 3;

            Sheet_.Cells[2, 1].Value = dataGridView1.Columns["Номер записи"].HeaderText;
            Sheet_.Cells[2, 2].Value = dataGridView1.Columns["Дата записи"].HeaderText;
            Sheet_.Cells[2, 3].Value = dataGridView1.Columns["Учащийся"].HeaderText;
            Sheet_.Cells[2, 4].Value = dataGridView1.Columns["Курс"].HeaderText;
            Sheet_.Cells[2, 5].Value = dataGridView1.Columns["ФИО сотрудника"].HeaderText;
            Sheet_.Cells[2, 6].Value = dataGridView1.Columns["Стоимость курса"].HeaderText;
            Sheet_.Cells[2, 7].Value = dataGridView1.Columns["Подтверждение"].HeaderText;
            Sheet_.Cells[2, 8].Value = dataGridView1.Columns["Обработка"].HeaderText;

            Sheet_.Range[Sheet_.Cells[2, 1], Sheet_.Cells[2, 7]].HorizontalAlignment = 3;

            int n = 3;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Sheet_.Cells[n, 1].Value = dataGridView1.Rows[i].Cells["Номер записи"].Value;
                Sheet_.Cells[n, 2].Value = dataGridView1.Rows[i].Cells["Дата записи"].Value;
                Sheet_.Cells[n, 3].Value = dataGridView1.Rows[i].Cells["Учащийся"].Value;
                Sheet_.Cells[n, 4].Value = dataGridView1.Rows[i].Cells["Курс"].Value;
                Sheet_.Cells[n, 5].Value = dataGridView1.Rows[i].Cells["ФИО сотрудника"].Value;
                Sheet_.Cells[n, 6].Value = dataGridView1.Rows[i].Cells["Стоимость курса"].Value;
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Подтверждение"].Value) == true)
                    Sheet_.Cells[n, 7].Value = "Да";
                else
                    Sheet_.Cells[n, 7].Value = "Нет";
                Sheet_.Cells[n, 3].Value = dataGridView1.Rows[i].Cells["Учащийся"].Value;
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Обработка"].Value) == true)
                    Sheet_.Cells[n, 8].Value = "Да";
                else
                    Sheet_.Cells[n, 8].Value = "Нет";
                n++;
            }
            Sheet_.Range[Sheet_.Cells[3, 4], Sheet_.Cells[3 + dataGridView1.RowCount, 7]].HorizontalAlignment = 3;
            Sheet_.Range[Sheet_.Cells[3, 8], Sheet_.Cells[3 + dataGridView1.RowCount, 8]].HorizontalAlignment = 4;
            Sheet_.Range[Sheet_.Cells[2, 1], Sheet_.Cells[2 + dataGridView1.RowCount, 8]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous ;
            Sheet_.Cells.Columns.EntireColumn.AutoFit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kod;
            try
            {
                kod = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Номер записи"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не указан удаляемый экземпляр!!!", "Ошибка"); return;
            }
            string message = "Вы точно хотите удалить запись № " + kod + "?";
            string caption = "Удаление записи";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(message, caption, buttons);
            if (rezult == DialogResult.No) { return; }
            string sql = "DELETE FROM zapis WHERE id_z = " + kod;
            Главная.Modification_Execute(sql);
            for (int i = Главная.cdt.Tables["Журнал учащихся"].Rows.Count -1; i >= 0; i--)
                if (Главная.cdt.Tables["Журнал учащихся"].Rows[i]["Номер записи"].ToString() == kod)
                {
                    Главная.cdt.Tables["Журнал учащихся"].Rows.RemoveAt(i);
                    dataGridView1.CurrentCell = null;
                    return;
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить информацию обо всех записях?";
            string caption = "Очистка журнала";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(message, caption, buttons);
            if (rezult == DialogResult.No) { return; }
            string sql = "DELETE FROM zapis";
            Главная.Modification_Execute(sql);
            Главная.cdt.Tables["Журнал учащихся"].Clear();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Запись_на_занятие.n = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Номер записи"].Value.ToString();
            Запись_на_занятие запись = new Запись_на_занятие();
            if (Главная.tabControl1.TabCount > 2)
                Главная.tabControl1.TabPages.RemoveAt(Главная.tabControl1.TabCount - 1);
            Главная.tabControl1.Controls.Add(запись.tabControl1.TabPages[0]);
            Главная.tabControl1.SelectedIndex = Главная.tabControl1.TabCount - 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
