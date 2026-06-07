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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shoesDBDataSet.Продажи". При необходимости она может быть перемещена или удалена.
            this.продажиTableAdapter.Fill(this.shoesDBDataSet.Продажи);
            UpdateTotalBooksCount();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                продажиBindingSource.Sort = "ДатаПродажи ASC";
            }
            else if (!radioButton2.Checked)
            {
                продажиBindingSource.Sort = null;
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

            MessageBox.Show("Продажа с такой датой не найден.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filterStr = textBox2.Text.Trim();

            if (!string.IsNullOrEmpty(filterStr))
            {
                продажиBindingSource.Filter = $"ДатаПродажи LIKE '{filterStr}%'";
            }
            else
            {
                продажиBindingSource.Filter = "";
            }
            UpdateTotalBooksCount();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                продажиBindingSource.Sort = "ДатаПродажи DESC";
            }
            else if (!radioButton1.Checked)
            {
                продажиBindingSource.Sort = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            продажиBindingSource.Filter = "";
            UpdateTotalBooksCount();
        }

        private void UpdateTotalBooksCount()
        {
            int count = продажиBindingSource.Count;
            label2.Text = $"{count}";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.продажиBindingSource.EndEdit();
            this.продажиTableAdapter.Update(this.shoesDBDataSet.Продажи);
            this.продажиTableAdapter.Fill(this.shoesDBDataSet.Продажи);
            UpdateTotalBooksCount();
        }

    }
}
