using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class WritterTypeEffect : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] AudioSource AS;
    [SerializeField] float delay;

    private string currentText;


    public IEnumerator ShowText(string text)
    {
        panel.SetActive(true);
        for (int i = 0; i <= text.Length; i++)
        {
            currentText = text.Substring(0, i);
            textMeshProUGUI.text = currentText;

            AS.Play();

            yield return new WaitForSeconds(delay / text.Length);
            AS.Stop();
        }

        yield return new WaitForSeconds(1.2f * text.Length / 100);
        if (!GlobalController.Instance.wasBad)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        GlobalController.Instance.blockt = false;
        panel.SetActive(false);
    }

}
