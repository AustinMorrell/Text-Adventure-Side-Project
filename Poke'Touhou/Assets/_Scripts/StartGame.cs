using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private SceneManager SceneManagement;

    public void OnClick()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(Example());
        SceneManager.LoadScene("Cutsene_1");
    }

    public IEnumerator Example()
    {
        yield return new WaitForSeconds(4);
    }
}
