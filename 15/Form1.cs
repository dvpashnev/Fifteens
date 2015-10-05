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

namespace _15
{
  public partial class Form1 : Form
  {
    private int[,] positions = {{1,5,9,13}, {2,6,10,14}, {3,7,11,15}, {4,8,12,0} };
    public Form1()
    {
      InitializeComponent();
      begin(NewToolStripMenuItem, new EventArgs());
    }

    private void begin(object sender, EventArgs e)
    {
      foreach (Control c in tableLayoutPanel1.Controls)
      {
        if (c is Button)
        {
          int col = new Random().Next(0, 3);
          Thread.Sleep(2);
          int row = new Random().Next(0, 3);
          if (tableLayoutPanel1.GetControlFromPosition(col, row) == null)
          {
            tableLayoutPanel1.SetCellPosition(c, new TableLayoutPanelCellPosition(col, row));
          }
          else
          {
            tableLayoutPanel1.SetCellPosition(tableLayoutPanel1.GetControlFromPosition(col, row),
              tableLayoutPanel1.GetPositionFromControl(c));
            tableLayoutPanel1.SetCellPosition(c, new TableLayoutPanelCellPosition(col, row));
          }
        }
      }
    }

    private void button15_Click(object sender, EventArgs e)
    {
      Button btn = sender as Button;

      if (tableLayoutPanel1.GetCellPosition(btn).Column + 1 < 4 &&
        tableLayoutPanel1.GetControlFromPosition(
        tableLayoutPanel1.GetCellPosition(btn).Column + 1,
        tableLayoutPanel1.GetCellPosition(btn).Row
        ) == null)
      {
        tableLayoutPanel1.SetCellPosition(btn,
          new TableLayoutPanelCellPosition(
            tableLayoutPanel1.GetCellPosition(btn).Column + 1,
            tableLayoutPanel1.GetCellPosition(btn).Row));
      }
      else if (tableLayoutPanel1.GetCellPosition(btn).Column - 1 >= 0 &&
        tableLayoutPanel1.GetControlFromPosition(
        tableLayoutPanel1.GetCellPosition(btn).Column - 1,
        tableLayoutPanel1.GetCellPosition(btn).Row
        ) == null)
      {
        tableLayoutPanel1.SetCellPosition(btn,
          new TableLayoutPanelCellPosition(
            tableLayoutPanel1.GetCellPosition(btn).Column - 1,
            tableLayoutPanel1.GetCellPosition(btn).Row));
      }
      else if (tableLayoutPanel1.GetCellPosition(btn).Row + 1 < 4 &&
        tableLayoutPanel1.GetControlFromPosition(
        tableLayoutPanel1.GetCellPosition(btn).Column,
        tableLayoutPanel1.GetCellPosition(btn).Row + 1
        ) == null)
      {
        tableLayoutPanel1.SetCellPosition(btn,
          new TableLayoutPanelCellPosition(
            tableLayoutPanel1.GetCellPosition(btn).Column,
            tableLayoutPanel1.GetCellPosition(btn).Row + 1));
      }
      else if (tableLayoutPanel1.GetCellPosition(btn).Row - 1 >= 0 &&
        tableLayoutPanel1.GetControlFromPosition(
        tableLayoutPanel1.GetCellPosition(btn).Column,
        tableLayoutPanel1.GetCellPosition(btn).Row - 1
        ) == null)
      {
        tableLayoutPanel1.SetCellPosition(btn,
          new TableLayoutPanelCellPosition(
            tableLayoutPanel1.GetCellPosition(btn).Column,
            tableLayoutPanel1.GetCellPosition(btn).Row - 1));
      }
      check();
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void check()
    {
      int rezult = 0;
      for (int i = 0; i < 4; i++ )
      {
        for (int j = 0; j < 4; j++)
        {
          if(tableLayoutPanel1.GetControlFromPosition(i, j)==null)
          {
            continue;
          }
          if (Convert.ToInt32(tableLayoutPanel1.GetControlFromPosition(i, j).Text) == positions[i, j])
          {
            rezult++;
          }
        }
      }
      toolStripProgressBar1.Value = (int)(((double)rezult / 15) * 100);
      toolStripStatusLabel1.Text = rezult.ToString() + " из 15";
      if (rezult == 15)
      {
        MessageBox.Show("Вы выиграли!");
      }
    }
  }
}
