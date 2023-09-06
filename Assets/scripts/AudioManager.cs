using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> musics = new List<AudioSource>();
    [SerializeField] List<AudioSource> sounds = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        changeVolume();
    }

    public void changeVolume()
    {
        if (GlobalController.Instance != null)
        {
            foreach (AudioSource music in musics)
            {
                music.volume = GlobalController.Instance.musicValue;
            }
            foreach (AudioSource sound in sounds)
            {
                sound.volume = GlobalController.Instance.soundValue;
            }
        }
    }
}
