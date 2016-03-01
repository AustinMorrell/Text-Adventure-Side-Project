using UnityEngine;
using System.Collections;

public class Battle_Script : MonoBehaviour {

    [SerializeField]
    Player player;
    [SerializeField]
    Enemy enemy;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (player.PlayerHp <= 0)
        {

        }

        if (enemy.EnemyHp <= 0)
        {
            enemy.DoIt = false;
        }
    }
}
