using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace File_Handling
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();
        public Form1()
        {

            InitializeComponent();
            this.table.Columns.Add("NAME");
            view_source.DataSource = this.table;
            read_file();
            view_source.Refresh();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            DataRow record = this.table.NewRow();
            record["NAME"] = Name.Text;
            this.table.Rows.Add(record);
            write_file();
            view_source.Refresh();
        }

        //Write File
        public void write_file()
        {
            string path = Directory.GetCurrentDirectory() + @"\DataFile.txt";
            if (File.Exists(path)) { File.Delete(path); }
            FileStream fs = File.Open(path, FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (DataRow row in this.table.Rows)
                    sw.WriteLine(row["NAME"]);
            }
        }
        //Read File
        public void read_file()
        {

            string path = Directory.GetCurrentDirectory() + @"\DataFile.txt";

            if (File.Exists(path))
            {

                FileStream fs = File.Open(path, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {

                    while (!sr.EndOfStream)
                    {

                        DataRow record = this.table.NewRow();
                        record["NAME"] = sr.ReadLine();
                        this.table.Rows.Add(record);
                    }

                }
            }
        }

        
    }
}
