using UnityEngine;

/// <summary>
/// 움직이는 객체의 추상형
/// </summary>
public interface IMoveable
{

    /// <param name="vec">이동 벡터</param>
    /// <param name="speed">속도</param>
    public void Move(in Vector3 vec, in float speed);

}