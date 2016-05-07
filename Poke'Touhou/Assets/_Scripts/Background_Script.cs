using UnityEngine;
using System.Collections;

public class Background_Script : MonoBehaviour {

    [SerializeField]
    private Sprite[] Frames;
    private int i = 0;
    private int Count = 0;
	
	void Update ()
    {
	if (Count % 4 == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Frames[i];
            i++;
            if (i > Frames.Length)
            {
                i = 0;
            }
        }
        Count++;
	}
}
