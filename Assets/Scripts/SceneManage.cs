using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject nextScene;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            StartCoroutine(WaitButton());
        }
    }

    private IEnumerator WaitButton()
    {
        yield return new WaitForSeconds(2f);
        nextScene.SetActive(true);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
