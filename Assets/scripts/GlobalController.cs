using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;
    public float musicValue;
    public float soundValue;
    public bool hasLoadedScene;
    public GameObject menu;
    public bool isDragging = false;
    public int deathCount;
    public string nextLine;
    public bool wasBad;
    public bool blockt;
    // Start is called before the first frame update
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                Instance.menu.SetActive(true);
            }
        }
    }
}
