public delegate void StartWave();
public delegate void EndWave();

public delegate void WaveEvent(int wave);
public delegate void SkipEvent();

public static class WaveHub
{
    public static StartWave OnStartWave;
    public static EndWave OnEndWave;

    public static WaveEvent OnWaveEvent;
    public static SkipEvent OnSkipEvent;
}
