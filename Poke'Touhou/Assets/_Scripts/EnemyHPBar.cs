using UnityEngine;
using System.Collections;

public class EnemyHPBar : MonoBehaviour {

    private float Max;
    private bool stop;

    [SerializeField]
    private Enemy m_player;

    // Use this for initialization
    void Start()
    {
        Max = gameObject.transform.localScale.x;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == false)
        {
            gameObject.transform.localScale = new Vector3(Max * (m_player.EnemyHp / m_player.BaseEHp), 1, 1);
            if (m_player.EnemyHp <= 0)
            {
                stop = true;
            }
        }
    }
}
