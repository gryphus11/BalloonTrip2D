using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneSwitcher {
    public static void ChangeSceneByPath(string scenePath)
    {
        int sceneBuildIndex = SceneUtility.GetBuildIndexByScenePath(scenePath);

        if (scenePath.ToUpper().Equals("EXIT"))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        if (sceneBuildIndex == -1)
        {
            Debug.Log("유효하지 않은 Scene");
        }
        else
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
