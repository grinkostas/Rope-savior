using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwticher : MonoBehaviour
{
    [SerializeField]
    private LevelConfig _levelToTest;

    [SerializeField]
    private List<LevelConfig> _levels;

    [SerializeField]
    private LevelConfig _currentConfig = null;

    private Level _currentLevel = null;
   
    private const string LastLevelNamePref = "LastLevelName";

    private void Start()
    {
#if UNITY_EDITOR
        if (_levelToTest != null)
        {
            LoadLevel(_levelToTest);
            return;
        }
#endif
        LoadLastLevel();
    }

    private void LoadLastLevel()
    {
    #if UNITY_EDITOR
        if (_levelToTest != null)
        {
            LoadLevel(_levelToTest);
            return;
        }
    #endif

        string levelName = PlayerPrefs.GetString(LastLevelNamePref);
        if (string.IsNullOrEmpty(levelName) && _levels.Count > 0)
        {
            LoadLevel(_levels[0]);
            return;
        }

        var level = _levels.Find(x=> x.LevelName == levelName);

        if (level == null)
        {
            LoadLevel(_levels[0]);
            return;
        }

        LoadLevel(level);
    }

    private void LoadLevel(LevelConfig config)
    {        

        if (_currentLevel != null)        
            Destroy(_currentLevel.gameObject);

        _currentConfig = config;
        _currentLevel = Instantiate(config.Level);
        _currentLevel.Init(this, config);

        PlayerPrefs.SetString(LastLevelNamePref, config.LevelName);
    }

    public void NextLevel()
    {
        if (_currentConfig.NextLevel != null)
        {
            LoadLevel(_currentConfig.NextLevel);
        }
        else
        {
            Debug.Log("Last Level");
        }
    }
}


