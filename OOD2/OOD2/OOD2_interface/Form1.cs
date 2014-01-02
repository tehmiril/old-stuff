using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OOD2_interface
{
    public partial class Form1 : Form
    {
        private Graphics g;

        bool ANDbuttonSelected = false;
        bool ORbuttonSelected = false;
        bool NOTbuttonSelected = false;
        bool SINKbuttonSelected = false;
        bool SOURCEbuttonSelected = false;
        bool CONNECTbuttonSelected = false;
        bool DELETEbuttonSelected = false;

        int connectionGate1X = 0;
        int connectionGate1Y = 0;

        int connectionGate2X = 0;
        int connectionGate2Y = 0;

        int locationX;
        int locationY;

        GATE[] gateArray = new GATE[2]{null, null};

        string fileCheck = "OOD Group C 2011";

        BOARD myBoard = new BOARD();

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(800, 600);
            g = Graphics.FromImage(this.pictureBox1.Image);
            Pen myBlackPen = new Pen(Color.Black);
            int currentX = 0, currentY = 0;
            int widthOfOneCell = 40, heightOfOneCell = 40;
            for (int j = 1; j < pictureBox1.Size.Width; j++)
            {
                for (int i = 1; i < pictureBox1.Size.Height; i++)
                {
                    g.DrawRectangle(myBlackPen, currentX, currentY, widthOfOneCell, heightOfOneCell);
                    currentX += widthOfOneCell;
                }
                currentX = 0;
                currentY += widthOfOneCell;
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            if (CONNECTbuttonSelected)
            {
                button_connect.BackColor = Color.Empty;
                CONNECTbuttonSelected = false;
            }
            else if (!ANDbuttonSelected && !ORbuttonSelected && !NOTbuttonSelected && !SINKbuttonSelected && !SOURCEbuttonSelected)
            {
                button_connect.BackColor = Color.Yellow;
                CONNECTbuttonSelected = true;
            }
        }

        private void button_and_Click(object sender, EventArgs e)
        {
            if (ANDbuttonSelected)
            {
                button_and.BackColor = Color.Empty;
                ANDbuttonSelected = false;
            }
            else if (!ORbuttonSelected && !NOTbuttonSelected && !SINKbuttonSelected && !SOURCEbuttonSelected && !CONNECTbuttonSelected)
            {
                button_and.BackColor = Color.Yellow;
                ANDbuttonSelected = true;
            }
        }

        private void button_source_Click(object sender, EventArgs e)
        {
            if (SOURCEbuttonSelected)
            {
                button_source.BackColor = Color.Empty;
                SOURCEbuttonSelected  = false;
            }
            else if (!ANDbuttonSelected && !ORbuttonSelected && !NOTbuttonSelected && !SINKbuttonSelected && !CONNECTbuttonSelected)
            {
                button_source.BackColor = Color.Yellow;
                SOURCEbuttonSelected = true;

            }
        }

        private void button_lamp_Click(object sender, EventArgs e)
        {
            if (SINKbuttonSelected)
            {
                button_lamp.BackColor = Color.Empty;
                SINKbuttonSelected  = false;
            }
            else if (!ANDbuttonSelected && !ORbuttonSelected && !NOTbuttonSelected && !SOURCEbuttonSelected && !CONNECTbuttonSelected)
            {
                button_lamp.BackColor = Color.Yellow;
                SINKbuttonSelected = true;
            }
        }

        private void button_or_Click(object sender, EventArgs e)
        {
            if (ORbuttonSelected)
            {
                button_or.BackColor = Color.Empty;
                ORbuttonSelected = false;
            }
            else if (!ANDbuttonSelected && !NOTbuttonSelected && !SINKbuttonSelected && !SOURCEbuttonSelected && !CONNECTbuttonSelected)
            {
                button_or.BackColor = Color.Yellow;
                ORbuttonSelected = true;
            }
        }

        private void button_not_Click(object sender, EventArgs e)
        {
            if (NOTbuttonSelected)
            {
                button_not.BackColor = Color.Empty;
                NOTbuttonSelected = false;
            }
            else if (!ANDbuttonSelected && !ORbuttonSelected && !SINKbuttonSelected && !SOURCEbuttonSelected && !CONNECTbuttonSelected)
            {
                button_not.BackColor = Color.Yellow;
                NOTbuttonSelected = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < myBoard.myConnection.Count(); i++)
            {
                myBoard.myConnection[i].draw(e);
                myBoard.myConnection[i].transferValue();
            }

            for (int i = 0; i < myBoard.myGate.Count(); i++)
            {
                myBoard.myGate[i].operation();
            }
            
            for (int i = 0; i < myBoard.myGate.Count(); i++)
            {
                myBoard.myGate[i].draw(e);
            }

            pictureBox1.Update();
            pictureBox1.Invalidate();         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ANDbuttonSelected)
            {
                ANDGate and1 = new ANDGate(locationX, locationY);
                button_and.BackColor = Color.Empty;
                ANDbuttonSelected = false;
                myBoard.myGate.Add(and1);
            }

            if (SINKbuttonSelected)
            {
                SINKGate sink1 = new SINKGate(locationX, locationY);
                button_lamp.BackColor = Color.Empty;
                SINKbuttonSelected = false;
                myBoard.myGate.Add(sink1);
            }

            if (ORbuttonSelected)
            {
                ORGate or1 = new ORGate(locationX, locationY);
                button_or.BackColor = Color.Empty;
                ORbuttonSelected = false;
                myBoard.myGate.Add(or1);
            }

            if (NOTbuttonSelected)
            {
                NOTGate not1 = new NOTGate(locationX, locationY);
                button_not.BackColor = Color.Empty;
                NOTbuttonSelected = false;
                myBoard.myGate.Add(not1);
            }

            if (SOURCEbuttonSelected)
            {
                SOURCEGate source1 = new SOURCEGate(locationX, locationY);
                button_source.BackColor = Color.Empty;
                SOURCEbuttonSelected = false;
                myBoard.myGate.Add(source1);
            }

            if (DELETEbuttonSelected)
            {
                bool gateDeleted = false;
                for (int i = 0; i < myBoard.myGate.Count(); i++)
                {
                    
                    if (locationX > myBoard.myGate[i].prop_X && locationX < myBoard.myGate[i].prop_X + 60 && locationY > myBoard.myGate[i].prop_Y && locationY < myBoard.myGate[i].prop_Y + 60)
                    {
                        myBoard.myGate.Remove(myBoard.myGate[i]);
                        gateDeleted = true;
                    }
                }
                for (int i = 0; i < myBoard.myConnection.Count(); i++)
                {

                    if ((locationX > myBoard.myConnection[i].Gate1_prop_X && locationX < myBoard.myConnection[i].Gate2_prop_X && locationY > myBoard.myConnection[i].Gate1_prop_Y && locationY < myBoard.myConnection[i].Gate2_prop_Y) || (locationX > myBoard.myConnection[i].Gate1_prop_X && locationX < myBoard.myConnection[i].Gate2_prop_X && locationY < myBoard.myConnection[i].Gate1_prop_Y && locationY > myBoard.myConnection[i].Gate2_prop_Y))
                    {
                        myBoard.myConnection[i].removeConnection();
                        myBoard.myConnection.Remove(myBoard.myConnection[i]);
                        gateDeleted = true;
                    }
                }
                if (!gateDeleted)
                    this.label1.Text = "No Gate / Connection is found!";
                buttonDel.BackColor = Color.Empty;
                DELETEbuttonSelected = false;
            }

            if (CONNECTbuttonSelected)
            {
                int inp_num = 0;
                if (gateArray[0] == null && gateArray[1] == null)
                {
                    for (int i = 0; i < myBoard.myGate.Count(); i++)
                    {
                        if (!myBoard.myGate[i].outpSelected && (locationX > myBoard.myGate[i].outp_prop_X - 5 && locationX < myBoard.myGate[i].outp_prop_X + 5 && locationY > myBoard.myGate[i].outp_prop_Y - 5 && locationY < myBoard.myGate[i].outp_prop_Y + 5))
                        {
                            gateArray[0] = myBoard.myGate[i];
                            connectionGate1X = myBoard.myGate[i].outp_prop_X;
                            connectionGate1Y = myBoard.myGate[i].outp_prop_Y;
                            myBoard.myGate[i].inp2Selected = true;
                        }
                    }
                }

                else if (gateArray[0] != null && gateArray[1] == null)
                {
                    for (int i = 0; i < myBoard.myGate.Count(); i++)
                    {
                        if (!myBoard.myGate[i].inp1Selected && (locationX > myBoard.myGate[i].inp1_prop_X - 5 && locationX < myBoard.myGate[i].inp1_prop_X + 5 && locationY > myBoard.myGate[i].inp1_prop_Y - 5 && locationY < myBoard.myGate[i].inp1_prop_Y + 5))
                    {
                        gateArray[1] = myBoard.myGate[i];
                        connectionGate2X = myBoard.myGate[i].inp1_prop_X;
                        connectionGate2Y = myBoard.myGate[i].inp1_prop_Y;
                        myBoard.myGate[i].inp1Selected = true;
                        inp_num = 1;
                    }
                        else if (!myBoard.myGate[i].inp2Selected && (locationX > myBoard.myGate[i].inp2_prop_X - 5 && locationX < myBoard.myGate[i].inp2_prop_X + 5 && locationY > myBoard.myGate[i].inp2_prop_Y - 5 && locationY < myBoard.myGate[i].inp2_prop_Y + 5))
                    {
                        gateArray[1] = myBoard.myGate[i];
                        connectionGate2X = myBoard.myGate[i].inp2_prop_X;
                        connectionGate2Y = myBoard.myGate[i].inp2_prop_Y;
                        myBoard.myGate[i].inp2Selected = true;
                        inp_num = 2;
                    }
                }

                    if (gateArray[0] != null && gateArray[1] != null)
                    {
                        CONNECTION connection = new CONNECTION(gateArray[0], gateArray[1], connectionGate1X, connectionGate1Y, connectionGate2X, connectionGate2Y, inp_num);
                        myBoard.myConnection.Add(connection);
                        button_connect.BackColor = Color.Empty;
                        CONNECTbuttonSelected = false;
                    }

                    gateArray[0] = null;
                    gateArray[1] = null;
                    connectionGate1X = 0;
                    connectionGate1Y = 0;
                    connectionGate2X = 0;
                    connectionGate2Y = 0;
                }
            }

            if (myBoard.myGate.Count() != 0 && !ANDbuttonSelected && !ORbuttonSelected && !NOTbuttonSelected && !SINKbuttonSelected && !SOURCEbuttonSelected && !CONNECTbuttonSelected)
            {
                for (int i = 0; i < myBoard.myGate.Count(); i++)
                {
                    int tempX = myBoard.myGate[i].prop_X;
                    int tempY = myBoard.myGate[i].prop_Y;
                    if (locationX >= tempX && (tempX + 50) >= locationX && locationY >= tempY && (tempY + 50) >= locationY)
                        myBoard.myGate[i].changeValue();
                }
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            locationX = e.X;
            locationY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DELETEbuttonSelected)
            {
                buttonDel.BackColor = Color.Empty;
                DELETEbuttonSelected = false;
            }
            else if (!ORbuttonSelected && !NOTbuttonSelected && !SINKbuttonSelected && !SOURCEbuttonSelected && !CONNECTbuttonSelected)
            {
                buttonDel.BackColor = Color.Yellow;
                DELETEbuttonSelected = true;
            }
        }

        private void buttonClrAll_Click(object sender, EventArgs e)
        {
            myBoard.myGate.Clear();
            myBoard.myConnection.Clear();
            gateArray[0] = null;
            gateArray[1] = null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\help.chm");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files(*.txt)|*.txt";
            saveFileDialog1.Title = "Save ";


            if ((saveFileDialog1.ShowDialog()) == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null)
                {
                    StreamWriter saving = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.Create));

                    saving.WriteLine(fileCheck);
                    
                    foreach (GATE test in myBoard.myGate)
                    {
                        saving.WriteLine(test.GetType());
                        saving.WriteLine(test.prop_X);
                        saving.WriteLine(test.prop_Y);
                        saving.WriteLine(test.valueInput1);
                        saving.WriteLine(test.valueInput2);
                        saving.WriteLine(test.valueOutput);
                        saving.WriteLine(test.inp1Selected);
                        saving.WriteLine(test.inp2Selected);
                        saving.WriteLine(test.outpSelected);
                    }

                    saving.WriteLine('z');

                    foreach (CONNECTION test2 in myBoard.myConnection)
                    {
                        saving.WriteLine(test2.inputGate.prop_X);
                        saving.WriteLine(test2.inputGate.prop_Y);
                        saving.WriteLine(test2.outputGate.prop_X);
                        saving.WriteLine(test2.outputGate.prop_Y);
                        saving.WriteLine(test2.Gate1_prop_X);
                        saving.WriteLine(test2.Gate1_prop_Y);
                        saving.WriteLine(test2.Gate2_prop_X);
                        saving.WriteLine(test2.Gate2_prop_Y);
                        saving.WriteLine(test2.inputNum);
                    }

                    saving.Close();
                }
            }
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Txt(*.txt)|*.txt";
            openFileDialog1.Title = "Open";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            if ((openFileDialog1.ShowDialog()) == DialogResult.OK)
            {
                StreamReader loading = new StreamReader(new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read));

                if (fileCheck == loading.ReadLine())
                {
                    while (loading.Peek() != 'z')
                    {
                        String type = loading.ReadLine();
                        int X = Convert.ToInt32(loading.ReadLine());
                        int Y = Convert.ToInt32(loading.ReadLine());
                        bool inp1 = Convert.ToBoolean(loading.ReadLine());
                        bool inp2 = Convert.ToBoolean(loading.ReadLine());
                        bool outp = Convert.ToBoolean(loading.ReadLine());
                        bool inp1Sel = Convert.ToBoolean(loading.ReadLine());
                        bool inp2Sel = Convert.ToBoolean(loading.ReadLine());
                        bool outpSel = Convert.ToBoolean(loading.ReadLine());
                        if (type == "OOD2_interface.ANDGate")
                        {
                            ANDGate and2 = new ANDGate(X, Y, inp1, inp2, outp, inp1Sel, inp2Sel, outpSel);
                            myBoard.myGate.Add(and2);
                        }
                        if (type == "OOD2_interface.ORGate")
                        {
                            ORGate and2 = new ORGate(X, Y, inp1, inp2, outp, inp1Sel, inp2Sel, outpSel);
                            myBoard.myGate.Add(and2);
                        }
                        if (type == "OOD2_interface.NOTGate")
                        {
                            NOTGate and2 = new NOTGate(X, Y, inp1, inp2, outp, inp1Sel, inp2Sel, outpSel);
                            myBoard.myGate.Add(and2);
                        }
                        if (type == "OOD2_interface.SOURCEGate")
                        {
                            SOURCEGate and2 = new SOURCEGate(X, Y, inp1, inp2, outp, inp1Sel, inp2Sel, outpSel);
                            myBoard.myGate.Add(and2);
                        }
                        if (type == "OOD2_interface.SINKGate")
                        {
                            SINKGate and2 = new SINKGate(X, Y, inp1, inp2, outp, inp1Sel, inp2Sel, outpSel);
                            myBoard.myGate.Add(and2);
                        }
                    }

                    loading.ReadLine();

                    while (loading.Peek() != -1)
                    {
                        GATE gate1 = null;
                        GATE gate2 = null;
                        int Gate1X = Convert.ToInt32(loading.ReadLine());
                        int Gate1Y = Convert.ToInt32(loading.ReadLine());
                        int Gate2X = Convert.ToInt32(loading.ReadLine());
                        int Gate2Y = Convert.ToInt32(loading.ReadLine());
                        int conn1X = Convert.ToInt32(loading.ReadLine());
                        int conn1Y = Convert.ToInt32(loading.ReadLine());
                        int conn2X = Convert.ToInt32(loading.ReadLine());
                        int conn2Y = Convert.ToInt32(loading.ReadLine());
                        int inpNum = Convert.ToInt32(loading.ReadLine());
                        for (int i = 0; i < myBoard.myGate.Count(); i++)
                        {
                            if (Gate1X == myBoard.myGate[i].prop_X && Gate1Y == myBoard.myGate[i].prop_Y)
                                gate1 = myBoard.myGate[i];
                            else if (Gate2X == myBoard.myGate[i].prop_X && Gate2Y == myBoard.myGate[i].prop_Y)
                                gate2 = myBoard.myGate[i];
                        }
                        CONNECTION connection = new CONNECTION(gate1, gate2, conn1X, conn1Y, conn2X, conn2Y, inpNum);
                        myBoard.myConnection.Add(connection);
                    }
                    this.label1.Text = "";
                    loading.Close();
                }
                else
                {
                    this.label1.Text = "Unrecognized file type!";
                    loading.Close();
                }
            }

        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
