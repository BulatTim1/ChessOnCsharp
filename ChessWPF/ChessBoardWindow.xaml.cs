using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChessCore;

namespace ChessWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChessBoardWindow : Window
    {
        Gameboard board;
        int activeX = -1, activeY = -1;
        bool activeFigure = false;

        List<Label> labels;
        
        public ChessBoardWindow()
        {
            InitializeComponent();
            board = new Gameboard();
            labels = new List<Label>();
        }

        // !!! Col - X, Row - Y

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var row = 8 - Grid.GetRow((Rectangle)sender) - 1; //first row and col - labels
            var col = Grid.GetColumn((Rectangle)sender) - 1;

            // 0 - left, 1 - right
            bool LeftButton = false;

            if (e.LeftButton == MouseButtonState.Pressed) LeftButton = true;
            else if (e.RightButton != MouseButtonState.Pressed) return;
            
            bool hasFigure = board.HasFigure(col, row);
            
            if (hasFigure)
            {
                if (LeftButton && activeFigure && col == activeX && row == activeY)
                {
                    activeFigure = false;
                    ResetBoard();
                }
                else if (LeftButton)
                {
                    ResetBoard();
                    activeX = col;
                    activeY = row;
                    activeFigure = true;
                    
                    var possibleMoves = board.GetPossibleMoves(col, row);
                    var rect = (Rectangle) FindName("point" + col + row);
                    rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                    
                    foreach (var move in possibleMoves)
                    {
                        rect = (Rectangle) FindName("point" + move[0] + move[1]); //first col (X), after row (Y)
                        rect.Style = (Style) this.Resources["PointPossibleMove"];
                    }
                }
                else if (!LeftButton)
                {
                    board.DelFigure(col, row);
                    foreach(var label in labels)
                    {
                        if (7 - row == Grid.GetRow(label) && col + 1 == Grid.GetColumn(label))
                        {
                            Board.Children.Remove(label);
                            labels.Remove(label);
                            break;
                        }
                    }
                    ResetBoard();
                }
            }
            else 
            {
                if (LeftButton && !activeFigure)
                {
                    var type = (ComboBox)FindName("SelectedFigure");
                    string typeFigure;
                    try 
                    { 
                        typeFigure = ((TextBlock)type.SelectedValue).Text;
                    } catch
                    {
                        return;
                    }

                    var label = new Label
                    {
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        Content = typeFigure,
                        Visibility = Visibility.Visible
                    };
                    Grid.SetColumn(label, col + 1);
                    Grid.SetRow(label, 8 - (row + 1));
                    labels.Add(label);
                    Board.Children.Add(label);

                    var data = new FiguresData
                    {
                        Name = typeFigure,
                        Data = new Dictionary<string, int>
                    {
                        { "X", col },
                        { "Y", row }
                    }
                    };

                    board.AddFigure(col, row, FigureFab.Make(data));
                }
                else if (LeftButton && activeFigure)
                {
                    var rect = (Rectangle)FindName("point" + col + row);
                    if(rect.Style == (Style)this.Resources["PointPossibleMove"] && 
                        board.Move(activeX, activeY, col, row))
                    {
                        foreach (var label in labels)
                        {
                            if (activeX + 1 == Grid.GetColumn(label) && 7 - activeY == Grid.GetRow(label))
                            {
                                Grid.SetColumn(label, col + 1);
                                Grid.SetRow(label, 7 - row);
                                break;
                            }
                        }
                        
                        ResetBoard();
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var label in labels)
            {
                Board.Children.Remove(label);
            }

            activeFigure = false;

            InitializeComponent();
            board = new Gameboard();
            labels = new List<Label>();
        }

        private void ResetBoard()
        {
            activeFigure = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var rect = (Rectangle)FindName("point" + j + i);
                    rect.Stroke = null;
                    if ((i + j) % 2 == 0)
                    {
                        rect.Style = (Style)Resources["PointBlack"];
                    } 
                    else
                    {
                        rect.Style = (Style)Resources["PointWhite"];
                    }
                }
            }
        }
    }
}
