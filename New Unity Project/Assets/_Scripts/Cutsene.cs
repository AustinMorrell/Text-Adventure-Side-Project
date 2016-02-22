using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cutsene : MonoBehaviour {

    [SerializeField]
    private GameObject Picture;
    [SerializeField]
    private Sprite[] Pics;

	void Update ()
    {
        for (int i = 0; i < Pics.Length; i++)
        {
            Picture.GetComponent<Image>().sprite = Pics[i];
        }
        SceneManager.LoadScene("1stStage");
	}
}
