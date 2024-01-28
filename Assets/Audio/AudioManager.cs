using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] music, sfx;
    public AudioSource musicSource, sfxSource;

    // to call upon sound go to where the action that goes with the sound is played, ie the code that controls death should also have a reference
    // the line used should be AudioManager.Instance.Playsg
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioManager.Instance.PlaySFX("Splat");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AudioManager.Instance.PlaySFX("Death");
        }
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, x => x.ID == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.Clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, x => x.ID == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.Clip);
        }
    }
}
