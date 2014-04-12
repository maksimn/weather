using System;

namespace WeatherRendering {
    // Класс, содержащий массив с диапазоном возможных температур:
    // Здесь температура принимает значение либо неопределенное ("не уст."),
    // либо значение в диапазоне -75 ... +75 град. Цельсия
    class TemperaturesRange {
        private String[] temperatures;
        public TemperaturesRange() {
            String celsiusDegree = '\u00b0' + "C";
            temperatures = new String[152];
            temperatures[0] = "не уст.";
            for (Int32 i = 1; i < 152; i++) {
                if (i < 76) {
                    temperatures[i] = (i - 76).ToString() + celsiusDegree;
                } else {
                    temperatures[i] = "+" + (i - 76).ToString() + celsiusDegree;
                }
            }
        }
        public String Get(Int32 i) {
            return temperatures[i];
        }
        public Int32 Size() {
            return temperatures.Length;
        }
    }
}
