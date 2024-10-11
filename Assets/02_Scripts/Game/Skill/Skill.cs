using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Utilities;
using UnityEngine;

[System.Serializable]
public class SkilData
{

    public string name;
    //나중에 추가
}

public abstract class Skill : ScriptableObject
{

    [field:SerializeField] public SkilData Data { get; private set; }
    public abstract void Execute();

}