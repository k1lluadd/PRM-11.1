using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shoesDBDataSet.Покупатели". При необходимости она может быть перемещена или удалена.
            this.покупателиTableAdapter.Fill(this.shoesDBDataSet.Покупатели);
            UpdateTotalBooksCount();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                покупателиBindingSource.Sort = "ФИО ASC";
            }
            else if (!radioButton2.Checked)
            {
                покупателиBindingSource.Sort = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите строку для поиска.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string title = row.Cells[1].Value?.ToString();
                if (!string.IsNullOrEmpty(title) &&
                    title.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    dataGridView1.CurrentCell = row.Cells[1];
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }

            MessageBox.Show("Покупатель с таким ФИО не найден.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filterStr = textBox2.Text.Trim();

            if (!string.IsNullOrEmpty(filterStr))
            {
                покупателиBindingSource.Filter = $"ФИО LIKE '{filterStr}%'";
            }
            else
            {
                покупателиBindingSource.Filter = "";
            }
            UpdateTotalBooksCount();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                покупателиBindingSource.Sort = "ФИО DESC";
            }
            else if (!radioButton1.Checked)
            {
                покупателиBindingSource.Sort = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            покупателиBindingSource.Filter = "";
            UpdateTotalBooksCount();
        }

        private void UpdateTotalBooksCount()
        {
            int count = покупателиBindingSource.Count;
            label2.Text = $"{count}";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.покупателиBindingSource.EndEdit();
            this.покупателиTableAdapter.Update(this.shoesDBDataSet.Покупатели);
            this.покупателиTableAdapter.Fill(this.shoesDBDataSet.Покупатели);
            UpdateTotalBooksCount();
        }
    }
}
