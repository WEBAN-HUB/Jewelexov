using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider LoadingBar;
    public static string nextScene;
    AsyncOperation AOp;
    float timer = 0.0f;
    float faketime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string nextSceneName;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }


    IEnumerator LoadScene()
    {
        yield return null;

        AOp = SceneManager.LoadSceneAsync(nextScene);
        AOp.allowSceneActivation = false;

        timer = 0.0f;
        while (!AOp.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (AOp.progress >= 0.9f)
            {
                LoadingBar.value = Mathf.Lerp(LoadingBar.value, 1.0f, timer);

                if (LoadingBar.value == 1.0f)
                {
                    faketime += Time.deltaTime;
                    if (faketime >= 0.8f)
                    {
                        AOp.allowSceneActivation = true;
                        if (nextScene == "SceneTitle")
                        {

                        }
                        else
                        {
                            SceneManager.LoadScene("UIPlaying", LoadSceneMode.Additive);
                        }
                    }
                }
            }
            else
            {
                LoadingBar.value = Mathf.Lerp(LoadingBar.value, AOp.progress, timer);
                if (LoadingBar.value >= AOp.progress)
                {
                    timer = 0.0f;
                }
            }
        }
    }
}
