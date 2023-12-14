using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
   [SerializeField] private static SoundManager _instance;
    [SerializeField] public static SoundManager instance => _instance;

    [SerializeField] public static bool hasIntance => _instance != null;
    public enum SoundName
    {
        BGM,
        BGM2,
        Playerdie,
        EnemyG,
        EnemyGhost,
        Jump,
        Walk,
        Win,
        ItemCollect,

        BT,
        BGM3
    }

    [SerializeField] private Sound[] _sounds;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Play(SoundName name)
    {
        Sound sound = GetSound(name);
        if (sound.audioSource == null)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
        }

        sound.audioSource.Play();
    }

    private Sound GetSound(SoundName name)
    {
        return Array.Find(_sounds, s => s.soundName == name);
    }
}
