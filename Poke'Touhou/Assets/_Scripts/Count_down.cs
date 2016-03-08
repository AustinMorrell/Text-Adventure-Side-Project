using UnityEngine;
using System.Collections;

public class Count_down : MonoBehaviour {

    float maxTime = 10;
    float CurrentTime;

	// Use this for initialization
	void Start ()
    {
        CurrentTime = maxTime;
        StartCoroutine(time(10));
	}
	
	// Update is called once per frame
	IEnumerator time(float f)
    {
        while(f > 0)
        {
            f -= Time.deltaTime;
            Debug.Log(f);
            yield return null;
        }
    }
}
