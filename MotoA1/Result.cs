using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotoA1
{
    public partial class Result : Form
    {
        private int socau =0;
        private bool rot = false;
        public List<int> yourquestion = null;
        public List<int> correct = null;
        public Result(int socau=0,bool rot = false, List<int> yourquestion=null,List<int> correct=null)
        {
            this.yourquestion = yourquestion;
            this.correct = correct;
            this.socau = socau;
            this.rot = rot;
            InitializeComponent();
        }

        private void Result_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            try
            {
                if(yourquestion!=null && correct!=null) 
                {
                    for(int i =0; i < correct.Count;i++)
                    {
                        ListViewItem lv1 = new ListViewItem((i+1).ToString());
                        lv1.SubItems.Add(yourquestion[i].ToString());
                        lv1.SubItems.Add(correct[i].ToString());
                        listView1.Items.Add(lv1);
                    }
                }
                string temp = $"Số Câu Đúng : {socau}";
                label2.Text = temp;
                kq.Text = (socau >= 21 && rot == false) ? "Bạn Đã Vượt Qua" : "Bạn Đã Không Vượt Qua";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
