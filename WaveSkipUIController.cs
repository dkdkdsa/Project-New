using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveSkipUIController;

public class WaveSkipUIController : UIController<WaveSystem, WaveSkipUIView, ActionType>
{
    public enum ActionType : byte
    {
        Skip
    }
}
