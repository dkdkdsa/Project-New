public interface IController
{

    /// <summary>
    /// 활성화 여부
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Update와 동일
    /// </summary>
    public void Control(params object[] param);

}