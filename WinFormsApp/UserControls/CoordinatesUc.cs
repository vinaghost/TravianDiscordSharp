using MainCore.Models;

namespace WinFormsApp.UserControls
{
    public partial class CoordinatesUc : UserControl
    {
        public CoordinatesUc()
        {
            InitializeComponent();
        }

        public Coordinates Coordinates => new((int)NumericX.Value, (int)NumericY.Value);

        public void SetValue(int x, int y)
        {
            NumericX.Value = x;
            NumericY.Value = y;
        }
    }
}