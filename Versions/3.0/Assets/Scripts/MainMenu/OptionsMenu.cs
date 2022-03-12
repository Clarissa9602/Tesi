using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu Instance;
    public AudioSource audioSource;
    private float musicVolume = 1f;
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }
    public void UpdateVolume(float volume)
    {
            musicVolume = volume;
    }
}
