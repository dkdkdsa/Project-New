using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveData
{
    public List<SpawnData> SpawnDatas = new();
}

[Serializable]
public class SpawnData
{
    public bool IsUnitSpawn = true;

    public Enemy Prefab;
    public float SpawnInterval;
}