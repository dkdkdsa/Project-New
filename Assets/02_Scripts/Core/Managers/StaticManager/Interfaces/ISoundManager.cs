using System;

public enum SoundPlayType
{
    Play2D,
    Play3D
}

/// <summary>
/// SoundManager의 추상형
/// </summary>
public interface ISoundManager : IManager
{

    /// <summary>
    /// 사운드를 재생
    /// </summary>
    /// <param name="soundKey">재생할 사운드의 key</param>
    /// <param name="volume">사운드의 볼륨</param>
    /// <param name="type">사운드 재생 타입</param>
    /// <returns>재생된 사운드의 키</returns>
    public Guid PlaySound(string soundKey, float volume, bool loop = false, SoundPlayType type = SoundPlayType.Play2D);

    /// <summary>
    /// 사운드를 멈춘다
    /// </summary>
    /// <param name="soundKey">사운드의 키</param>
    /// <returns>성공 여부</returns>
    public bool StopSound(Guid soundKey);

}
