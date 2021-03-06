﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Latihan_4_1
{
    public partial class Form1 : Form
    {
        string filename;
        Boolean newfile = false;
        //
        public Form1()
        {
            InitializeComponent();
            textboxArea.Enabled = false;
            buttonSave.Enabled = false;
            labelFilename.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog window_open_dialog = new OpenFileDialog();

            if (window_open_dialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader stream_read = new StreamReader(File.OpenRead(window_open_dialog.FileName));
                textboxArea.Text = stream_read.ReadToEnd();
                stream_read.Dispose();
                //
                textboxArea.Enabled = true;
                buttonSave.Enabled = true;
                filename = window_open_dialog.FileName;
                labelFilename.Text = filename;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            StreamWriter stream_write = new StreamWriter(filename);
            stream_write.Write(textboxArea.Text);
            stream_write.Dispose();
            //
            labelFilename.Text = filename;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newfile = true;
            textboxArea.Enabled = true;
            buttonSave.Enabled = true;
            textboxArea.Text = "";
            labelFilename.Text = "Filename : *untitled";
        }

        private void textboxArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult warna = colorDialog1.ShowDialog();
            if (warna == DialogResult.OK)
            {
                textboxArea.ForeColor = colorDialog1.Color;
            }
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = textboxArea.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textboxArea.SelectionFont = fd.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textboxArea.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textboxArea.BackColor = colorDialog1.Color;
            }
        }
    }
}
