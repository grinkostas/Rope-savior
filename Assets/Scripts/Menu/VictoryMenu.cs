using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryMenu : Menu
{
    [SerializeField]
    private TextMeshProUGUI _levelNameText;

    [SerializeField]
    private Level _level;
    

    public void OnLevelEnd(LevelResult levelResult)
    {
        if (levelResult == LevelResult.Victory)
            Show();
        else
            Hide();        
    }

    public void NextLevel()
    {
        _level.NextLevel();
    }

    public void Init(LevelConfig config)
    {
        _levelNameText.text = config.LevelName;
    }
}
