using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaveSetting))]
public class WaveSettingEditor : Editor
{
    private List<string> _waveNameData = new();
    private WaveSetting _target => target as WaveSetting;
    private int _index = 0;

    private void WaveUpdate()
    {
        _waveNameData.Clear(); // 중복 추가 방지
        for (int i = 0; i < _target.WaveData.Count; i++)
        {
            _waveNameData.Add($"{i + 1} 웨이브");
        }
    }

    public override void OnInspectorGUI()
    {
        SelectStartState();
    }

    private void SelectStartState()
    {
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("웨이브 지정");

        if (GUILayout.Button("Add"))
        {
            WaveData data = new();
            data.SpawnDatas.Add(new SpawnData());  // 기본 SpawnData 추가
            _target.WaveData.Add(data);

            EditorUtility.SetDirty(_target);  // 객체가 변경되었음을 알림
        }

        if (GUILayout.Button("Remove"))
        {
            if (_target.WaveData.Count > 0 && _index >= 0 && _index < _target.WaveData.Count)
            {
                _target.WaveData.RemoveAt(_index);  // 해당 인덱스의 WaveData 제거
                _waveNameData.RemoveAt(_index);     // 해당 인덱스의 웨이브 이름 제거

                // 인덱스가 마지막을 가리키고 있었다면 하나 줄여줌
                if (_index >= _waveNameData.Count)
                {
                    _index--;
                }

                EditorUtility.SetDirty(_target);  // 객체가 변경되었음을 알림
                Repaint();  // 인스펙터 다시 그리기
            }
        }

        WaveUpdate();  // 항상 최신 상태 유지

        _index = EditorGUILayout.Popup(_index, _waveNameData.ToArray());

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        // _index에 해당하는 WaveData의 SpawnData 출력
        if (_target.WaveData.Count > 0 && _index >= 0 && _index < _target.WaveData.Count)
        {
            EditorGUILayout.LabelField($"{_index + 1} 웨이브의 SpawnData");

            var waveData = _target.WaveData[_index];
            if (waveData.SpawnDatas != null && waveData.SpawnDatas.Count > 0)
            {
                foreach (var spawnData in waveData.SpawnDatas)
                {
                    spawnData.IsUnitSpawn = EditorGUILayout.Toggle("유닛 생성 여부", spawnData.IsUnitSpawn);
                    spawnData.Prefab = (Enemy)EditorGUILayout.ObjectField("유닛", spawnData.Prefab, typeof(Enemy), true);
                    spawnData.SpawnInterval = EditorGUILayout.FloatField("다음 이벤트간의 간격", spawnData.SpawnInterval);
                }
            }
            else
            {
                EditorGUILayout.LabelField("SpawnData가 없습니다.");
            }

            EditorUtility.SetDirty(_target);  // 변경 사항 반영
        }
    }
}
