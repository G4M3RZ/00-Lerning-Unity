using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    List<GameObject> _settings;

    private void Start()
    {
        _settings = new List<GameObject>();

        bool firstSetting = true;
        for (int i = 1; i < transform.childCount; i++)
        {
            _settings.Add(transform.GetChild(i).gameObject);
            _settings[i - 1].SetActive(firstSetting);
            firstSetting = false;
        }
    }

    public void SwitchSettings(int settingNum)
    {
        foreach (GameObject setting in _settings)
            setting.SetActive(false);

        _settings[settingNum].SetActive(true);
    }
}