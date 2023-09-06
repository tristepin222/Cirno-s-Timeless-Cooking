using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] Bowl bowl;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] List<AudioClip> clipList = new List<AudioClip>();

    private int i = 0;
    public void CallResult()
    {
        bowl.Result();
    }

    public void CallThink()
    {
        bowl.Think();
    }

    public void PlaySound()
    {
        audioSource.clip = clipList[i];
        audioSource.Play();
        i++;
        if (i == 3)
        {
            i = 0;
        }
    }
    public void PlayHit()
    {
        audioSource2.Play();
    }
    public void ResetScene()
    {
        bowl.resetScene();
    }
}
