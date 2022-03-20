using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingManager: MonoBehaviour
{
    public static LoadingManager Instance;

    public GameObject loadingScreen;
    public float MinLoadTime;
    public Slider slider;

    public Text progressText;
    private int progress;

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        progress = 0;
    }
    
    public void LoadLevel(string sceneName)
    {
        Debug.Log("Nome scena: "+sceneName);
        StartCoroutine(LoadAsynchronously(sceneName));
    }
    IEnumerator LoadAsynchronously(string sceneName){
        loadingScreen.SetActive(true);

        float elapsedLoadTime = 0f;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        while (!operation.isDone)
        {
            elapsedLoadTime += Time.deltaTime;
            yield return null;
        }
        while(elapsedLoadTime < MinLoadTime){
            elapsedLoadTime += Time.deltaTime;
            progress = (int)Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100 + "%";
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
