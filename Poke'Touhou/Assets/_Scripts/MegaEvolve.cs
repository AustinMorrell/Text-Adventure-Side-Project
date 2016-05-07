using UnityEngine;
using System.Collections;

public class MegaEvolve : MonoBehaviour {

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
            gameObject.transform.localScale = new Vector3(Max * (m_player.power / m_player.maxPower), 1, 1);
            if (m_player.power >= m_player.maxPower)
            {
                stop = true;
            }
        }
    }
}
