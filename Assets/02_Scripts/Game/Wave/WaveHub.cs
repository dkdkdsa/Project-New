public delegate void StartWave(float waveTime);
public delegate void WaveEvent(int wave);

public static class WaveHub
{
    public static StartWave OnStartWave;
    public static WaveEvent OnWaveEvent;
}
