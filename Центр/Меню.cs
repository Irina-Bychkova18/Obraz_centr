using System;
using System.Windows.Forms;

namespace Центр
{
    public partial class Меню : Form
    {
        public Меню()
        {
            InitializeComponent();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            while (Главная.tabControl1.TabCount > 0)
                Главная.tabControl1.TabPages.RemoveAt(Главная.tabControl1.TabCount - 1);
            Виды_кружков виды_кружков = new Виды_кружков();
            Главная.tabControl1.Controls.Add(виды_кружков.tabControl1.TabPages[0]);
        }

        private void кружкиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Кружки кружки = new Кружки();
            Главная.tabControl1.Controls.Add(кружки.tabControl1.TabPages[0]);
            Главная.tabControl1.SelectedIndex = Главная.tabControl1.TabCount - 1;
        }

        private void учащиесяToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Учащиеся учащиеся = new Учащиеся();
            Главная.tabControl1.Controls.Add(учащиеся.tabControl1.TabPages[0]);
            Главная.tabControl1.SelectedIndex = Главная.tabControl1.TabCount - 1;
        }

        private void занятияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Сотрудники сотрудники = new Сотрудники();
            Главная.tabControl1.Controls.Add(сотрудники.tabControl1.TabPages[0]);
            Главная.tabControl1.SelectedIndex = Главная.tabControl1.TabCount - 1;
        }

        private void журналУчащихсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Журнал_учащихся журнал_Учащихся = new Журнал_учащихся();
            Главная.tabControl1.Controls.Add(журнал_Учащихся.tabControl1.TabPages[0]);
            Главная.tabControl1.SelectedIndex = Главная.tabControl1.TabCount - 1;
        }
    }
}
