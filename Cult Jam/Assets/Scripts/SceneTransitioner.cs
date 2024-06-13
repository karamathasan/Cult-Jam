using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public static SceneTransitioner Instance;
    private void Start()
    {
        
    }

    public void ChangeScene(int sceneBuildIndex)
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneBuildIndex));
        Debug.Log(SceneManager.GetSceneByBuildIndex(sceneBuildIndex).name);
    }
}
