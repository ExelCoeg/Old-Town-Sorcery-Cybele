using UnityEngine;
using System;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public Sound[] musicSounds,sfxSounds;
    public AudioSource musicSource,sfxSource;
    public AudioMixer audioMixer;
   
    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

    }
    private void Start() {
        PlayMusic("noon");
    }

    private void Update() {
        if(GameManager.instance.pause){
            audioMixer.SetFloat("music",-80);
        }
        else{
            audioMixer.SetFloat("music",0);
        }
    }
    
    public void PlayMusic(string name){
        audioMixer.SetFloat("music", -100);
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if(s == null){
            print("Sound not found");
        }
        else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "music", 1, 90));
    }
    public void PlaySFX(string name){
        Sound s = Array.Find(sfxSounds, x=>x.name == name);
        if(s == null){
            print("Sound not found");
        }
        else{
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }
}