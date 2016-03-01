using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private float Max;
    private bool stop;

    [SerializeField]
    private Player m_player;

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
            gameObject.transform.localScale = new Vector3(Max * (m_player.PlayerHp / m_player.BaseHp), 1, 1);
            if (m_player.PlayerHp <= 0)
            {
                stop = true;
            }
        }
    }
}
