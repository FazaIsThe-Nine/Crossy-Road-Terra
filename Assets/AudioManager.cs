using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;
    [SerializeField] Toggle muteToggle;

    public static AudioManager Instance { get => instance;}

    public bool IsMute;
    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayBGM(AudioClip clip, bool loop = true) 
    {
        if(bgm.isPlaying)
            bgm.Stop();

        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }
    public void PlaySFX(AudioClip clip) 
    {
        if(sfx.isPlaying)
            sfx.Stop();

        sfx.clip = clip;
        sfx.Play();
    }
    public void SetMute (bool value) 
    {
        bgm.mute = value;
        sfx.mute = value;
    }
    private void Start() {
        muteToggle.isOn = IsMute;
    }
}
