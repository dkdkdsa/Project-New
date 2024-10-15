using System.Collections.Generic;
using Unity.Services.CloudSave;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(WaveSetting))]
public class WaveSettingEditor : Editor
{
    private List<string> _waveNameData = new();
    private WaveSetting _target => target as WaveSetting;
    private int _index = 0;

    private ReorderableList _list;

    private void WaveUpdate()
    {
        _waveNameData.Clear(); // 중복 추가 방지

        for (int i = 0; i < _target.WaveData.Count; i++)
        {
            _waveNameData.Add($"{i + 1} 웨이브");
        }
    }

    private void InitializeReorderableList()
    {
        if (_index >= 0 && _index < _target.WaveData.Count)
        {
            // ReorderableList 초기화
            _list = new ReorderableList(serializedObject, serializedObject.FindProperty("WaveData").GetArrayElementAtIndex(_index).FindPropertyRelative("SpawnDatas"), true, true, true, true);

            _list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = _list.serializedProperty.GetArrayElementAtIndex(index);
                bool isUnitSpawn = element.FindPropertyRelative("IsUnitSpawn").boolValue;
                rect.y += 2;

                EditorGUI.PropertyField(new Rect(rect.x + 5, rect.y, 60, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("IsUnitSpawn"), GUIContent.none);

                if (isUnitSpawn)
                {
                    EditorGUI.PropertyField(new Rect(rect.x + 30, rect.y, rect.width - 35, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("Prefab"), GUIContent.none);
                }
                else
                {
                    EditorGUI.PropertyField(new Rect(rect.x + 30, rect.y, rect.width - 35, EditorGUIUtility.singleLineHeight),
                        element.FindPropertyRelative("SpawnInterval"), GUIContent.none);
                }
            };
        }
    }

    public override void OnInspectorGUI()
    {
        WaveUpdate();

        EditorGUILayout.Space();
        GUIStyle boldStyle = new GUIStyle(EditorStyles.label)
        {
            fontStyle = FontStyle.Bold // 진한 스타일 설정
        };

        // 진한 텍스트 출력
        EditorGUILayout.LabelField("[ Default Settings ]", boldStyle);

        EditorGUILayout.Space();

        _target.WaveStartTime = EditorGUILayout.FloatField("웨이브 간의 시간 간격 :", _target.WaveStartTime);
        _target.DefaultSpawnInterval = EditorGUILayout.FloatField("유닛의 기본 생성 시간 :", _target.DefaultSpawnInterval);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("마지막 유닛 생성으로부터 스킵이 가능한 시간 :");
        _target.Skippabletime = EditorGUILayout.FloatField(_target.Skippabletime);

        EditorGUILayout.LabelField("마지막 유닛 생성으로부터 강제로 스킵이 되는 시간 :");
        _target.TimeToSkip = EditorGUILayout.FloatField(_target.TimeToSkip);

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("웨이브 지정");

        if (GUILayout.Button("Add"))
        {
            WaveData data = new();
            data.SpawnDatas.Add(new SpawnData());  // 기본 SpawnData 추가
            _target.WaveData.Add(data);

            // ApplyModifiedProperties로 serializedObject를 업데이트
            serializedObject.Update();
            EditorUtility.SetDirty(_target);  // 객체가 변경되었음을 알림
            WaveUpdate(); // Update the wave name list

            _index = _target.WaveData.Count - 1; // Select the newly added wave

            // 새 데이터를 추가한 후 다시 ReorderableList 초기화
            InitializeReorderableList();
        }

        if (GUILayout.Button("Remove"))
        {
            if (_target.WaveData.Count > 0 && _index >= 0 && _index < _target.WaveData.Count)
            {
                _target.WaveData.RemoveAt(_index);  // 해당 인덱스의 WaveData 제거

                // 인덱스가 마지막을 가리키고 있었다면 하나 줄여줌
                if (_index >= _waveNameData.Count)
                {
                    _index--;
                }

                // Update the serialized object after removing an element
                serializedObject.Update();
                EditorUtility.SetDirty(_target);  // 객체가 변경되었음을 알림
                WaveUpdate();  // Update wave names

                // 데이터가 남아 있을 경우에만 ReorderableList 초기화
                if (_waveNameData.Count > 0)
                {
                    InitializeReorderableList();
                }
                else
                {
                    _list = null;  // 모든 데이터를 제거한 경우 _list를 null로 설정
                }

                serializedObject.ApplyModifiedProperties();  // Apply changes to the serialized object
                Repaint();  // 인스펙터 다시 그리기
            }
        }

        _index = EditorGUILayout.Popup(_index, _waveNameData.ToArray());

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        serializedObject.Update();

        if (_index >= 0 && _index < _target.WaveData.Count)
        {
            var waveData = _target.WaveData[_index];            

            if (_list == null || _list.count != waveData.SpawnDatas.Count)
            {
                InitializeReorderableList();
            }

            _list.DoLayoutList();
        }

        serializedObject.ApplyModifiedProperties();
    }
}