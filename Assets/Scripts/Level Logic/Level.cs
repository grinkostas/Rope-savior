using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField]
    private StateMachine _stateMachine;

    [SerializeField]
    private LevelConfig _currentConfig;

    private LevelSwticher _levelSwitcher;

    public void Init(LevelSwticher levelSwitcher, LevelConfig levelConfig)
    {
        _levelSwitcher = levelSwitcher;
        _currentConfig.Init(levelConfig);
        _stateMachine.StartMachine();
    }
  
    public void NextLevel()
    {
        _levelSwitcher.NextLevel(); 
    }


}
