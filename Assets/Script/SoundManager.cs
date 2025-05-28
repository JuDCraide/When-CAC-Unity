// Based onhttps://www.youtube.com/watch?app=desktop&v=g5WT91Sn3hg
// By author: Small Hedge Games

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public enum SoundType {
    BUTTON,
    INPUT,
    LINK,
    SLIDER,
    TYPED,
    ERROR,
    GUESS,
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
    [SerializeField] public SoundList[] sounds;
    private static SoundManager instance = null;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private SoundMusic music;
    [SerializeField] private AudioSource musicSource;

    private static bool recentPlaySlicer = false;

    private void Awake() {
        if (!instance) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }

    void Start() {
        if (music.music) {
            musicSource.outputAudioMixerGroup = music.mixer;
            musicSource.clip = music.music;
            musicSource.volume = music.volume;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public static void PlaySound(SoundType sound, AudioSource source = null, float volume = 1) {
        SoundList soundList = instance.sounds[(int)sound];
        AudioClip[] clips = soundList.sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];

        if (source) {
            source.outputAudioMixerGroup = soundList.mixer;
            source.clip = randomClip;
            source.volume = volume * soundList.volume;
            if (sound != SoundType.SLIDER) {
                Debug.Log(soundList.name);
                source.Play();
            }
            if (sound == SoundType.SLIDER && !recentPlaySlicer) {
                Debug.Log("Playing slider sound");
                recentPlaySlicer = true;
                instance.StartCoroutine(instance.WaitToPlaySlider());
            }
        }
        else {
            instance.audioSource.outputAudioMixerGroup = soundList.mixer;
            instance.audioSource.PlayOneShot(randomClip, volume * soundList.volume);
        }
    }

    private IEnumerator WaitToPlaySlider() {
        yield return new WaitForSeconds(10f);
        recentPlaySlicer = false;
    }

#if UNITY_EDITOR
    private void OnEnable() {
        string[] names = Enum.GetNames(typeof(SoundType));
        //Debug.Log(names.Length);
        Array.Resize(ref sounds, names.Length);
        for (int i = 0; i < names.Length; i++) {
            sounds[i].name = names[i];
        }
    }
#endif
}

[Serializable]
public struct SoundList {
    [HideInInspector] public string name;
    [Range(0, 1)] public float volume;
    public AudioMixerGroup mixer;
    public AudioClip[] sounds;
}

[Serializable]
public struct SoundMusic {
    [HideInInspector] public string name;
    [Range(0, 1)] public float volume;
    public AudioMixerGroup mixer;
    public AudioClip music;
}