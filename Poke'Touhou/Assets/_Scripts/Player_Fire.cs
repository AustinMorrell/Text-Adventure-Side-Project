using UnityEngine;
using System.Collections;

public class Player_Fire : MonoBehaviour
{
    protected GameObject Player;
    protected GameObject Enemy;
    protected float count;

    void Start()
    {
        if (FindObjectOfType<Enemy>() != null)
        { Enemy = FindObjectOfType<Enemy>().gameObject; }
        Player = FindObjectOfType<Player>().gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy")
        {
            Enemy.GetComponent<Enemy>().EnemyHp -= Player.GetComponent<Player>().power;
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
