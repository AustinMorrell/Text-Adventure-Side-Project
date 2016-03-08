using UnityEngine;
using System.Collections;

public class Player_Fire : MonoBehaviour
{
    protected GameObject Enemy;
    protected float count;

    void Start()
    {
        Enemy = FindObjectOfType<Enemy>().gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy")
        {
            Enemy.GetComponent<Enemy>().EnemyHp -= 5f;
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
