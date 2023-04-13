using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearch
{
    public partial class Form1 : Form
    {
        int d = 256;
        public Form1()
        {
            InitializeComponent();
        }

        public void computeLPSArray(string pat, int M, int[] lps)
        {

            int len = 0;
            lps[0] = 0;


            int i = 1;
            while (i < M)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string target;
            string temp_target;

            int i = 0;
          
            int j = 0;
            bool boolean = false;
            bool boolean2 = false;
         
            string algorithm;
            string concate_rows = "";
            string concate_columns = "";
            string concate_file = "";
                

            string path;
            int num=1;
            
            while(num<11)
            {
                boolean2 = false;
                
                // add path of files to be searched from
                path = "C:\\Users\\Shafay\\Desktop\\20i1824_20i2337_20i2391_AI-K_Assignment4\\FileSearch\\DataFiles\\Research#" + num.ToString() + ".txt";
                string [] text = System.IO.File.ReadAllLines(path);                 

                int text_len = text.Length;
                string[] temp_text = text;

                if (checkBox1.Checked)
                {
                    target = " ";
                    target = target + textBox1.Text;
                    target = target + " ";

                    temp_target = target;
                    string[] temp_temp=text;
                    
                    for (int uff=0; uff<text.Length; uff++)
                    {
                        temp_text[uff] = " " + text[uff] + " "; 
                    }

                }
                else
                {
                    target = textBox1.Text;
                }

                temp_target = target;

                if (checkBox2.Checked)
                {

                }
                else
                {
                    int uff = 0;
                    while(uff < text.Length)
                    {
                        temp_text[uff] = temp_text[uff].ToLower();
                        uff += 1;
                    }
                    
                    temp_target = temp_target.ToLower();

                }

                ////////////////////////////////////////////////////

                algorithm = comboBox1.Text;
                int target_len = target.Length;


                if (target_len == 0)
                {
                    MessageBox.Show("Please Enter String For Search.");
                    return;              
                }

                else if (comboBox1.Text == String.Empty)
                {                 
                    MessageBox.Show("Please Select Algorithm.");
                    return;             
                }

                else
                {                
                    algorithm = comboBox1.Text;

                    if (algorithm == "Brute Force (BF)")
                    {
                        for (int jj=0 ; jj<text.Length; jj++)
                        {
                            int M = temp_target.Length;
                            int N = temp_text[jj].Length;

                            i = 0;
                            for (i = 0; i <= N - M; i++)
                            {
                                j = 0;

                                /* For current index i, check for pattern match */
                                for (j = 0; j < M; j++)
                                    if (temp_text[jj][i + j] != temp_target[j])
                                        break;

                                if (j == M)
                                {
                                    boolean = true;

                                    if (boolean2 == false)
                                    {
                                        concate_file = concate_file + " " + "  Research #" + num.ToString() + ".txt";
                                    }

                                    boolean2 = true;
                                    concate_file = concate_file + '\n';
                                    concate_columns = concate_columns + "     " + (i).ToString() + "  -  " + (i - 1 + M).ToString();
                                    concate_columns = concate_columns + '\n';

                                    concate_rows = concate_rows + "     " + jj.ToString();
                                    concate_rows = concate_rows + '\n';
                                }
                            }                          
                      }                           
                    }

                    ////////////////////////////////////////////////////////////////////

                    else if (algorithm == "Robin Karp (RP)")
                    {
                        int M;
                        int N;
                        int p, t = 0;
                        int h = 1;
                        int q;
                        q = Int32.MaxValue;
                        for(int jj=0; jj<text.Length;jj++)
                        {
                            int start, end = 0;
                             M = temp_target.Length;
                             N = temp_text[jj].Length;

                            p = 0;
                            t = 0;
                            h = 1;

                            for (int ii = 0; ii < M - 1; ii++)
                            { h = (h * d) % q; }

                            // Calculating Hash of First Sequence To Be Checked  
                            for (int ii = 0; ii < M; ii++)
                            {
                                p = (d * p + temp_target[ii]) % q;
                                if (ii < N)
                                { t = (d * t + temp_text[jj][ii]) % q; }
                            }

                            i=0;
                            j=0;
                            for (i = 0; i <= N - M; i++)
                            {
                                start = i;
                                end = i + M;
                                if (p == t) // Checking if total hash value matches
                                {
                                    for (j = 0; j < M; j++) // Checking each hash value
                                    {
                                        if (text[jj][i + j] != temp_target[j])
                                        { break; }
                                    }

                                    if (j == M) // If Exact sequence found
                                    { 
                                         boolean = true;

                                        if (boolean2 == false)
                                        {
                                            concate_file = concate_file + " " + "  Research #" + num.ToString() + ".txt";
                                        }

                                        boolean2 = true;
                                        concate_file = concate_file + '\n';
                                        concate_columns = concate_columns + "     " + (start).ToString() + "  -  " + (end - 1).ToString();
                                        concate_columns = concate_columns + '\n';

                                        concate_rows = concate_rows + "     " + jj.ToString();
                                        concate_rows = concate_rows + '\n';
                                    }
                                }

                                if (i < N - M)
                                {
                                    t = (d * (t - temp_text[jj][i] * h) + temp_text[jj][i + M]) % q; // Removing hash value of previous character & adding of new character

                                    if (t < 0)
                                    { t = (t + q); }
                                }
                            }
                         }                                                  
                      }

                   /////////////////////////////////////////////////////////////////////
                    else if (algorithm == "Knuth Morris Pratt (KMP)")
                    {
                        int M;
                        int N;
                        for(int jj=0; jj<text.Length;jj++)
                        {
                            M = temp_target.Length;
                            N = temp_text[jj].Length;
 
                            int[] lps = new int[M]; // array that holds prefix/sufix values from text

                        
                            computeLPSArray(temp_target, M, lps);
 
                            i = 0; 
                            j = 0;
                            
                            while ((N - i) >= (M - j)) 
                            {
                                if (temp_target[j] == temp_text[jj][i]) // Matching both
                                {
                                    j++;
                                    i++;
                                }
 
                                if (j == M) 
                                {
                                    boolean = true;

                                    if (boolean2 == false)
                                    {
                                        concate_file = concate_file + " " + "  Research #" + num.ToString() + ".txt";
                                    }

                                    boolean2 = true;
                                    concate_file = concate_file + '\n';
                                    concate_columns = concate_columns + "     " + (i - M).ToString() + "  -  " + (i -1).ToString();
                                    concate_columns = concate_columns + '\n';

                                    concate_rows = concate_rows + "     " + jj.ToString();
                                    concate_rows = concate_rows + '\n';

                                    j = lps[j - 1];
                                }
                                else if (i < N && temp_target[j] != temp_text[jj][i]) 
                                {
                                    if (j != 0)
                                        j = lps[j - 1];
                                    else
                                        i = i + 1;
                                }
                            }
                        }                     
                    }

                    ////////////////////////////////////////////////////////////////////
                    else
                    {
                        return;
                    }
                    num += 1;
                }
                     
            }

            this.Hide();
            Form2 obj3 = new Form2(concate_file, concate_columns, concate_rows, boolean);
            obj3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj3 = new Form1();
            obj3.Show();
        }  
     }
}
