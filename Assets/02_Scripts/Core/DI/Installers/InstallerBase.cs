using UnityEngine;

public abstract class InstallerBase<T> : MonoBehaviour, IInstaller
{
    public void StartInject()
    {
        Inject(GetComponent<T>());
    }

    /// <summary>
    /// 의존성을 주입
    /// </summary>
    /// <param name="target"></param>
    protected abstract void Inject(T target);

}
