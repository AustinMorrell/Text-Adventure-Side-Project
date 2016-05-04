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
    [SerializeField]
    private GameObject Handle;
    [SerializeField]
    private GameObject N;
    [SerializeField]
    private GameObject C;
    [SerializeField]
    private GameObject E;
    private int Selected;
    private float count;
    private bool check;
    private bool Hold;

	void Start ()
    {
        NewGame.SetActive(false);
        Continue.SetActive(false);
        Exit.SetActive(false);
        Handle.SetActive(false);
        Hold = true;
        check = true;
        Selected = 1;
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
                Handle.SetActive(true);
                check = false;
            }
        }

        if (Input.GetAxis("LeftJoystickY") > 0 && Hold)
        {
            Selected++;
            if (Selected > 3) { Selected = 1; }
            switch (Selected)
            {
                case 1:
                    Handle.transform.position = new Vector3(Handle.transform.position.x, -0.5f, Handle.transform.position.z);
                    break;

                case 2:
                    Handle.transform.position = new Vector3(Handle.transform.position.x, -1.5f, Handle.transform.position.z);
                    break;

                case 3:
                    Handle.transform.position = new Vector3(Handle.transform.position.x, -2.5f, Handle.transform.position.z);
                    break;
            }
            Hold = false;
        }

        if (Input.GetAxis("LeftJoystickY") == 0)
        {
            Hold = true;
        }

        if (Input.GetButtonDown("A"))
        {
            switch (Selected)
            {
                case 1:
                    N.GetComponent<StartGame>().OnClick();
                    break;

                case 2:
                    break;

                case 3:
                    E.GetComponent<Exit>().OnClick();
                    break;
            }
        }
    }
}
