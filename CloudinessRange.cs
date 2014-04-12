using System;

namespace WeatherRendering {   
    // Класс диапазоном возможных состояний облачности:
    class CloudinessRange {
        private String[] cloudiness;
        public CloudinessRange() {
            cloudiness = new String[8] { "не уст.", "Ясно", "Переменная облачность", "Облачно с прояснениями", "Облачно", "Туман", 
                "Дождь", "Снег" };
        }
        public String Get(Int32 i) {
            return cloudiness[i];
        }
        public Int32 Size() {
            return cloudiness.Length;
        }
    }
}
