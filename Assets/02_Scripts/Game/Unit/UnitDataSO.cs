using UnityEngine;
using SharedData;

[CreateAssetMenu(menuName = "SO/Unit/Data")]
public class UnitDataSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite View { get; private set; }

}