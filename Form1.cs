using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class Form1 : Form
    {
        Cell[] grid;
        List<Cell> stack, deadEnds;
        int border = 2;
        int cellNumber = 10;
        int cellWidth;
        Cell currentCell;
        int rows, cols;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            InitializeGrid();  //Dead ends Doesnt work

             
            while (MovetoNewCell())
            {
                UpdateGrid();
            }
            UpdateGrid();

            //Environment.Exit(0);
        }

        public void InitializeGrid()
        {
            stack = new List<Cell>();
            deadEnds = new List<Cell>();

            imageBox.Image = new Bitmap(imageBox.Width, imageBox.Height);

            cellWidth = imageBox.Image.Width / cellNumber;
            rows = imageBox.Image.Height / cellWidth;
            cols = imageBox.Image.Width / cellWidth;

            grid = new Cell[rows * cols];

            int pos = 0;
            for (int i = 0; i < rows; i++)  //ROWS
            {
                for (int j = 0; j < cols; j++)  //COLUMNS
                {
                    grid[pos++] = new Cell(i, j);
                }
            }

            Graphics graphics = Graphics.FromImage(imageBox.Image);

            for (int x = 0; x < grid.Length; x++)
            {
                Cell cell = grid[x];
                PaintCell(cell, Brushes.White);
            }
            imageBox.Image = imageBox.Image;

            currentCell = grid[random.Next(grid.Length)];
            currentCell.starter = true;
        }

        public void UpdateGrid()
        {
            for(int i=0; i<grid.Length; i++)  //Paints every grid
            {
                Cell cell = grid[i];

                int walls = 0;
                for (int j = 0; j < cell.walls.Length; j++)
                    if (cell.walls[j])
                        walls++;

                if(walls == 1)
                    PaintCell(cell, Brushes.AliceBlue);
                else
                    PaintCell(cell, Brushes.White);

                imageBox.Image = imageBox.Image;
            }
        }

        void PaintCell(Cell cell, Brush brush)
        {
            Graphics graphics = Graphics.FromImage(imageBox.Image);

            if (cell.starter)
                graphics.FillRectangle(Brushes.Orange, cell.y * cellWidth + border, cell.x * cellWidth + border, cellWidth - border, cellWidth - border);
            //else if (deadEnds.Contains(cell)) 
            //    graphics.FillRectangle(Brushes.Red, cell.y * cellWidth + border, cell.x * cellWidth + border, cellWidth - border, cellWidth - border);
            else
                graphics.FillRectangle(brush, cell.y*cellWidth + border, cell.x*cellWidth + border, cellWidth - border, cellWidth - border);


            /**/
            if (!cell.walls[0])  //Top
                graphics.FillRectangle(brush, cell.y * cellWidth + border, cell.x * cellWidth + border, cellWidth - border, border);
            if (!cell.walls[1]) //Right
                graphics.FillRectangle(brush, cell.y * cellWidth + cellWidth, cell.x * cellWidth + border, border, cellWidth - border);
            if (!cell.walls[2]) //Bottom
                graphics.FillRectangle(brush, cell.y * cellWidth + border, cell.x * cellWidth + cellWidth, cellWidth - border, border);
            if (!cell.walls[3]) //Left
                graphics.FillRectangle(brush, cell.y * cellWidth + border, cell.x * cellWidth + border, border, cellWidth - border);
        }

        bool MovetoNewCell()
        {
            Cell top = GetNeighbourCell(currentCell.x, currentCell.y - 1);
            Cell right = GetNeighbourCell(currentCell.x + 1, currentCell.y);
            Cell bottom = GetNeighbourCell(currentCell.x, currentCell.y + 1);
            Cell left = GetNeighbourCell(currentCell.x - 1, currentCell.y);

            List<Cell> neighbourhood = new List<Cell>();

            if (top.x != -1 && !top.visited)
                neighbourhood.Add(top);
            if (right.x != -1 && !right.visited)
                neighbourhood.Add(right);
            if (bottom.x != -1 && !bottom.visited)
                neighbourhood.Add(bottom);
            if (left.x != -1 && !left.visited)
                neighbourhood.Add(left);

            currentCell.visited = true;

            if (neighbourhood.Count > 0)
            {
                Cell nextCell = neighbourhood[random.Next(neighbourhood.Count)];
                RemoveWalls(currentCell, nextCell);

                currentCell = nextCell;

                if (neighbourhood.Count > 1)
                    stack.Add(currentCell);

                UpdateGrid();
                return true;
            }
            else
            {
                if (stack.Count == 0)
                    return false;

                Cell nextCell = stack[stack.Count - 1];
                currentCell = nextCell;

                stack.Remove(nextCell);

                deadEnds.Add(currentCell);

                return true;
            }
        }

        private void RestartBt_Click(object sender, EventArgs e)
        {
            InitializeGrid();  //Deadends Doesnt work

            while (MovetoNewCell())
            {
                UpdateGrid();
            }
        }

        Cell GetNeighbourCell(int x, int y)
        {
            if (x < 0 || y < 0 || x > rows - 1 || y > cols - 1)
                return new Cell(-1,-1);
            else
                return grid[y + x * cols];
        }

        void RemoveWalls(Cell current, Cell next)
        {
            if(current.x > next.x)
            {
                current.walls[0] = false;
                next.walls[2] = false;
            }
            else if(current.x < next.x)
            {
                current.walls[2] = false;
                next.walls[0] = false;
            }

            if (current.y > next.y)
            {
                current.walls[3] = false;
                next.walls[1] = false;
            }
            else if (current.y < next.y)
            {
                current.walls[1] = false;
                next.walls[3] = false;
            }
        }
    }
}
