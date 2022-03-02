using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameLoading : MonoBehaviour
{
    [SerializeField]
    GameObject loadingScene;
    [SerializeField]
    Slider sliderLoading;
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(Loading(sceneIndex));
    }
    IEnumerator Loading(int sceneIndex)
    {
        loadingScene.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            sliderLoading.value = progress;
            yield return null;
        }
    }
}
