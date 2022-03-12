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
        UnityEditor.EditorApplication.isPlaying = false;
    }
    
    IEnumerator CreateNewData(){
        // Schermata di caricamento
        Debug.Log("Caricamento in corso...");
        sceneLoader.GetComponent<LoadingManager>().LoadLevel("Activity 1");
        while(!SceneManager.GetSceneByName("Activity 1").isLoaded){
                yield return null;
        }
        /*Istanzia per la prima volta il player alle coordinate specificate
        GameObject newPlayer = Instantiate(playerPrefab, new Vector3(200f, 200.16f, 251f),
                                                            Quaternion.Euler(0f, 90f, 0f));
        // Sposta il GameObject specificato (il player in questo caso) nella scena principale
        //SceneManager.MoveGameObjectToScene(newPlayer, SceneManager.GetSceneByBuildIndex(1))*/;
    }
}
