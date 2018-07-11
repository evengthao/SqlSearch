using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLParsing
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           
            string[] lines = System.IO.File.ReadAllLines(@"c:\temp\initialdata.sql");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            var sqlStatement = new StringBuilder();
            var endOfSqlStatement = false;
            var containsSearchText = false;
            txtOutput.Clear();
            foreach (string line in lines)
            {
                if (line.ToLower().Contains(txtSearchText.Text.ToLower()))
                {
                    containsSearchText = true;
                }

                if (containsSearchText)
                {
                    sqlStatement.Append(line.Replace("\r\n", "").Trim());
                    if (line.Contains(";"))
                    {
                        Console.WriteLine(sqlStatement.ToString() + "\r\n");
                        txtOutput.AppendText(sqlStatement.ToString() + "\r\n");
                        txtOutput.AppendText("\r\n");
                        sqlStatement.Clear();
                        containsSearchText = false;
                    }
                }
              

                // Use a tab to indent each line of the file.
                //Console.WriteLine("\t" + line);
            }

            // Keep the console window open in debug mode.
        }
    }
}
