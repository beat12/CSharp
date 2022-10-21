using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coke_mainPage.Forms
{

    public partial class UserControl3 : UserControl
    {
        OracleConnection conn;
        bool btn_water = false;
        bool btn_mix = false;
        bool btn_calbon = false;
        bool btn_charge = false;
        bool btn_check = false;

        public UserControl3()
        {
            InitializeComponent();

            // 시작시 이미지 숨김
            pictureBox1.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;

            gaugebar1.Visible = false;
            gaugebar2.Visible = false;
            gaugebar3.Visible = false;
            gaugebar4.Visible = false;
            gaugebar5.Visible = false;
            gaugebar6.Visible = false;
            gaugebar7.Visible = false;
            gaugebar8.Visible = false;
            gaugebar9.Visible = false;
            gaugebar10.Visible = false;
            gaugebar11.Visible = false;

            gaugebar12.Visible = false;
            gaugebar13.Visible = false;
            gaugebar14.Visible = false;
            gaugebar15.Visible = false;
            gaugebar16.Visible = false;
            gaugebar17.Visible = false;
            gaugebar18.Visible = false;
            gaugebar19.Visible = false;
            gaugebar20.Visible = false;
            gaugebar21.Visible = false;
            gaugebar22.Visible = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        ////// 버튼, 이미지 ///////
        public void button_on_off_0()
        {
            for (int i = 0; i < 5; i++)
            {
                r_button1.Load(@"C:\Temp\pg\버튼1 on.png");
                Delay(500);
                r_button1.Load(@"C:\Temp\pg\버튼1 off.png");
                Delay(500);
            }
            r_button1.Load(@"C:\Temp\pg\버튼1 on.png");
        }
        public void button_on_off_1()
        {
            pictureBox1.Load(@"C:\Temp\pg\물탱크.gif");
            pictureBox1.Visible = true;

            gaugebar1.Visible = true;
            Delay(180);
            gaugebar2.Visible = true;
            Delay(180);
            gaugebar3.Visible = true;
            Delay(180);
            gaugebar4.Visible = true;
            Delay(180);
            gaugebar5.Visible = true;
            Delay(180);
            gaugebar6.Visible = true;
            Delay(180);
            gaugebar7.Visible = true;
            Delay(180);
            gaugebar8.Visible = true;
            Delay(180);
            gaugebar9.Visible = true;
            Delay(180);
            gaugebar10.Visible = true;
            Delay(180);
            gaugebar11.Visible = true;

            for (int i = 0; i < 5; i++)
            {
                r_button2.Load(@"C:\Temp\pg\버튼1 on.png");
                Delay(500);
                r_button2.Load(@"C:\Temp\pg\버튼1 off.png");
                Delay(500);
            }
            r_button2.Load(@"C:\Temp\pg\버튼1 on.png");
        }
        public void button_on_off_2()
        {
            pictureBox6.Load(@"C:\Temp\pg\게이지.gif");
            pictureBox6.Visible = true;
            pictureBox7.Load(@"C:\Temp\pg\게이지.gif");
            pictureBox7.Visible = true;
            pictureBox8.Load(@"C:\Temp\pg\게이지.gif");
            pictureBox8.Visible = true;
            pictureBox20.Load(@"C:\Temp\pg\오른쪽.gif");
            pictureBox20.Visible = true;

            gaugebar12.Visible = true;
            Delay(180);
            gaugebar13.Visible = true;
            Delay(180);
            gaugebar14.Visible = true;
            Delay(180);
            gaugebar15.Visible = true;
            Delay(180);
            gaugebar16.Visible = true;
            Delay(180);
            gaugebar17.Visible = true;
            Delay(180);
            gaugebar18.Visible = true;
            Delay(180);
            gaugebar19.Visible = true;
            Delay(180);
            gaugebar20.Visible = true;
            Delay(180);
            gaugebar21.Visible = true;
            Delay(180);
            gaugebar22.Visible = true;



            for (int i = 0; i < 5; i++)
            {
                r_button3.Load(@"C:\Temp\pg\버튼1 on.png");
                Delay(500);
                r_button3.Load(@"C:\Temp\pg\버튼1 off.png");
                Delay(500);
            }
            r_button3.Load(@"C:\Temp\pg\버튼1 on.png");

        }
        public void button_on_off_3()
        {
            pictureBox5.Load(@"C:\Temp\pg\버블.gif");
            pictureBox5.Visible = true;



            pictureBox21.Load(@"C:\Temp\pg\오른쪽.gif");
            pictureBox21.Visible = true;

            for (int i = 0; i < 5; i++)
            {
                r_button4.Load(@"C:\Temp\pg\버튼1 on.png");
                Delay(500);
                r_button4.Load(@"C:\Temp\pg\버튼1 off.png");
                Delay(500);
            }
            r_button4.Load(@"C:\Temp\pg\버튼1 on.png");
        }
        public void button_on_off_4()
        {
            pictureBox9.Load(@"C:\Temp\pg\충전.gif");
            pictureBox9.Visible = true;
            pictureBox22.Load(@"C:\Temp\pg\아래.gif");
            pictureBox22.Visible = true;

            for (int i = 0; i < 5; i++)
            {
                r_button5.Load(@"C:\Temp\pg\버튼1 on.png");
                Delay(500);
                r_button5.Load(@"C:\Temp\pg\버튼1 off.png");
                Delay(500);
            }
            r_button5.Load(@"C:\Temp\pg\버튼1 on.png");
        }
        public void button_on_off_5()
        {
            pictureBox10.Load(@"C:\Temp\pg\검수.gif");
            pictureBox10.Visible = true;
            pictureBox23.Load(@"C:\Temp\pg\왼쪽.gif");
            pictureBox23.Visible = true;

            for (int i = 0; i < 5; i++)
            {
                r_button6.Load(@"C:\Temp\pg\버튼1 on.png");
                Delay(500);
                r_button6.Load(@"C:\Temp\pg\버튼1 off.png");
                Delay(500);
            }
            r_button6.Load(@"C:\Temp\pg\버튼1 on.png");
        }
        public void button_on_off_6()
        {
            pictureBox24.Load(@"C:\Temp\pg\왼쪽.gif");
            pictureBox24.Visible = true;
            for (int i = 0; i < 5; i++)
            {

                r_button7.Load(@"C:\Temp\pg\버튼1 on.png");
                Delay(500);
                r_button7.Load(@"C:\Temp\pg\버튼1 off.png");
                Delay(500);

            }
            r_button7.Load(@"C:\Temp\pg\버튼1 on.png");
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void stop()
        {
            pictureBox1.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;

            gaugebar1.Visible = false;
            gaugebar2.Visible = false;
            gaugebar3.Visible = false;
            gaugebar4.Visible = false;
            gaugebar5.Visible = false;
            gaugebar6.Visible = false;
            gaugebar7.Visible = false;
            gaugebar8.Visible = false;
            gaugebar9.Visible = false;
            gaugebar10.Visible = false;
            gaugebar11.Visible = false;
            gaugebar12.Visible = false;
            gaugebar13.Visible = false;
            gaugebar14.Visible = false;
            gaugebar15.Visible = false;
            gaugebar16.Visible = false;
            gaugebar17.Visible = false;
            gaugebar18.Visible = false;
            gaugebar19.Visible = false;
            gaugebar20.Visible = false;
            gaugebar21.Visible = false;
            gaugebar22.Visible = false;
            r_button1.Load(@"C:\Temp\pg\버튼1 off.png");
            r_button2.Load(@"C:\Temp\pg\버튼1 off.png");
            r_button3.Load(@"C:\Temp\pg\버튼1 off.png");
            r_button4.Load(@"C:\Temp\pg\버튼1 off.png");
            r_button5.Load(@"C:\Temp\pg\버튼1 off.png");
            r_button6.Load(@"C:\Temp\pg\버튼1 off.png");
            r_button7.Load(@"C:\Temp\pg\버튼1 off.png");
        }
        // 공장 가동
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            conn = db.dbConnect();
            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;


            int leftover = 0;
            cmd.CommandText = "SELECT MATERIAL_NUMBER FROM INVENTORY WHERE MATERIAL_ID = 'SYRUP'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            leftover = rdr.GetInt32(0);

            try
            {
                if (textBox1.Text == "" || guna2ComboBox1.SelectedIndex == -1 || textBox1.Text == "0")
                {
                    MessageBox.Show("수량과 제품선택을 확인해주세요.");
                }
                else
                {
                    int n = Int32.Parse(textBox1.Text);
                    if (guna2ComboBox1.SelectedIndex == 0)
                    {

                        if (leftover >= n * 2)
                        {
                            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER-{n * 2} WHERE NOT MATERIAL_NAME IN ('1000ML', '500ML')";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER-{n} WHERE MATERIAL_NAME = '1000ML'";
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("1L 생산이 시작됩니다.", "생산 시작");
                            button_on_off_0();
                            Delay(250);
                            button_on_off_1();
                            Delay(250);
                            button_on_off_2();
                            Delay(250);
                            button_on_off_3();
                            Delay(250);
                            button_on_off_4();
                            Delay(250);
                            button_on_off_5();
                            Delay(250);
                            button_on_off_6();

                            stop();
                            cmd.CommandText = $"UPDATE LEFT_LIST SET LEFTOVER_NUMBER=LEFTOVER_NUMBER+{n} WHERE SIZE_NAME = '1L'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("제품생산이 완료되었습니다", "1L");
                        }
                        else
                        {
                            MessageBox.Show("재료가 부족합니다.", "재료 부족");
                        }
                    }
                    else
                    {
                        if (leftover >= n)
                        {
                            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER-{n} WHERE NOT MATERIAL_NAME IN ('500ML', '1000ML')";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER-{n} WHERE MATERIAL_NAME = '500ML'";
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("500ML 생산이 시작됩니다.", "생산 시작");
                            button_on_off_0();
                            Delay(250);
                            button_on_off_1();
                            Delay(250);
                            button_on_off_2();
                            Delay(250);
                            button_on_off_3();
                            Delay(250);
                            button_on_off_4();
                            Delay(250);
                            button_on_off_5();
                            Delay(250);
                            button_on_off_6();

                            stop();

                            cmd.CommandText = $"UPDATE LEFT_LIST SET LEFTOVER_NUMBER=LEFTOVER_NUMBER+{n} WHERE SIZE_NAME = '500ML'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("제품생산이 완료되었습니다.", "500ml");
                        }
                        else
                        {
                            MessageBox.Show("재료가 부족합니다.", "재료 부족");
                        }
                    }
                    textBox1.Text = "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("수량과 제품선택을 확인해주세요.(x)");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 수동 제어

        // 물탱크 
        private void button1_Click(object sender, EventArgs e)
        {

            if (btn_water == false)
            {
                btn_water = true;
                button_on_off_0();
                button_on_off_1();

            }
            else
            {
                stop();
                btn_water = false;
            }
        }
        // 혼합
        private void button2_Click(object sender, EventArgs e)
        {

            if (btn_mix == false)
            {
                btn_mix = true;
                button_on_off_2();

            }
            else
            {
                stop();
                btn_mix = false;
            }
        }
        // 탄산
        private void button3_Click(object sender, EventArgs e)
        {
            if (btn_calbon == false)
            {
                btn_calbon = true;
                button_on_off_3();

            }
            else
            {
                stop();
                btn_calbon = false;
            }

        }
        // 충전
        private void button4_Click(object sender, EventArgs e)
        {
            if (btn_charge == false)
            {
                btn_charge = true;
                button_on_off_4();

            }
            else
            {
                stop();
                btn_charge = false;
            }

        }
        // 검수
        private void button5_Click(object sender, EventArgs e)
        {
            if (btn_check == false)
            {
                btn_check = true;
                button_on_off_5();

            }
            else
            {
                stop();
                btn_check = false;
            }

        }
        // 생산
  
        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        // form 닫기 
        private void button10_Click(object sender, EventArgs e)
        {

        }

        // Delay 합수
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }

        // 안쓰는거. 디자인이랑 다 바꿔야해서 밑에 따로 정리.

    }
}