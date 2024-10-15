using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveUIController;

public class WaveModel
{
    public WaveModel(WaveSetting setting, WaveSystem system)
    {
        Setting = setting;
        System = system;
    }

    public readonly WaveSetting Setting;
    public readonly WaveSystem System;
}

public class WaveUIController : UIController<WaveModel, WaveUIView, ActionType>
{
    public enum ActionType : byte
    {
        Skip
    }

    public override void LocalInject(ComponentList list)
    {
        base.LocalInject(list);

        _view.RegisterEvent(ActionType.Skip, SkipUI);

        var target = GameObject.Find("WaveSystem");

        WaveSystem system = target.GetComponent<WaveSystem>();
        WaveSetting setting = target.GetComponent<WaveSetting>();

        _model = new WaveModel(setting, system);
    }

    /// <summary>
    /// 다음 웨이브로 이동하는 이벤트
    /// </summary>
    /// <param name="param"></param>
    private void SkipUI(object[] param)
    {
        _model.System.AllowWaveTransition();
    }

    private void OnEnable()
    {
        //웨이브가 시작될 때
        WaveHub.OnStartWave += UpdateUI;

        //웨이브를 스킵할 수 있을 때
        WaveHub.OnSkipEvent += _view.SkipPanel.ShowUI;
        WaveHub.OnSkipEvent += _view.WavePanel.SkipCoolTime;

        //웨이브가 끝났을 때
        WaveHub.OnEndWave   += _view.SkipPanel.HideUI;
    }

    private void OnDisable()
    {
        //웨이브가 시작될 때
        WaveHub.OnStartWave -= UpdateUI;

        //웨이브를 스킵할 수 있을 때
        WaveHub.OnSkipEvent -= _view.SkipPanel.ShowUI;
        WaveHub.OnSkipEvent -= _view.WavePanel.SkipCoolTime;

        //웨이브가 끝났을 때
        WaveHub.OnEndWave   -= _view.SkipPanel.HideUI;
    }

    /// <summary>
    /// 웨이브가 시작되면 UIView 업데이트
    /// </summary>
    private void UpdateUI()
    {
        _view.Viewing(_model);
    }
}