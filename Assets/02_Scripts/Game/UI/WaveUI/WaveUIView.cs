using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WaveUIController;

public class WaveUIView : UIView<WaveSetting, WaveUIEvent>
{
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _timeText;

    public override void Viewing(in WaveSetting model)
    {
        _waveText.text = $"{model.CurrentWave}";
        _timeText.text = $"{model.CurrentWave}";
    }
}
