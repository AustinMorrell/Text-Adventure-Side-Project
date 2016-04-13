using UnityEngine;
using System.Collections;

public class Enemy_Fire : MonoBehaviour
{
    protected Object Drop;
    protected GameObject Player;
    protected float count;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
        Drop = Resources.Load("PowerUp");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Player.GetComponent<Player>().PlayerHp -= 1f;
            Destroy(gameObject);
        }

        if (other.name == "Player_Attack(Clone)")
        {
            Instantiate(Drop, gameObject.transform.position, Quaternion.identity);
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
