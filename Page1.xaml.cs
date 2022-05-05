using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Navigation;

namespace GameOfLife
{
    public partial class Page1 : Page
    {
        Dictionary<int, int[,]> shapes_coordinate = new Dictionary<int, int[,]>();
        public Page1()
        {
            InitializeComponent();
            //_NavigationFrame.Navigate(new Page1());

            //initialize the shapes_coodinate Dictionary
            // for example mario == 1
            shapes_coordinate.Add(1, new int[,] { { 0, 3 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 0, 7 }, { 0, 8 }, { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 1, 6 }, { 1, 7 }, { 1, 8 }, { 1, 9 }, { 1, 10 }, { 1, 11 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 2, 7 }, { 2, 8 }, { 3, 1 }, { 3, 2 }, { 3, 3 }, { 3, 4 }, { 3, 5 }, { 3, 6 }, { 3, 7 }, { 3, 8 }, { 3, 9 }, { 3, 10 }, { 3, 11 }, { 4, 1 }, { 4, 2 }, { 4, 3 }, { 4, 4 }, { 4, 5 }, { 4, 6 }, { 4, 7 }, { 4, 8 }, { 4, 9 }, { 4, 10 }, { 4, 11 }, { 4, 12 }, { 5, 1 }, { 5, 2 }, { 5, 3 }, { 5, 4 }, { 5, 5 }, { 5, 6 }, { 5, 7 }, { 5, 8 }, { 5, 9 }, { 5, 10 }, { 5, 11 }, { 6, 3 }, { 6, 4 }, { 6, 5 }, { 6, 6 }, { 6, 7 }, { 6, 8 }, { 6, 9 }, { 6, 10 }, { 7, 2 }, { 7, 3 }, { 7, 4 }, { 7, 5 }, { 7, 6 }, { 7, 7 }, { 7, 8 }, { 8, 1 }, { 8, 2 }, { 8, 3 }, { 8, 4 }, { 8, 5 }, { 8, 6 }, { 8, 7 }, { 8, 8 }, { 8, 9 }, { 8, 10 }, { 9, 0 }, { 9, 1 }, { 9, 2 }, { 9, 3 }, { 9, 4 }, { 9, 5 }, { 9, 6 }, { 9, 7 }, { 9, 8 }, { 9, 9 }, { 9, 10 }, { 9, 11 }, { 10, 0 }, { 10, 1 }, { 10, 2 }, { 10, 3 }, { 10, 4 }, { 10, 5 }, { 10, 6 }, { 10, 7 }, { 10, 8 }, { 10, 9 }, { 10, 10 }, { 10, 11 }, { 11, 0 }, { 11, 1 }, { 11, 2 }, { 11, 3 }, { 11, 4 }, { 11, 5 }, { 11, 6 }, { 11, 7 }, { 11, 8 }, { 11, 9 }, { 11, 10 }, { 11, 11 }, { 12, 0 }, { 12, 1 }, { 12, 2 }, { 12, 3 }, { 12, 4 }, { 12, 5 }, { 12, 6 }, { 12, 7 }, { 12, 8 }, { 12, 9 }, { 12, 10 }, { 12, 11 }, { 13, 2 }, { 13, 3 }, { 13, 4 }, { 13, 7 }, { 13, 8 }, { 13, 9 }, { 14, 1 }, { 14, 2 }, { 14, 3 }, { 14, 8 }, { 14, 9 }, { 14, 10 } });
            shapes_coordinate.Add(2, new int[,] { { 0, 4 }, { 0, 5 }, { 0, 6 }, { 0, 7 }, { 0, 17 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 1, 6 }, { 1, 7 }, { 1, 8 }, { 1, 16 }, { 1, 17 }, { 1, 18 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 2, 7 }, { 2, 8 }, { 2, 9 }, { 2, 16 }, { 2, 17 }, { 2, 18 }, { 2, 19 }, { 3, 2 }, { 3, 3 }, { 3, 4 }, { 3, 5 }, { 3, 6 }, { 3, 7 }, { 3, 8 }, { 3, 9 }, { 3, 16 }, { 3, 17 }, { 3, 18 }, { 3, 19 }, { 4, 1 }, { 4, 2 }, { 4, 3 }, { 4, 4 }, { 4, 5 }, { 4, 6 }, { 4, 7 }, { 4, 8 }, { 4, 9 }, { 4, 10 }, { 4, 15 }, { 4, 16 }, { 4, 17 }, { 4, 18 }, { 4, 19 }, { 4, 20 }, { 5, 0 }, { 5, 1 }, { 5, 2 }, { 5, 3 }, { 5, 4 }, { 5, 5 }, { 5, 6 }, { 5, 7 }, { 5, 8 }, { 5, 9 }, { 5, 10 }, { 5, 15 }, { 5, 16 }, { 5, 17 }, { 5, 18 }, { 5, 19 }, { 5, 20 }, { 6, 0 }, { 6, 1 }, { 6, 2 }, { 6, 3 }, { 6, 4 }, { 6, 5 }, { 6, 6 }, { 6, 7 }, { 6, 8 }, { 6, 9 }, { 6, 10 }, { 6, 11 }, { 6, 15 }, { 6, 16 }, { 6, 17 }, { 6, 18 }, { 6, 19 }, { 6, 20 }, { 7, 0 }, { 7, 1 }, { 7, 2 }, { 7, 3 }, { 7, 4 }, { 7, 5 }, { 7, 6 }, { 7, 7 }, { 7, 8 }, { 7, 9 }, { 7, 10 }, { 7, 11 }, { 7, 16 }, { 7, 17 }, { 7, 18 }, { 7, 19 }, { 8, 1 }, { 8, 2 }, { 8, 3 }, { 8, 4 }, { 8, 5 }, { 8, 6 }, { 8, 7 }, { 8, 8 }, { 8, 9 }, { 8, 10 }, { 8, 11 }, { 8, 12 }, { 8, 16 }, { 8, 17 }, { 8, 18 }, { 9, 2 }, { 9, 3 }, { 9, 4 }, { 9, 5 }, { 9, 6 }, { 9, 7 }, { 9, 8 }, { 9, 9 }, { 9, 10 }, { 9, 11 }, { 9, 12 }, { 9, 13 }, { 9, 15 }, { 9, 16 }, { 9, 17 }, { 9, 18 }, { 10, 4 }, { 10, 5 }, { 10, 6 }, { 10, 7 }, { 10, 8 }, { 10, 9 }, { 10, 10 }, { 10, 11 }, { 10, 12 }, { 10, 13 }, { 10, 14 }, { 10, 15 }, { 10, 16 }, { 10, 17 }, { 11, 5 }, { 11, 6 }, { 11, 7 }, { 11, 8 }, { 11, 9 }, { 11, 10 }, { 11, 11 }, { 11, 12 }, { 11, 13 }, { 11, 14 }, { 11, 15 }, { 11, 16 }, { 11, 17 }, { 12, 5 }, { 12, 6 }, { 12, 7 }, { 12, 8 }, { 12, 9 }, { 12, 10 }, { 12, 11 }, { 12, 12 }, { 12, 13 }, { 12, 14 }, { 12, 15 }, { 12, 16 }, { 13, 4 }, { 13, 6 }, { 13, 7 }, { 13, 8 }, { 13, 9 }, { 13, 10 }, { 13, 11 }, { 13, 12 }, { 13, 13 }, { 13, 14 }, { 13, 15 }, { 14, 5 }, { 14, 6 }, { 14, 7 }, { 14, 8 }, { 14, 9 }, { 14, 10 }, { 14, 11 }, { 14, 12 }, { 14, 13 }, { 14, 14 } });
            shapes_coordinate.Add(3, new int[,] { { 0, 5 }, { 0, 6 }, { 0, 7 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 1, 6 }, { 1, 7 }, { 1, 8 }, { 1, 9 }, { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 2, 7 }, { 2, 8 }, { 2, 9 }, { 2, 10 }, { 3, 1 }, { 3, 2 }, { 3, 3 }, { 3, 4 }, { 3, 5 }, { 3, 6 }, { 3, 7 }, { 3, 8 }, { 3, 9 }, { 3, 10 }, { 4, 1 }, { 4, 7 }, { 4, 8 }, { 4, 9 }, { 4, 10 }, { 4, 11 }, { 5, 0 }, { 5, 8 }, { 5, 9 }, { 5, 10 }, { 5, 11 }, { 5, 12 }, { 5, 13 }, { 6, 0 }, { 6, 8 }, { 6, 9 }, { 6, 10 }, { 6, 11 }, { 6, 12 }, { 6, 13 }, { 6, 14 }, { 7, 1 }, { 7, 2 }, { 7, 3 }, { 7, 4 }, { 7, 5 }, { 7, 6 }, { 7, 7 }, { 7, 8 }, { 7, 9 }, { 7, 10 }, { 7, 11 }, { 7, 12 }, { 7, 13 }, { 7, 14 }, { 8, 1 }, { 8, 2 }, { 8, 3 }, { 8, 4 }, { 8, 5 }, { 8, 6 }, { 8, 7 }, { 8, 8 }, { 8, 9 }, { 8, 10 }, { 8, 11 }, { 8, 12 }, { 8, 13 }, { 8, 14 }, { 9, 1 }, { 9, 2 }, { 9, 3 }, { 9, 4 }, { 9, 5 }, { 9, 6 }, { 9, 7 }, { 9, 8 }, { 9, 9 }, { 9, 10 }, { 9, 11 }, { 9, 12 }, { 9, 13 }, { 9, 14 }, { 10, 1 }, { 10, 2 }, { 10, 3 }, { 10, 4 }, { 10, 5 }, { 10, 6 }, { 10, 7 }, { 10, 8 }, { 10, 9 }, { 10, 10 }, { 10, 11 }, { 10, 12 }, { 10, 13 }, { 10, 14 }, { 11, 1 }, { 11, 2 }, { 11, 3 }, { 11, 4 }, { 11, 5 }, { 11, 6 }, { 11, 7 }, { 11, 8 }, { 11, 9 }, { 11, 10 }, { 11, 11 }, { 11, 12 }, { 11, 13 }, { 12, 1 }, { 12, 2 }, { 12, 3 }, { 12, 4 }, { 12, 5 }, { 12, 6 }, { 12, 7 }, { 12, 8 }, { 12, 9 }, { 12, 10 }, { 12, 11 }, { 13, 1 }, { 13, 2 }, { 13, 3 }, { 13, 4 }, { 13, 8 }, { 13, 9 }, { 13, 10 }, { 13, 11 }, { 14, 2 }, { 14, 3 }, { 14, 9 }, { 14, 10 } });
            shapes_coordinate.Add(4, new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 7 }, { 0, 8 }, { 0, 9 }, { 1, 0 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 1, 6 }, { 1, 9 }, { 2, 1 }, { 2, 2 }, { 2, 4 }, { 2, 5 }, { 2, 7 }, { 2, 8 }, { 3, 2 }, { 3, 7 }, { 4, 2 }, { 4, 3 }, { 4, 5 }, { 4, 7 }, { 4, 8 }, { 4, 9 }, { 4, 10 }, { 4, 11 }, { 4, 12 }, { 5, 2 }, { 5, 6 }, { 5, 7 }, { 5, 9 }, { 5, 10 }, { 5, 11 }, { 5, 13 }, { 6, 2 }, { 6, 6 }, { 6, 7 }, { 6, 10 }, { 6, 11 }, { 6, 13 }, { 7, 2 }, { 7, 3 }, { 7, 4 }, { 7, 5 }, { 7, 6 }, { 7, 7 }, { 7, 13 }, { 7, 14 }, { 8, 3 }, { 8, 4 }, { 8, 5 }, { 8, 6 }, { 8, 9 }, { 8, 10 }, { 8, 12 }, { 8, 13 }, { 8, 14 }, { 8, 15 }, { 9, 4 }, { 9, 8 }, { 9, 9 }, { 9, 10 }, { 9, 12 }, { 9, 13 }, { 9, 14 }, { 9, 15 }, { 10, 4 }, { 10, 8 }, { 10, 9 }, { 10, 10 }, { 10, 13 }, { 10, 15 }, { 11, 4 }, { 11, 13 }, { 12, 5 }, { 12, 6 }, { 12, 7 }, { 12, 8 }, { 12, 9 }, { 12, 10 }, { 12, 11 }, { 12, 12 }, { 13, 5 }, { 13, 7 }, { 13, 10 }, { 13, 12 } });
           

        }

        // defining the variables
        const int BoardWidth = 59;
        const int BoardHeight = 25;
        const int RectSize = 20;
        const int CreationDelay = 100;
        bool isStart = false;
        DispatcherTimer dTimer;
        Rectangle[,] BoardRef;
        int LiveCells = 0;
        int shape_number = 1;

        // creating the grid for the game
        public void CreateBoard()
        {
            BoardRef = new Rectangle[BoardHeight, BoardWidth];
            for (int i = 0; i < BoardHeight; i++) // generating the cells using BoardHeight
            {
                for (int j = 0; j < BoardWidth; j++) //generating cells using BoardWidth
                {
                    if (i == 0 || i == BoardHeight - 1 || j == 0 || j == BoardWidth - 1) // if it's the border
                    {
                        // the border
                        Rectangle r = new Rectangle
                        {
                            Width = RectSize,
                            Height = RectSize,
                            Stroke = Brushes.LightGray,
                            StrokeThickness = 0.5,
                            Fill = Brushes.DimGray,
                        };
                        BoardRef[i, j] = r;
                        Canvas.SetLeft(r, j * RectSize);
                        Canvas.SetTop(r, i * RectSize);
                        cBoard.Children.Add(r);
                    }
                    else
                    {
                        // the grid/board of the area where the user can click on
                        CellModel Cell = new CellModel { State = false, Col = i, Ren = j };
                        Rectangle r = new Rectangle
                        {
                            Width = RectSize,
                            Height = RectSize,
                            Stroke = Brushes.Black,
                            StrokeThickness = 0.5,
                            Fill = Brushes.Black,
                            Tag = Cell
                        };
                        r.MouseDown += R_MouseDown;
                        BoardRef[i, j] = r;
                        Canvas.SetLeft(r, j * RectSize);
                        Canvas.SetTop(r, i * RectSize);
                        cBoard.Children.Add(r);
                    }
                }
            }
        }
        // running the game
        public void StartGame()
        {
            dTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, CreationDelay) };
            dTimer.Tick += DispatcherTimer_Tick;
            dTimer.Start();
            isStart = true;
        }

        // pausing the game 
        public void StopGame()
        {
            dTimer.Stop();
            isStart = false;
            btnReset.IsEnabled = true;
        }

        // resetting the all the cells inside the border 
        public void ResetGame()
        {
            foreach (var box in BoardRef)
            {
                if (box.Tag != null)
                {
                    var cell = (CellModel)box.Tag;
                    if (cell.State == true)
                    {
                        ChangeCellState(cell);
                    }
                }
            }
        }

        // changing the state of the cells, cell.state = true --> alive, cell.state = false --> not alive
        private void ChangeCellState(CellModel cell)
        {
            if (cell.State == false)
            {
                cell.State = true;
                BoardRef[cell.Col, cell.Ren].Fill = Brushes.White;
                LiveCells++;
            }
            else
            {
                cell.State = false;
                BoardRef[cell.Col, cell.Ren].Fill = Brushes.Black;
                LiveCells--;
                if (LiveCells == 0 && isStart == true)
                {
                    StopGame();
                }
            }
        }

        // the rules of the Game Of Life (Online)
        public void ApplyRules()
        {
            List<CellModel> CellsToChange = new List<CellModel>();
            foreach (var cellRectref in BoardRef)
            {
                List<CellModel> neighbours;
                if (cellRectref.Tag != null)
                {
                    var tempCell = (CellModel)cellRectref.Tag;
                    neighbours = GetNeighbours(tempCell);
                    int neighboursCount = neighbours.Count(x => x.State == true);

                    if (tempCell.State == true)
                    {
                        if (neighboursCount < 2 || neighboursCount > 3)
                        {
                            CellsToChange.Add(tempCell);
                        }
                    }
                    else
                    {
                        if (neighboursCount == 3)
                        {
                            CellsToChange.Add(tempCell);
                        }
                    }
                }
            }
            if (CellsToChange.Count != 0)
            {
                ChangeCells(CellsToChange);
            }
        }
        // to change the state of the specific cell
        private void ChangeCells(List<CellModel> cells)
        {
            foreach (var cell in cells)
            {
                ChangeCellState(cell);
            }
        }
        // codes of the game, to get the neighbours of the cells (Online)
        // so that the program knows whether the cell dies or not
        List<CellModel> GetNeighbours(CellModel cell)
        {
            List<CellModel> NeighboursList = new List<CellModel>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    var neighbour = BoardRef[cell.Col + i, cell.Ren + j];
                    if (neighbour.Tag != null)
                    {
                        var temp = (CellModel)neighbour.Tag;
                        if (temp.Col != cell.Col || temp.Ren != cell.Ren)
                        {
                            NeighboursList.Add(temp);
                        }
                    }
                }
            }
            return NeighboursList;
        }
        // mouse listener. (if game hasn't started yet and if user clicks on a cell, the cell becomes alive)
        private void R_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isStart == false)
            {
                var cell = (CellModel)(sender as Rectangle).Tag;
                ChangeCellState(cell);
            }
        }
        // if there are no alive cells left on the board, the game would stop running the rules of the game
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (LiveCells > 0)
            {
                ApplyRules();
            }
            else
            {
                dTimer.Stop();
            }
        }
        // the button for the Starting and Stopping the game, 2 in 1
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (isStart == false)
            {
                StartGame();
            }
            else
            {
                StopGame();
            }
        }
        // the button for resetting the cells on the board
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (isStart == false)
            {
                ResetGame();
            }
        }

        // "shape" button click
        private void btnShape_Click(object sender, RoutedEventArgs e)
        {
            if (isStart == false)
            {
                ResetGame();
                for (int i = 0; i < shapes_coordinate[shape_number].GetLength(0); i++)
                {
                    var cell = (CellModel)BoardRef[5 + shapes_coordinate[shape_number][i, 0], 23 + shapes_coordinate[shape_number][i, 1]].Tag;
                    ChangeCellState(cell);
                }
            }
            if (shape_number < 4)
            {
                shape_number++;
            }
            else
            {
                shape_number = 1;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateBoard();
        }
    }
}
