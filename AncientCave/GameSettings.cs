namespace AncientCave;

    public class GameSettings
    {
        public Display Display { get; set; }
        public Audio Audio { get; set; }
    }

    public class Display
    {
        public double Gamma { get; set; }
        public int Borderless { get; set; }
        public int Fullscreen { get; set; }
        public int SizeW { get; set; }
        public int SizeH { get; set; }
    }

    public class Audio
    {
        public int Master { get; set; }
        public int Music { get; set; }
        public int Effect { get; set; }
    }
