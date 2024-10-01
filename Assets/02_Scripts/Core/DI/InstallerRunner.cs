using UnityEngine;

[DefaultExecutionOrder(-1)]
public class InstallerRunner : MonoBehaviour
{

    private void Awake()
    {

        var compo = GetComponentsInChildren<IInstaller>();

        foreach (var item in compo)
            item.StartInject();

    }

}