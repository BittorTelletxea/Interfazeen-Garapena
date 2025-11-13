using _3UDBittor.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _3UDBittor.Views.Components
{
    public partial class EserlekuControl : UserControl
    {
        public EserlekuControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<Seat> Seats
        {
            get => (ObservableCollection<Seat>)GetValue(SeatsProperty);
            set => SetValue(SeatsProperty, value);
        }

        public static readonly DependencyProperty SeatsProperty =
            DependencyProperty.Register(nameof(Seats),
                typeof(ObservableCollection<Seat>),
                typeof(EserlekuControl),
                new PropertyMetadata(null));

        public int Columns
        {
            get => (int)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register(nameof(Columns),
                typeof(int),
                typeof(EserlekuControl),
                new PropertyMetadata(6));

        public ICommand SeatClickCommand
        {
            get => (ICommand)GetValue(SeatClickCommandProperty);
            set => SetValue(SeatClickCommandProperty, value);
        }

        public static readonly DependencyProperty SeatClickCommandProperty =
            DependencyProperty.Register(nameof(SeatClickCommand),
                typeof(ICommand),
                typeof(EserlekuControl),
                new PropertyMetadata(null));
    }
}
