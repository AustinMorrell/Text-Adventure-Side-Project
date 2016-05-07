using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    protected float count;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Player>().power += 1;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        count += Time.deltaTime;
        if (count >= 4)
        {
            Destroy(gameObject);
        }
    }
}
