using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _11._1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "shoesDBDataSet.Категории". При необходимости она может быть перемещена или удалена.
            this.категорииTableAdapter.Fill(this.shoesDBDataSet.Категории);
            UpdateTotalBooksCount();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                категорииBindingSource.Sort = "НазваниеКатегории ASC";
            }
            else if (!radioButton2.Checked)
            {
                категорииBindingSource.Sort = null;
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

            MessageBox.Show("Категория с таким названием не найдена.", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filterStr = textBox2.Text.Trim();

            if (!string.IsNullOrEmpty(filterStr))
            {
                категорииBindingSource.Filter = $"НазваниеКатегории LIKE '{filterStr}%'";
            }
            else
            {
                категорииBindingSource.Filter = "";
            }
            UpdateTotalBooksCount();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                категорииBindingSource.Sort = "НазваниеКатегории DESC";
            }
            else if (!radioButton1.Checked)
            {
                категорииBindingSource.Sort = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            категорииBindingSource.Filter = "";
            UpdateTotalBooksCount();
        }

        private void UpdateTotalBooksCount()
        {
            int count = категорииBindingSource.Count;
            label2.Text = $"{count}";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.категорииBindingSource.EndEdit();
            this.категорииTableAdapter.Update(this.shoesDBDataSet.Категории);
            this.категорииTableAdapter.Fill(this.shoesDBDataSet.Категории);
            UpdateTotalBooksCount();
        }
    }
}
