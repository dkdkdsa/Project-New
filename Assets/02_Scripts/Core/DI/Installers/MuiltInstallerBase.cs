using UnityEngine;

public abstract class MuiltInstallerBase<T> : MonoBehaviour, IInstaller
{

    /// <summary>
    /// 의존성 주입을 시작하는 부분
    /// </summary>
    public virtual void StartInject()
    {

        Inject(GetComponentsInChildren<T>());

    }

    /// <summary>
    /// 의존성을 주입
    /// </summary>
    /// <param name="targets"></param>
    protected abstract void Inject(T[] targets);

}

public interface IInstaller
{

    public void StartInject();

}