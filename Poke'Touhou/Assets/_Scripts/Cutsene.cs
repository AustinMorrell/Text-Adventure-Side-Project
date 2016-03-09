using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cutsene : MonoBehaviour {

    [SerializeField]
    private GameObject Picture;
    [SerializeField]
    private Sprite[] Pics;
    [SerializeField]
    private Text[] Statement;
    [SerializeField]
    private Canvas Can;
    private bool a;
    private int i;
    Text Temp;

    void Start()
    {
        a = true;
        i = 0;
    }

    void Update ()
    {
        if (a)
        {
            if (i == Pics.Length)
            {
                SceneManager.LoadScene("1stStage");
            }
            Picture.GetComponent<Image>().sprite = Pics[i];
            Temp = Instantiate(Statement[i]);
            Temp.transform.parent = Can.transform;
            a = false;
            i++;
        }
        else if (Input.GetButtonDown("A") || Input.GetKeyDown("z"))
        {
            Destroy(Temp);
            a = true;
        }
	}
}
