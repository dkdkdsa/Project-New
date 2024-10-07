using UnityEngine;

/// <summary>
/// ILocalInject를 상속받은 겍체에게 의존성을 주입
/// </summary>
[RequireComponent(typeof(InstallerRunner))]
public class LocalInstaller : MuiltInstallerBase<ILocalInject>
{

    protected override void Inject(ILocalInject[] arr)
    {

        var compoList = new ComponentList(GetComponentsInChildren<Component>());

        foreach (var inj in arr)
        {

            inj.LocalInject(compoList);

        }

    }


}
