using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TowerUpgrader))]
public class TowerUpgradeEditor : Editor
{

    private int _levelSelectIdx;
    private TowerUpgrader _target => target as TowerUpgrader;
    private UnitDataSO _data => _target.GetComponent<TowerBase>().Data;
    private StatUpgradeData<int, float> _current => _target.Datas.Count <= 0 ? null : _target.Datas[_levelSelectIdx];
    private TowerValueContainer _value => _target.GetComponent<TowerValueContainer>();
    private Rect _start, _end;

    private void OnEnable()
    {
        
        _levelSelectIdx = 0;

    }

    public override void OnInspectorGUI()
    {

        if (!CheckUnitSetting())
        {

            EditorGUILayout.LabelField("타워가 올바르게 설정되어있지 않습니다 타워의 필수 구성요소를 추가해주세요");

            return;

        }

        _start = EditorGUILayout.GetControlRect();
        TowerNameLabel();
        Line(Color.black);
        EditorGUILayout.Space();
        LevelSelect();
        AddLevel();
        RemoveLevel();
        if (_current == null)
            return;
        EditorGUILayout.Space();
        SetCost();
        ShowData();

        _end = EditorGUILayout.GetControlRect();

    }

    private void RemoveLevel()
    {

        if(GUILayout.Button("레벨 삭제"))
        {

            _target.Datas.Remove(_current);
            _levelSelectIdx = 0;

        }

    }

    private void SetCost()
    {

        _current.cost = EditorGUILayout.IntField("레벨업 비용 : ", _current.cost);

    }

    private void ShowData()
    {

        if (_current == null || _current.datas.Count != _value.FloatStats.Count)
        {

            foreach(var item in _value.FloatStats)
            {

                if (_current.datas.Find(x => x.statKey == item.name.GetHash()) == null)
                {

                    _current.datas.Add(new StatControlData<int, float> { statKey = item.name.GetHash(), });

                }

            }

            List<StatControlData<int, float>> removed = new();

            foreach(var item in _current.datas)
            {

                bool non = true;
                foreach (var f in _value.FloatStats)
                {

                    if(f.name.GetHash() == item.statKey)
                    {
                        non = false; 
                        break;
                    }

                }

                if (non)
                    removed.Add(item);
            }

            foreach (var item in removed)
                _current.datas.Remove(item);

        }

        for(int i = 0; i < _value.FloatStats.Count; i++)
        {

            var stat = _value.FloatStats[i];
            
            float m = 0;
            for (int j = 0; j < _levelSelectIdx; j++)
            {
                m += _target.Datas[j].datas.Find(x => x.statKey == stat.name.GetHash()).modify;
            }

            EditorGUILayout.BeginHorizontal();
            var mod = _current.datas.Find(x => x.statKey == stat.name.GetHash()).modify;
            EditorGUILayout.LabelField($"{stat.name} : {stat.stat.Value + m}", GUILayout.MaxWidth(150));
            mod = EditorGUILayout.FloatField($"추가 량(결과 : {stat.stat.Value + mod + m} ) : ", mod);
            _current.datas.Find(x => x.statKey == stat.name.GetHash()).modify = mod;

            EditorGUILayout.EndHorizontal();

        }

    }

    private void AddLevel()
    {

        if (GUILayout.Button("레벨 추가"))
        {

            var obj = new StatUpgradeData<int, float>();
            _target.Datas.Add(obj);
            foreach (var item in _value.FloatStats)
            {

                if (obj.datas.Find(x => x.statKey == item.name.GetHash()) == null)
                {

                    obj.datas.Add(new StatControlData<int, float> { statKey = item.name.GetHash(), });

                }

            }

        }

    }

    private void LevelSelect()
    {

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("레벨 선택 : ");

        var levelList = new List<string>();

        int i = 0;
        foreach(var t in _target.Datas)
        {

            i++;
            levelList.Add($"레벨{i}");

        }

        _levelSelectIdx = EditorGUILayout.Popup(_levelSelectIdx, levelList.ToArray());

        EditorGUILayout.EndHorizontal();

    }

    private void TowerNameLabel()
    {

        string str = $"타워 : {_data.Name}";

        var labelStyle = new GUIStyle(EditorStyles.label);
        labelStyle.alignment = TextAnchor.UpperCenter;
        labelStyle.fontSize = 16;
        labelStyle.fontStyle = FontStyle.Bold;
        EditorGUI.LabelField(_start, str, labelStyle);

    }

    private void Line(Color color)
    {

        var rt = EditorGUILayout.GetControlRect();
        EditorGUI.DrawRect(rt, color);

    }

    private bool CheckUnitSetting()
    {

        var compo = _target.GetComponent<TowerBase>();

        return compo != null && compo.Data != null;

    }

}