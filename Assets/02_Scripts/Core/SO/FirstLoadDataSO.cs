using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "SO/FirstLoad")]
public class FirstLoadDataSO : ScriptableObject
{

    public List<AssetLabelReference> labels;

}