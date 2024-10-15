using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WaveUIController;

public class WaveUIView : UIView<WaveModel, ActionType>
{
    [SerializeField] private WaveUIPanel _wavePanel;
    [SerializeField] private WaveSkipUIPanel _skipPanel;

    public WaveUIPanel WavePanel => _wavePanel;
    public WaveSkipUIPanel SkipPanel => _skipPanel;

    public override void Viewing(in WaveModel model)
    {
        _wavePanel.SetUp(model.Setting);
        _skipPanel.SetUp(this);
    }
}