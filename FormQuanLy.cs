using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoAnTest
{
    public partial class FormQuanLy : Form
    {        
        public FormQuanLy()
        {
            InitializeComponent();
        }    
        void AddLH()
        {
            ListViewItem item = new ListViewItem(textBox_MaLH.Text);
            item.SubItems.Add(textBox_TenLH.Text);
            listView_LH.Items.Add(item);
        }
        void AddMH()
        {
            ListViewItem item = new ListViewItem(textBox_MaMH.Text);
            item.SubItems.Add(textBox_TenMH.Text);
            item.SubItems.Add(textBox_Nam.Text);
            item.SubItems.Add(textBox_CongTy.Text);
            item.SubItems.Add(dateTimePicker_MH.Text);
            item.SubItems.Add(comboBox_LH.Text);
            listView_MH.Items.Add(item);
        }
        void HienThiCombobox()
        {            
            comboBox_LH.Items.Clear();
            for (int i =0; i<listView_LH.Items.Count;i++)
            {
                comboBox_LH.Items.Add(listView_LH.Items[i].Text);
            }           
        }
        void RefreshLH()
        {
            textBox_MaLH.Clear();
            textBox_TenLH.Clear();
            textBox_MaLH.Focus();
        }
        void RefreshMH()
        {
            textBox_MaMH.Clear();
            textBox_TenMH.Clear();            
            textBox_CongTy.Clear();
            textBox_Nam.Clear();
            textBox_MaMH.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label_MHLH_Click(object sender, EventArgs e)
        {

        } 
        private void button_Exit_Click(object sender, EventArgs e)
        {
            RefreshLH();          
        }

        private void button_ExitMH_Click(object sender, EventArgs e)
        {
            RefreshMH();
        }

        private void button_AddMH_Click(object sender, EventArgs e)
        {
                if (string.IsNullOrEmpty(textBox_MaMH.Text) ||
                    string.IsNullOrEmpty(textBox_TenMH.Text) ||
                    string.IsNullOrEmpty(textBox_Nam.Text) ||
                    string.IsNullOrEmpty(textBox_CongTy.Text) ||
                    string.IsNullOrEmpty(comboBox_LH.Text) ||
                    string.IsNullOrEmpty(dateTimePicker_MH.Text))
                {
                    MessageBox.Show("Lỗi !!! Nhập thiếu thông tin");
                    return;
                }
            if(listView_MH.Items.Count==0)
            {
                AddMH();                            
            }
            else
            {                
                for(int i=0; i<listView_MH.Items.Count;i++)
                {
                    if (textBox_MaMH.Text == listView_MH.Items[i].Text)
                    {
                        MessageBox.Show("Lỗi !!! Mã Mặt hàng đã tồn tại");
                        return;
                    }
                }
                AddMH();
            }            
            RefreshMH();            
        }
        private void listView_LH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_LH.SelectedItems.Count > 0)
            {
                ListViewItem item = listView_LH.SelectedItems[0];
                textBox_MaLH.Text = item.SubItems[0].Text;
                textBox_TenLH.Text = item.SubItems[1].Text;
            }
        }
        private void listView_MH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView_MH.SelectedItems.Count>0)
            {
                ListViewItem item = listView_MH.SelectedItems[0];
                textBox_MaMH.Text = item.SubItems[0].Text;
                textBox_TenMH.Text = item.SubItems[1].Text;
                textBox_Nam.Text = item.SubItems[2].Text;
                textBox_CongTy.Text = item.SubItems[3].Text;
                dateTimePicker_MH.Value = Convert.ToDateTime(item.SubItems[4].Text);
                comboBox_LH.Text = item.SubItems[5].Text;
            }
        }

        private void button_SearchLH_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_LH.Items.Count; i++)
            {
                if (textBox_SearchLH.Text.ToLower() == listView_LH.Items[i].Text.ToLower() ||
                    textBox_SearchLH.Text.ToLower() == listView_LH.Items[i].SubItems[1].Text.ToLower())
                {
                    textBox_MaLH.Text = listView_LH.Items[i].Text;
                    textBox_TenLH.Text = listView_LH.Items[i].SubItems[1].Text;
                    textBox_SearchLH.Clear();
                    MessageBox.Show("Kết quả tìm kiếm True !!!");
                    return;
                }                
            }
            MessageBox.Show("False !!! Không tìm thấy ");
            textBox_SearchLH.Clear();
            return;
        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_MaLH.Text) ||
                string.IsNullOrEmpty(textBox_TenLH.Text))
            {
                MessageBox.Show("Lỗi !!! Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (listView_LH.Items.Count == 0)
            {
                AddLH();
            }
            else
            {
                for (int i = 0; i < listView_LH.Items.Count; i++)
                {
                    if (textBox_MaLH.Text == listView_LH.Items[i].Text)
                    {                        
                        MessageBox.Show("False !!! Mã Loại hàng này đã tồn tại");                        
                        return;
                    }
                }
                AddLH();
            }
            HienThiCombobox();
            RefreshLH();
        }
        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_MaLH.Text) ||
                            string.IsNullOrEmpty(textBox_TenLH.Text))
            {
                MessageBox.Show("Lỗi !!! Vui lòng nhập đầy đủ thông tin");
                return;
            }
            for (int i = 0; i < listView_LH.Items.Count; i++)
            {
                if (listView_LH.Items[i].Selected)                    
                {                    
                    if (textBox_MaLH.Text !=listView_LH.Items[i].Text)
                    {
                        for (int k=0;k<listView_LH.Items.Count;k++)
                        {
                            if (textBox_MaLH.Text == listView_LH.Items[k].Text)
                            {
                                MessageBox.Show("False !!! Mã Loại hàng đã tồn tại");
                                return;
                            }                            
                        }    
                    }    
                    
                    DialogResult EditLH = MessageBox.Show("Bạn muốn sửa", "!!!!!!!!!!", MessageBoxButtons.YesNo);

                    if (EditLH == DialogResult.Yes)
                    {
                        ListViewItem item = listView_LH.SelectedItems[0];
                        item.SubItems[0].Text = textBox_MaLH.Text;
                        item.SubItems[1].Text = textBox_TenLH.Text;
                        MessageBox.Show("Sửa Thành Công");
                    }                    
                }                
            }
            RefreshLH();
            HienThiCombobox();                        
        }
        private void button_EditMH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_MaMH.Text) ||
                string.IsNullOrEmpty(textBox_TenMH.Text) ||
                string.IsNullOrEmpty(textBox_Nam.Text) ||
                string.IsNullOrEmpty(textBox_CongTy.Text) ||
                string.IsNullOrEmpty(comboBox_LH.Text) ||
                string.IsNullOrEmpty(dateTimePicker_MH.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            for (int i = 0; i < listView_MH.Items.Count; i++)
            {
                if (listView_MH.Items[i].Selected)
                {
                    if(textBox_MaMH.Text != listView_MH.Items[i].Text)
                    {
                        for (int k=0; k<listView_MH.Items.Count;k++)
                        {
                            if (textBox_MaMH.Text ==listView_MH.Items[k].Text)
                            {
                                MessageBox.Show("False !!! Mã Mặt hàng đã tồn tại");
                                return;
                            }    
                        }    
                    }
                    DialogResult EditMH = MessageBox.Show("Bạn muốn sửa", "!!!!!!!!!!", MessageBoxButtons.YesNo);

                    if (EditMH == DialogResult.Yes)
                    {
                        ListViewItem item = listView_MH.SelectedItems[0];
                        item.SubItems[0].Text = textBox_MaMH.Text;
                        item.SubItems[1].Text = textBox_TenMH.Text;
                        item.SubItems[2].Text = textBox_Nam.Text;
                        item.SubItems[3].Text = textBox_CongTy.Text;
                        item.SubItems[4].Text = Convert.ToString(dateTimePicker_MH.Value);
                        item.SubItems[5].Text = comboBox_LH.Text;
                        MessageBox.Show("Sửa Thành Công!!!");
                    }                    
                }
            }            
            RefreshMH();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_LH.Items.Count; i++)
            {
                if (listView_LH.Items[i].Selected)
                {
                    DialogResult EditLH = MessageBox.Show("Bạn muốn xóa", "!!!!!!!!!!", MessageBoxButtons.YesNo);
                    if (EditLH == DialogResult.Yes)
                    {
                        listView_LH.Items.RemoveAt(i);                        
                        MessageBox.Show("Xóa Thành Công");
                        RefreshLH();
                    }                    
                }
            } 
            HienThiCombobox();            
        }

        private void button_DeleteMH_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_MH.Items.Count; i++)
            {
                if (listView_MH.Items[i].Selected)
                {
                    DialogResult DeleteMH = MessageBox.Show("Bạn muốn xóa","!!!!!!!!!!", MessageBoxButtons.YesNo);
                    if (DeleteMH == DialogResult.Yes)
                    {
                        listView_MH.Items.RemoveAt(i);
                        MessageBox.Show("Xóa Thành Công");
                        RefreshMH();
                    }
                }
            }            
        }        

        private void button_SearchMH_Click(object sender, EventArgs e)
        {
            for (int i=0; i<listView_MH.Items.Count; i++)
            {
                if(textBox_SearchMH.Text.ToLower() == listView_MH.Items[i].Text.ToLower() ||
                    textBox_SearchMH.Text.ToLower() == listView_MH.Items[i].SubItems[1].Text.ToLower() ||
                    textBox_SearchMH.Text.ToLower() == listView_MH.Items[i].SubItems[3].Text.ToLower() ||
                    textBox_SearchMH.Text.ToLower() == listView_MH.Items[i].SubItems[5].Text.ToLower())
                {                    
                    textBox_MaMH.Text = listView_MH.Items[i].Text;
                    textBox_TenMH.Text = listView_MH.Items[i].SubItems[1].Text;
                    textBox_CongTy.Text = listView_MH.Items[i].SubItems[3].Text;
                    textBox_Nam.Text = listView_MH.Items[i].SubItems[2].Text;
                    dateTimePicker_MH.Value = Convert.ToDateTime( listView_MH.Items[i].SubItems[4].Text);
                    comboBox_LH.Text = listView_MH.Items[i].SubItems[5].Text;                    
                    MessageBox.Show("Kết quả tìm kiếm True !!!");
                    textBox_SearchMH.Clear();
                    return;
                }                
            }
            MessageBox.Show("False !!! Không tìm thấy");
            return;
        }

        private void button_LoaiHang_Click(object sender, EventArgs e)
        {
            panel_LH.BringToFront();
        }

        private void button_MH_Click(object sender, EventArgs e)
        {
            panel_MH.BringToFront();
        }

        private void textBox_Nam_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_Nam_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {      
                e.Handled = true;
            }
        }
    }
}
