using System;
using System.IO;

namespace WeatherRendering {
    // Класс со значениями вводных данных
    class InputDataTable {
        private Int32[] cloudiness;
        private Int32[] temperature;
        public InputDataTable(Int32 n) {
            temperature = new Int32[n];
            cloudiness = new Int32[n];
        }
        public void ReadFile(String filename) {
            String s = File.ReadAllText(filename);
            String[] strArr = s.Split(new Char[2] { '\n', ' ' });
            for (int i = 0, j = 0; j < temperature.Length; i = i + 2, j++) {
                try {
                    temperature[j] = Convert.ToInt32(strArr[i]);
                    cloudiness[j] = Convert.ToInt32(strArr[i + 1]);
                } catch (Exception) {
                }
            }
        }
        public void Show() {
            String s = "";
            for (Int32 i = 0; i < temperature.Length; i++) { s = s + temperature[i].ToString() + " " + cloudiness[i] + "\n"; }
            System.Windows.MessageBox.Show(s);
        }
        public Int32 GetTemperatureIndex(Int32 i) {
            return temperature[i];
        }
        public Int32 GetCloudinessIndex(Int32 i) {
            return cloudiness[i];
        }
    }
}
