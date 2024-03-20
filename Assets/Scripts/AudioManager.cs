using UnityEngine;
using System;
public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public Sound[] musicSounds,sfxSounds;
    public AudioSource musicSource,sfxSource;
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
   
    public void PlayMusic(string name){
        Sound s = Array.Find(musicSounds,x=>x.name == name);
        if(s == null){
            print("Sound not found");
        }
        else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        FadeAudioSource.StartFade(musicSource,2,100);
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