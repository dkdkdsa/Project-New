public interface IHpable
{

    public delegate void HpChanged(float oldValue, float newValue);
    public event HpChanged OnHpChanged;
    public float Hp { get; }

}
