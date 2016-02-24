using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void OnClick()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(Example());
        Application.Quit();
    }

    public IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
    }
}
