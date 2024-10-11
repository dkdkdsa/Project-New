using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WaveSystem : MonoBehaviour
{
    /// <summary>
    /// 웨이브를  실행해주는 로직
    /// </summary>
    /// <returns></returns>
    private IEnumerator OnWaveCoroutine()
    {
        while (_currentWave < _waveSetting.Wave)
        {
            WaveHub.OnStartWave?.Invoke(_waveSetting.WaveIntervalTime);

            yield return new WaitForSeconds(_waveSetting.WaveIntervalTime);
            yield return WaveEventCoroutine(_waveSetting.SpawnUnitCountInWave(_currentWave));
        }
    }

    /// <summary>
    /// WaveSetting에 맞춰 이벤트를 실행해주는 로직
    /// </summary>
    /// <param name="size">해당 Wave에 실행해야 할 웨이브의 개수</param>
    /// <returns></returns>
    private IEnumerator WaveEventCoroutine(int size)
    {
        int spawnIndex = 0;

        while (spawnIndex < size)
        {
            SpawnData spawnData = _waveSetting.GetSpawnData(_currentWave, spawnIndex);

            if (spawnData.IsUnitSpawn)
            {
                SpawnUnit(spawnIndex);
                yield return new WaitForSeconds(_waveSetting.DefaultSpawnTime);
            }
            else
            {
                TriggerWaveEvent();
                yield return new WaitForSeconds(spawnData.SpawnInterval);
            }

            spawnIndex++;
        }

        yield return CheckChangeWaveCoroutine();

        _waveSetting.CurrentWave++;
    }

    /// <summary>
    /// 조건 충족이 안되면 웨이브에 머물게 하는 로직
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckChangeWaveCoroutine()
    {
        while (!_canChangeWave)
        {
            yield return null;
        }

        _canChangeWave = false;
    }
}