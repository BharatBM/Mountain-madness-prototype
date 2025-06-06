using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;
    public static LevelLoader instance;
    public void LoadLevel(int SceneIndex)

    {
        StartCoroutine(LoadAsynchronously(SceneIndex));
    }

IEnumerator LoadAsynchronously (int sceneIndex)
{
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    
    loadingScreen.SetActive(true);

    while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
}

 
}
