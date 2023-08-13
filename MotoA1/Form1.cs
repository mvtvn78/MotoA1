using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using MotoA1;

namespace AppMoTo
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            Init(listallQuestion);
            InitializeComponent();

        }
        private int[] Rs = { 2, 2, 3, 1, 1, 4, 2, 1, 3, 3, 3, 2, 2, 2, 3, 1, 2, 1, 3, 2, 4, 2, 2, 4, 1, 4, 3, 1, 2, 4, 3, 2, 3, 1, 2, 2, 2, 3, 2, 1, 3, 4, 3, 4, 3, 2, 2, 2, 4, 2, 2, 4, 2, 3, 1, 1, 1, 1, 3, 1, 2, 4, 1, 2, 4, 1, 1, 2, 2, 1, 2, 1, 3, 1, 4, 3, 3, 2, 1, 4, 3, 4, 2, 3, 1, 1, 1, 4, 1, 1, 4, 1, 3, 2, 3, 4, 4, 3, 3, 1, 3, 1, 3, 2, 1, 2, 1, 1, 2, 3, 1, 2, 3, 2, 1, 4, 3, 1, 2, 2, 2, 1, 1, 3, 1, 4, 1, 3, 2, 3, 1, 2, 1, 2, 1, 3, 1, 2, 3, 1, 2, 2, 2, 2, 2, 2, 3, 1, 2, 1, 4, 3, 4, 2, 1, 2, 2, 3, 3, 4, 2, 4, 1, 4, 1, 2, 3, 2, 2, 1, 1, 3, 1, 1, 1, 3, 2, 2, 4, 1, 3, 3, 3, 2, 3, 2, 1, 3, 2, 4, 2, 3, 2, 2, 3, 2, 2, 1, 2, 2 };
        public List<int> listmark = new List<int>(25) { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private Button currentButton = null;
        public List<string> listallQuestion = new List<string>();
        public List<string> question25 = new List<string>();
        public List<int> resultquestion25 = new List<int>();
        public bool rot = false;
        public static void Init(List<String> list)
        {
            for (int i = 1; i <= 200; i++)
            {
                string png = ".png";
                string rs = i.ToString() + png;
                list.Add(rs);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                List<Button> buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
                List<RadioButton> rdbtn = new List<RadioButton>() { radioButton1, radioButton2, radioButton3, radioButton4 };
                Button btnClick = sender as Button;

                currentButton = btnClick;
                int idx = buttons.FindIndex(btn => btn == btnClick);
                string x = $"Câu {buttons[idx].Text} :";
                label2.Text = x;
                //  truy xuất lại hoặc reset
                for(int i =0;i<buttons.Count;i++)
                {
                    if(idx==i)
                    {
                        
                        pictureBox1.ImageLocation = (@".\appmoto\" + question25[i]);
                    }    
                }    
                if (listmark[idx] == 0)
                {
                    btnClick.BackColor = Color.White;
                    for (int i = 0; i < rdbtn.Count; i++)
                    {
                        rdbtn[i].Checked = false;
                    }
                }
                else
                {

                    rdbtn[listmark[idx] - 1].Checked = true;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Moto_Load(object sender, EventArgs e)
        {
            try
            {
                Random rd = new Random();
                int[] listliet = { 15, 16, 17, 18, 19, 23, 26, 27, 28, 29, 30, 31, 32, 33, 34, 58, 61, 78, 89, 94 };
                int indexliet = rd.Next(0, listliet.Length);
                
                //Thêm 1 câu điểm liệt vào
                question25.Add(listallQuestion[listliet[indexliet] - 1]);
                resultquestion25.Add(Rs[listliet[indexliet] - 1]);
                // Thêm 7 câu về KN
                int count = 0;
                while (count != 7)
                {
                    int idxKN = rd.Next(1, 83);
                    while (question25.Any(it => it == listallQuestion[idxKN - 1]))
                    {
                        idxKN = rd.Next(1, 83);
                    }
                    question25.Add(listallQuestion[idxKN - 1]);
                    resultquestion25.Add(Rs[idxKN - 1]);
                    count++;
                }

                //Thêm 1 câu van hoa vào
                int indxvh = rd.Next(84, 88);
                question25.Add(listallQuestion[indxvh - 1]);
                resultquestion25.Add(Rs[indxvh - 1]);
                // thêm 1 câu kĩ thuật kéo xe vào
                int idxKT = rd.Next(89, 100);
                question25.Add(listallQuestion[idxKT - 1]);
                resultquestion25.Add(Rs[idxKT - 1]);
                // Thêm 8 câu biển báo vào 
                count = 0;
                while (count != 8)
                {
                    int idxBB = rd.Next(101, 165);
                    while (question25.Any(it => it == listallQuestion[idxBB - 1]))
                    {
                        idxBB = rd.Next(101, 165);
                    }
                    question25.Add(listallQuestion[idxBB - 1]);
                    resultquestion25.Add(Rs[idxBB - 1]);
                    count++;
                }
                // Thêm 7 câu sa hình vào
                count = 0;
                while (count != 7)
                {
                    int idxSH = rd.Next(166, 200);
                    while (question25.Any(it => it == listallQuestion[idxSH - 1]))
                    {
                        idxSH = rd.Next(166, 200);
                    }
                    question25.Add(listallQuestion[idxSH - 1]);
                    resultquestion25.Add(Rs[idxSH - 1]);
                    count++;
                }
                
                List<Button> buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
                for (int i = 0; i < buttons.Count; i++)

                {
                    buttons[i].Text = (i + 1).ToString();
                    buttons[i].Cursor = Cursors.Hand;
                }
                label3.Text = "20:00";
                label4.Text = $"{precent} %";
                button1.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult flag = MessageBox.Show("Bạn có muốn kết thúc bài thi của bạn không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (flag == DialogResult.Yes)
                {
                    int socau = 0;

                    for (int i = 0; i < listmark.Count; i++)
                    {
                        if (listmark[i] == resultquestion25[i])
                        {
                            socau++;
                        }
                    }
                    if (listmark[0] != resultquestion25[0])
                        rot = true;
                    Result kq = new Result(socau,rot,listmark,resultquestion25);
                    this.Hide();
                    if(kq.ShowDialog()== DialogResult.Cancel) 
                    {
                        this.Close();
                    }
                }
            } 
            catch { 
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.facebook.com/sieuphammaitien594");

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Process.Start(@"https://github.com/mvtvn78");
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
        }
        private static int totalSeconds = 20 * 60;
        private static int count = 0;
        private static int precent = 0;
        public void ChangeLabelText(string newtext)
        {
            label3.BeginInvoke((MethodInvoker)delegate
            {
                label3.Text = newtext;
            });

        }
        public void ChangeLabelText4(string newtext)
        {
            label4.BeginInvoke((MethodInvoker)delegate
            {
                label4.Text = newtext;
            });

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                Thread thr = new Thread(new ThreadStart(() =>
                {

                    if (totalSeconds > 0)
                    {
                        count++;
                        if (count == 12)
                        {
                            count = 0;
                            precent++;
                        }
                        totalSeconds--;
                        int minutes = totalSeconds / 60;
                        int remainingSeconds = totalSeconds % 60;
                        //fixx"Cross-thread operation not valid" 
                        ChangeLabelText($"{minutes:00}:{remainingSeconds:00}");
                        ChangeLabelText4($"{precent} %");
                        progressBar1.Value = precent;
                    }
                    else
                    {
                        timer1.Stop();
                        ChangeLabelText("00:00");
                        ChangeLabelText4($"100 %");
                        progressBar1.Value = 100;
                        button26.PerformClick();
                    }

                }
            ));
                thr.IsBackground = true;
                thr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Button> buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
                List<RadioButton> rdbtn = new List<RadioButton>() { radioButton1, radioButton2, radioButton3, radioButton4 };
                RadioButton rd = sender as RadioButton;
                if (currentButton != null)
                {
                    currentButton.BackColor = Color.Green;
                    int idx = buttons.FindIndex(it => it == currentButton);
                    listmark[idx] = int.Parse(rd.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatStyle = FlatStyle.Standard;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.FlatStyle = FlatStyle.Flat;
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            try
            {
                List<Button> buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
                int idx = buttons.FindIndex(it => it == currentButton);
                if (idx <= 0)
                {
                    buttons[24].PerformClick();
                }
                else
                    buttons[idx - 1].PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAfter_Click(object sender, EventArgs e)
        {
            try
            {
                List<Button> buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
                int idx = buttons.FindIndex(it => it == currentButton);
                if (idx >= buttons.Count - 1)
                {
                    buttons[0].PerformClick();
                }
                else
                    buttons[idx + 1].PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
