using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WeatherRendering {
    public partial class MainWindow : Window {
        private String dataFileName = "weather.dat";
        private Int32 numOfDays = 7;
        private InputDataTable inputData;
        private View view;

        public MainWindow() {
            InitializeComponent();
            try {
                inputData = new InputDataTable(numOfDays);
                inputData.ReadFile(dataFileName);

                view = new View(numOfDays);
                view.SetStyle(this.FindResource("DayLabelStyle") as Style);
                view.SetPositionInGrid();
                view.AddToGrid(mainGrid);
                view.AddDates();
                view.AddDaysOfWeek();
                view.AddCloudinessRange(new CloudinessRange());
                view.AddTemperatureRange(new TemperaturesRange());
                view.GetData(inputData);
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }            
        }

        // Event Handlers:
        private void windowLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e) {
            this.Close();
        }

        private void hideWindowButton_Clicked(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void MainWindowClosedEventHandler(object sender, EventArgs e) {
            try {
                view.SaveToFile(dataFileName);
            } catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }            
        }
    }
}
