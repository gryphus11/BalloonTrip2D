using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneChangeButton : MonoBehaviour {

    public void OnSceneChecngeButtonClick(string path)
    {
        CSceneSwitcher.ChangeSceneByPath(path);
    }
}
