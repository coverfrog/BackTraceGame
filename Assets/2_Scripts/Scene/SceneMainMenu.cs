using System;
using System.Collections;
using Cf.CSteam;
using UnityEngine;

public sealed class SceneMainMenu : SceneHandler
{
    [Header("UI")]
    [SerializeField] private UIModeSelector modeSelector;

    public override IEnumerator Start()
    {
        modeSelector.Init(this);
        
        return base.Start();
    }
}
