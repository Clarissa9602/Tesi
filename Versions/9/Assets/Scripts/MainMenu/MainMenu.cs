using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //public GameObject playerPrefab;
    public GameObject sceneLoader;
    // Start is called before the first frame update
    
    public void Play(){
        sceneLoader.GetComponent<LoadingManager>().LoadLevel("Activity 1");
        //StartCoroutine(CreateNewData());
    }
    public void Quit()
    {
        //PlayerPrefs.DeleteKey("MusicVol");
        Application.Quit();

        // Esce dall'editor quando è in play
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
