using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveUIController;

public class WaveUIController : UIController<WaveSetting, WaveUIView, WaveUIEvent>
{
    public enum WaveUIEvent : byte
    {
        Update
    }
}