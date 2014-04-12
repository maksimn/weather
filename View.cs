using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace WeatherRendering {
    class View {
        private Label[] dateLabel, dayOfWeekLabel;
        private ComboBox[] cloudinessComboBox, temperatureComboBox;
        public View(Int32 n) {
            dateLabel = new Label[n];
            dayOfWeekLabel = new Label[n];
            cloudinessComboBox = new ComboBox[n];
            temperatureComboBox = new ComboBox[n];
            for (Int32 i = 0; i < n; i++) {
                dateLabel[i] = new Label();
                dayOfWeekLabel[i] = new Label();
                cloudinessComboBox[i] = new ComboBox();
                temperatureComboBox[i] = new ComboBox();
            }
        }
        public void SetStyle(Style style) {
            for (Int32 i = 0; i < dateLabel.Length; i++) {
                dateLabel[i].Style = style;
                dayOfWeekLabel[i].Style = style;
                cloudinessComboBox[i].Style = style;
                temperatureComboBox[i].Style = style;
            }
        }
        public void SetPositionInGrid() {
            for (Int32 i = 0; i < dateLabel.Length; i++) {
                Grid.SetColumn(dateLabel[i], 0);
                Grid.SetRow(dateLabel[i], i);
                Grid.SetColumn(dayOfWeekLabel[i], 1);
                Grid.SetRow(dayOfWeekLabel[i], i);
                Grid.SetColumn(cloudinessComboBox[i], 2);
                Grid.SetRow(cloudinessComboBox[i], i);
                Grid.SetColumn(temperatureComboBox[i], 3);
                Grid.SetRow(temperatureComboBox[i], i);
            }
        }
        public void AddToGrid(Grid grid) {
            for (Int32 i = 0; i < dateLabel.Length; i++) {
                grid.Children.Add(dateLabel[i]);
                grid.Children.Add(dayOfWeekLabel[i]);
                grid.Children.Add(cloudinessComboBox[i]);
                grid.Children.Add(temperatureComboBox[i]);
            }
        }
        public void AddCloudinessRange(CloudinessRange cloudinessRange) {
            for (Int32 i = 0; i < dateLabel.Length; i++) {
                for (Int32 j = 0; j < cloudinessRange.Size(); j++) {
                    cloudinessComboBox[i].Items.Add(cloudinessRange.Get(j));
                }
            }
        }
        public void AddTemperatureRange(TemperaturesRange temperatureRange) {
            for (Int32 i = 0; i < dateLabel.Length; i++) {
                for (Int32 j = 0; j < temperatureRange.Size(); j++) {
                    temperatureComboBox[i].Items.Add(temperatureRange.Get(j));
                }
            }
        }
        public void AddDaysOfWeek() {
            dayOfWeekLabel[0].Content = "Понедельник";
            dayOfWeekLabel[1].Content = "Вторник";
            dayOfWeekLabel[2].Content = "Среда";
            dayOfWeekLabel[3].Content = "Четверг";
            dayOfWeekLabel[4].Content = "Пятница";
            dayOfWeekLabel[5].Content = "Суббота";
            dayOfWeekLabel[6].Content = "Воскресенье";
        }
        public void AddDates() {
            DateTime currDate = DateTime.Now.Date;
            DateTime beginningOfWeekDate;
            switch (currDate.DayOfWeek) {
                case DayOfWeek.Monday: beginningOfWeekDate = currDate; break;
                case DayOfWeek.Tuesday: beginningOfWeekDate = currDate.AddDays(-1); break;
                case DayOfWeek.Wednesday: beginningOfWeekDate = currDate.AddDays(-2); break;
                case DayOfWeek.Thursday: beginningOfWeekDate = currDate.AddDays(-3); break;
                case DayOfWeek.Friday: beginningOfWeekDate = currDate.AddDays(-4); break;
                case DayOfWeek.Saturday: beginningOfWeekDate = currDate.AddDays(-5); break;
                case DayOfWeek.Sunday: beginningOfWeekDate = currDate.AddDays(-6); break;
                default: beginningOfWeekDate = currDate; break;
            }
            for (Int32 i = 0; i < dateLabel.Length; i++) {
                dateLabel[i].Content = beginningOfWeekDate.AddDays(i).Date.ToString("d");
            }
        }
        public void GetData(InputDataTable input) {
            for (Int32 i = 0; i < dateLabel.Length; i++) {
                cloudinessComboBox[i].SelectedIndex = input.GetCloudinessIndex(i);
                temperatureComboBox[i].SelectedIndex = input.GetTemperatureIndex(i);
            }
        }
        public void SaveToFile(String filename) {
            String s1, s2, s = "";
            for (Int32 i = 0; i < dateLabel.Length; i++) {
                s1 = temperatureComboBox[i].SelectedIndex.ToString();
                s2 = cloudinessComboBox[i].SelectedIndex.ToString();
                s = s + s1 + " " + s2 + "\n";
            }
            File.WriteAllText(filename, s);
        }
    }
}
