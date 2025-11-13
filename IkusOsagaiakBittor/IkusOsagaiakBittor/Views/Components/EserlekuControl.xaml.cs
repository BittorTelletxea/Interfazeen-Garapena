using IkusOsagaiakBittor.Models;
using IkusOsagaiakBittor.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IkusOsagaiakBittor.Views.Components
{
    public partial class EserlekuControl : UserControl
    {
        public EserlekuControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<Seat> SeatItems
        {
            get => (ObservableCollection<Seat>)GetValue(SeatItemsProperty);
            set => SetValue(SeatItemsProperty, value);
        }

        public static readonly DependencyProperty SeatItemsProperty =
            DependencyProperty.Register(
                nameof(SeatItems),
                typeof(ObservableCollection<Seat>),
                typeof(EserlekuControl),
                new PropertyMetadata(new ObservableCollection<Seat>())
            );

        public int GridColumns
        {
            get => (int)GetValue(GridColumnsProperty);
            set => SetValue(GridColumnsProperty, value);
        }

        public static readonly DependencyProperty GridColumnsProperty =
            DependencyProperty.Register(
                nameof(GridColumns),
                typeof(int),
                typeof(EserlekuControl),
                new PropertyMetadata(6)
            );

        public ICommand OnSeatClick
        {
            get => (ICommand)GetValue(OnSeatClickProperty);
            set => SetValue(OnSeatClickProperty, value);
        }

        public static readonly DependencyProperty OnSeatClickProperty =
            DependencyProperty.Register(
                nameof(OnSeatClick),
                typeof(ICommand),
                typeof(EserlekuControl),
                new PropertyMetadata(null)
            );
    }
}
