using EIPTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WAGOTemplate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0 & this.comboBox2.SelectedIndex == 0)
            {
                CheckAndUpdateChannels0();
            }
            else
            {
                if (this.comboBox1.SelectedIndex == 0 & this.comboBox2.SelectedIndex == 1)
                {
                    CheckAndUpdateChannels1();
                }
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var file = new SaveFileDialog())
            {
                file.Title = "选择文件保存位置";
                file.FileName = textBox1.Text;
                file.Filter = "Json file(*.json)|*.json";
                file.DefaultExt = "json";
                file.CheckPathExists = true;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    var can = WAGOCANOpen.CreateSlaveConfig((int)numericUpDownDI.Value, (int)numericUpDownDO.Value,
                      (int)numericUpDownAI.Value, (int)numericUpDownAO.Value, (int)numericUpDownUC.Value, textBox1.Text, textBox1.Text);
                    ConfigGenerator.Export(file.FileName, can);
                }

                    
            }
        }

        private void ChangeFileName()
        {
            int c = 337;
            if (this.comboBox1.SelectedIndex == 0 & this.comboBox2.SelectedIndex == 1)
            {
                c = 337;
            }
            else
            {
                if (this.comboBox1.SelectedIndex == 0 & this.comboBox2.SelectedIndex == 0)
                {
                    c = 363;
                }
            }
            StringBuilder s = new StringBuilder($"WAGO {c}");
            if (numericUpDownDI.Value != 0)
            {
                s.Append($" {numericUpDownDI.Value}DI");
            }
            if (numericUpDownDO.Value != 0)
            {
                s.Append($" {numericUpDownDO.Value}DO");
            }
            if (numericUpDownAI.Value != 0)
            {
                s.Append($" {numericUpDownAI.Value}AI");
            }
            if (numericUpDownAO.Value != 0)
            {
                s.Append($" {numericUpDownAO.Value}AO");
            }
            if (numericUpDownUC.Value != 0)
            {
                s.Append($" {numericUpDownUC.Value}UC");
            }
            textBox1.Text = s.ToString();
        }

        private bool CheckAndUpdateChannels0()
        {
            bool pass;
            if (WAGOCANOpen.CalTPDOLength((int)numericUpDownDI.Value, (int)numericUpDownAI.Value, (int)numericUpDownUC.Value) <= 24)
            {
                if (WAGOCANOpen.CalRPDOLength((int)numericUpDownDO.Value, (int)numericUpDownAO.Value) <= 24)
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                }
            }
            else
            {
                pass = false;
                MessageBox.Show("The combination of current input parameters is invalid\n" +
                                "because the maximum number of CAN messages is exceeded.\n " +
                                "Please reduce the number of channels.","ERROR",
                                MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (pass == true)
            {
                button1.Enabled = true;
                //检查通过改变文件名称
                ChangeFileName();
            }            
            else
            {
                button1.Enabled = false;
            }
            return pass;
        }

        private bool CheckAndUpdateChannels1()
        {
            bool pass;
            if (WAGOEIP.CalTPDOBytes((int)numericUpDownDI.Value, (int)numericUpDownAI.Value, (int)numericUpDownUC.Value) <= 255)
            {
                if (WAGOEIP.CalRPDOBytes((int)numericUpDownDO.Value, (int)numericUpDownAO.Value,(int)numericUpDownUC.Value) <= 255)
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                }
            }
            else
            {
                pass = false;
                MessageBox.Show("The combination of current input parameters is invalid\n" +
                                "because the maximum number of messages is exceeded.\n " +
                                "Please reduce the number of channels.", "ERROR",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (pass == true)
            {
                button1.Enabled = true;
                //检查通过改变文件名称
                ChangeFileName();
            }
            else
            {
                button1.Enabled = false;
            }
            return pass;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //检查通过改变文件名称
            ChangeFileName();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //检查通过改变文件名称
            ChangeFileName();
        }
    }
}
