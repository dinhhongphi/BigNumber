using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Caculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Number a;
            string result;
            string temp;
            try
            {
                a = new Number(txtInput.Text);
                //split number to plus
                result = a.Next();
                while ((temp = a.Next()) != null)
                {
                    if (result.Length >= temp.Length)
                    {
                        result = PlusTwoNumber(result, temp);
                    }
                    else
                    {
                        result = PlusTwoNumber(temp, result);
                    }
                }
                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                a = null;
                result = string.Empty;
                temp = string.Empty;
                MessageBox.Show(ex.Message);
            }
        }

        private string PlusTwoNumber(string l, string s)
        {
            //check l and s
            if (string.IsNullOrEmpty(l.Trim()) ||
                string.IsNullOrEmpty(s.Trim()))
            {
                throw new ArgumentException();
            }
            int r = 0;
            string result = "";
            int i, t = 1;
            //plus columns in two numbers
            for (i = s.Length - 1; i >= 0; i--)
            {
                if (!int.TryParse(l[l.Length - t++].ToString(), out int l_column_t)
                    || !int.TryParse(s[i].ToString(), out int s_column_i))
                {
                    throw new ArgumentException();
                }
                var temp = Plus(l_column_t, s_column_i + r, out r);
                result = result.Insert(0, temp.ToString());
            }
            //plus or add remainder to result
            i = l.Length - s.Length;
            while (r > 0)
            {
                if (l.Length > result.Length)
                {
                    var temp = Plus(l[--i] - '0', r, out r);
                    result = result.Insert(0, temp.ToString());
                }
                else //equals, then insert remainder to start result
                {
                    result = result.Insert(0, r.ToString());
                    r = 0;
                }
            }
            //copy  rest of l to result
            while (i > 0)
            {
                result = result.Insert(0, l[--i].ToString());
            }
            return result;
        }

        //plus columns in two numbers
        private int Plus(int x, int y, out int r)
        {
            int temp = x + y;
            r = temp / 10; //plus remainder
            return temp % 10;
        }

    }
}
