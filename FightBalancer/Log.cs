using Newtonsoft.Json;

namespace FightBalancer
{
    public class Log
    {
        public int? Min { get; set; }
        public int? Max { get; set; }
        public int Sum { get; set; }
        public int Avg => Count != 0 ? Sum / Count : 0;
        [JsonIgnore]
        private int Count { get; set; }

        public void Add(int value)
        {
            if (Min == null || value < Min)
                Min = value;
            if (Max == null || value > Max)
                Max = value;
            Sum += value;
            Count++;
        }
    }
}
