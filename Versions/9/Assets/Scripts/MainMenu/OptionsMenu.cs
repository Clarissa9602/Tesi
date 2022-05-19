using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//[RequireComponent(typeof(Toggle))]
public class OptionsMenu : MonoBehaviour
{
    //public static OptionsMenu Instance;
    public AudioSource audioSource;
    private Toggle myToggle;
    private float musicVolume = 1f;
    bool done;
    void Awake(){
        /*if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }*/
        myToggle = GetComponent<Toggle>();
        if(audioSource.volume == 0){
            myToggle.isOn = false;
            done = true;
        }
    }
    private void Start(){
        audioSource.Play();
    }
    public void StopAudio(){
       AudioListener.pause = !done; 
       Debug.Log("Done" + done);
    }
    private void Update(){
        audioSource.volume = musicVolume;
    }
    public void UpdateVolume(float volume){
        musicVolume = volume;
    }
    public void ToggleAudioOnValueChange(bool audioIn){
        if(audioIn){ 
            AudioListener.volume = 1;
        }
        else{
            AudioListener.volume = 0;
        }
    }
}
