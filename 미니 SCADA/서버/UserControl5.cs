using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coke_mainPage.Forms
{
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int syrup, sugar, extract, carbonic, bottle;


            if (syrup_txtbx.Text == "")
                syrup = 0;
            else { syrup = Int32.Parse(syrup_txtbx.Text); }

            if (sugar_txtbx.Text == "")
                sugar = 0;
            else { sugar = Int32.Parse(sugar_txtbx.Text); }

            if (extract_txtbx.Text == "")
                extract = 0;
            else { extract = Int32.Parse(extract_txtbx.Text); }

            if (carbonic_txtbx.Text == "")
                carbonic = 0;
            else { carbonic = Int32.Parse(carbonic_txtbx.Text); }

            if (bottle_txtbx.Text == "")
                bottle = 0;
            else { bottle = Int32.Parse(bottle_txtbx.Text); }






            Database db = new Database();

            OracleConnection conn = db.dbConnect();

            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER+{syrup} WHERE MATERIAL_ID='SYRUP'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER+{sugar} WHERE MATERIAL_ID='SUGAR'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER+{extract} WHERE MATERIAL_ID='EXTRACT_COKE'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER+{carbonic} WHERE MATERIAL_ID='CARBONIC'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = $"UPDATE INVENTORY SET MATERIAL_NUMBER=MATERIAL_NUMBER+{bottle} WHERE MATERIAL_ID='BOTTLE'";
            cmd.ExecuteNonQuery();

            MessageBox.Show("발주되었습니다!");

            syrup_txtbx.Text = "";
            sugar_txtbx.Text = "";
            extract_txtbx.Text = "";
            carbonic_txtbx.Text = "";
            bottle_txtbx.Text = "";
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
            syrup_txtbx.Text = "";
            sugar_txtbx.Text = "";
            extract_txtbx.Text = "";
            carbonic_txtbx.Text = "";
            bottle_txtbx.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
