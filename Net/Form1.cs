using System;
using System.Windows.Forms;

namespace Net
{
    public partial class Form1 : Form
    {
        int Size;
        int area;
        TextBox[] vec = new TextBox[0];
        TextBox[,] tb1 = new TextBox[0, 0];
        TextBox[,] tb2 = new TextBox[0, 0];
        Label[,] res = new Label[0, 0];
        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Location = new System.Drawing.Point(560, 10);
            label6.Location = new System.Drawing.Point(560, 30);
            label7.Location = new System.Drawing.Point(560, 50);
            label8.Location = new System.Drawing.Point(560, 70);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") 
            {
                Size = int.Parse(textBox1.Text);
                for (int i = 0; i < vec.GetLength(0); i++)
                {
                    Controls.Remove(vec[i]);
                    vec[i].Dispose();
                }

                vec = new TextBox[Size];
                label4.Location = new System.Drawing.Point(10, 80);
                label4.Visible = true;
                for (int i = 0; i < vec.GetLength(0); i++)
                {
                        vec[i] = new System.Windows.Forms.TextBox();
                        vec[i].Location = new System.Drawing.Point(10 + i * 70, 100);
                        vec[i].Size = new System.Drawing.Size(60, 23);
                        Controls.Add(vec[i]);
                    vec[i].Text = "0";
                }


                //матрица V
                for (int i = 0; i < tb1.GetLength(0); i++)
                {
                    for (int j = 0; j < tb1.GetLength(1); j++)
                    {
                        Controls.Remove(tb1[i, j]);
                        tb1[i, j].Dispose();
                    }
                }

                tb1 = new TextBox[Size, Size];
                label2.Location = new System.Drawing.Point(10, 180);
                label2.Visible = true;
                for (int i = 0; i < tb1.GetLength(0); i++)
                {
                    for (int j = 0; j < tb1.GetLength(1); j++)
                    {
                        tb1[i, j] = new System.Windows.Forms.TextBox();
                        tb1[i, j].Location = new System.Drawing.Point(10 + j * 70, 200 + i * 30);
                        area = 10 + j * 70;
                        tb1[i, j].Size = new System.Drawing.Size(60, 23);
                        Controls.Add(tb1[i, j]);
                        tb1[i, j].Text = "0";
                    }
                }

                //матрица W

                for (int i = 0; i < tb2.GetLength(0); i++)
                {
                    for (int j = 0; j < tb2.GetLength(1); j++)
                    {
                        Controls.Remove(tb2[i, j]);
                        tb2[i, j].Dispose();
                    }
                }

                tb2 = new TextBox[Size, Size];
                label3.Location = new System.Drawing.Point(area + 100 + 10, 180);
                label3.Visible = true;
                for (int i = 0; i < tb2.GetLength(0); i++)
                {
                    for (int j = 0; j < tb2.GetLength(1); j++)
                    {
                        tb2[i, j] = new System.Windows.Forms.TextBox();
                        tb2[i, j].Location = new System.Drawing.Point(area + 100 + 10 + j * 70, 200 + i * 30);
                        tb2[i, j].Size = new System.Drawing.Size(60, 23);
                        Controls.Add(tb2[i, j]);
                        tb2[i, j].Text = "0";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "5";

            vec[2].Text = "6";
            
            for (int i = 0; i < tb1.GetLength(0); i++)
            {
                for (int j = 0; j < tb1.GetLength(1); j++)
                {
                    tb1[i, j].Text = "0,2";
                    tb2[i, j].Text = "0,2";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    Controls.Remove(res[i, j]);
                    res[i, j].Dispose();
                }
            }


            NetResult result = new NetResult(vec.Length);

            result.Net1 = Multiply(vec, tb2);
            result.Out1 = F(result.Net1);
            result.Net2 = Multiply2(result.Net2, tb1);
            result.Out2 = F(result.Net2);

            res = new Label[4, Size];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    res[i, j] = new System.Windows.Forms.Label();
                    res[i, j].Location = new System.Drawing.Point(600 + 10 + j * 70, 10 + i * 20);
                    res[i, j].Size = new System.Drawing.Size(60, 15);
                    Controls.Add(res[i, j]);
                    res[i, j].Text = "0";
                }
            }
            for (int j = 0; j < Size; j++)
            {
                res[0, j].Text = result.Net1[j].ToString();
                res[1, j].Text = result.Out1[j].ToString();
                res[2, j].Text = result.Net2[j].ToString();
                res[3, j].Text = result.Out2[j].ToString();
            }
        }

        private static float[] F(float[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = (float)(1 / (1 + Math.Exp((double)-v[i])));
            }

            return v;
        }

        private static float[] Multiply(TextBox[] vector, TextBox[,] matrix)
        {
            float[] result = new float[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = 0; j < vector.Length; j++)
                {
                    result[i] += float.Parse(vector[i].Text) * float.Parse(matrix[i, j].Text);
                }
            }

            return result;
        }

        private static float[] Multiply2(float[] vector, TextBox[,] matrix)
        {
            float[] result = new float[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                for (int j = 0; j < vector.Length; j++)
                {
                    result[i] += vector[i] * float.Parse(matrix[i, j].Text);
                }
            }

            return result;
        }
    }
}
