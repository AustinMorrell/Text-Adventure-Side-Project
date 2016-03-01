using UnityEngine;
using System.Collections;

public class Enemy_Fire : MonoBehaviour
{
    protected GameObject Player;
    protected float count;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Player.GetComponent<Player>().PlayerHp -= 1f;
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
