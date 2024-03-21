namespace AncientCave.ECS.Entities
{
    public enum ScreenMode
    {
        FullScreen,
        Windowed,
        Borderless
    }

    public class DisplayResolution
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    
    public class GameSettingEntity
    {
        public DisplayResolution Resolution { get; set; } = new DisplayResolution { Width = 1920, Height = 1080 };
        public ScreenMode ScreenMode { get; set; } = ScreenMode.FullScreen;
        public float MasterVolume { get; set; } = 1;
        public float EffectVolume { get; set; } = 1;
        public float MusicVolume { get; set; } = 1;
        public bool VSync { get; set; } = true;
    }
}