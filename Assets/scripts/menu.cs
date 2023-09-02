using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class menu : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;
    public bool hideOnPlay;

    private void Start()
    {
        if (GlobalController.Instance != null)
        {
            GlobalController.Instance.menu = this.gameObject;
        }
        if (hideOnPlay)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Play()
    {
        GlobalController.Instance.musicValue = musicSlider.value;
        GlobalController.Instance.soundValue = soundSlider.value;
        if (!GlobalController.Instance.hasLoadedScene)
        {
            DontDestroyOnLoad(this.gameObject);
            GlobalController.Instance.hasLoadedScene = true;
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Quit()
    {
       Application.Quit();
    }
    public void onMusicValueChange(float amount)
    {
        GlobalController.Instance.musicValue = amount;
    }

    public void onSoundValueChange(float amount)
    {
        GlobalController.Instance.soundValue = amount;
    }
}
