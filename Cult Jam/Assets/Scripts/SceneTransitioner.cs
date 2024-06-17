using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public static SceneTransitioner Instance;
    [SerializeField]
    private GameObject canvas;

    private void Start()
    {
        Application.targetFrameRate = 60;
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this);
        }
    }

    public void ChangeScene(int sceneBuildIndex)
    {
        int oldSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
        StartCoroutine(delayTransition(sceneBuildIndex, oldSceneIndex));
    }

    IEnumerator delayTransition(int sceneBuildIndex, int oldSceneIndex)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneBuildIndex);
        //SceneManager.UnloadSceneAsync(oldSceneIndex);
    }

    public void PlayNext()
    {
        // check for final scene
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else Application.Quit();
    }

    public bool NextExits()
    {
        return SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings;
    }


}
