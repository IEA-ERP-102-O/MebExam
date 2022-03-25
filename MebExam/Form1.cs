using MebExam.Source.Context;
using MebExam.Source.Models;
using MebExam.Source.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MebExam
{

    public partial class Form1 : Form
    {
        private readonly CategoryRepository _categoryRepo;
        private readonly ProductRepository _productRepo;
        private string selectedProduct = "";
        public Form1()
        {
            InitializeComponent();
            _categoryRepo = new CategoryRepository();
            _productRepo = new ProductRepository();
            //new AppDbContext().Database.Create();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_Category.DisplayMember = "Name";
            cmb_Category.ValueMember = "Id";
            cmb_Category.Items.AddRange(_categoryRepo.GetQueryable().ToList().Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
            }).ToArray());
            cmb_Category.DataSource = _categoryRepo.GetQueryable().ToList();
            GetTable();

        }

        private void GetTable()
        {
            var products = _productRepo.GetQueryable().Include(x => x.Category).Select(x => new
            {
                Id = x.Id,
                UrunAdi = x.Name,
                Fiyat = x.Price,
                FirmaAdi = x.ProducingCompany,
                Kategori = x.Category.Name,
                KategoriId = x.CategoryId
            }).ToArray();
            dataGridView1.DataSource = products;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_Price.Text == "")
            {
                MessageBox.Show("Fiyat girin.");
            }
            else
            {
                var product = new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = txt_ProductName.Text,
                    Price = Convert.ToDecimal(txt_Price.Text),
                    ProducingCompany = txt_Company.Text,
                    CategoryId = cmb_Category.SelectedValue.ToString()

                };
                _productRepo.Add(product);
                GetTable();
                clearForm();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProduct = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            txt_ProductName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_Price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_Company.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            //dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //dataGridView1.CurrentRow.Cells[5].Value.ToString();



            cmb_Category.SelectedValue = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        private void clearForm()
        {
            txt_Company.Text = "";
            txt_Price.Text = "";
            txt_ProductName.Text = "";
            cmb_Category.SelectedIndex = 0;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            var product = _productRepo.Find(selectedProduct);
            if (product == null)
                MessageBox.Show("Ürün bulunamadı");

            product.Name = txt_ProductName.Text;
            product.Price = Convert.ToDecimal(txt_Price.Text);
            product.ProducingCompany = txt_Company.Text;
            product.CategoryId = cmb_Category.SelectedValue.ToString();
            _productRepo.Update(product);
            clearForm();
            GetTable();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            _productRepo.Delete(selectedProduct);
            MessageBox.Show("Silindi");
            clearForm();
            GetTable();
        }
    }
}
