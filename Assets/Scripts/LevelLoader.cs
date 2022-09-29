using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;


    void Start ()
   {
        StartCoroutine(LoadAsynchronously(1)); // = INDEX of the scene to be loaded after initial loading screen
   }

   IEnumerator LoadAsynchronously (int sceneIndex)
   {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Debug.Log(progress);
            slider.value = progress;
            yield return null;
        }
   }

}
