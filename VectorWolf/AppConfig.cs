namespace VectorWolf;

public class AppConfig
{
    public string Title { get; set; } = "VectorWolf Game";
    public int Width { get; set; } = 800;
    public int Height { get; set; } = 600;
    public bool IsFullScreen { get; set; } = false;
    public bool EnableVSync { get; set; } = true;
    public string AssetsRootDirectory { get; set; } = "Content";
}
