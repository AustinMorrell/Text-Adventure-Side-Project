using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaitForASec : MonoBehaviour {

    [SerializeField]
    private GameObject NewGame;
    [SerializeField]
    private GameObject Continue;
    [SerializeField]
    private GameObject Exit;
    private float count;
    private bool check;

	void Start ()
    {
        NewGame.SetActive(false);
        Continue.SetActive(false);
        Exit.SetActive(false);
        check = true;
	}
	

	void Update ()
    {
        count += Time.deltaTime;
        if (check)
        {
            if (count >= 2)
            {
                NewGame.SetActive(true);
                Continue.SetActive(true);
                Exit.SetActive(true);
                check = false;
            }
        }
    }
}
