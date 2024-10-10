using UnityEngine;

public class PositionMove : MonoBehaviour, IMoveable
{
    public void Move(in Vector3 vec, in float speed)
    {
        transform.Translate(vec * Time.deltaTime * speed);
    }

}
