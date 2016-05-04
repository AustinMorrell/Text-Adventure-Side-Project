using UnityEngine;
using System.Collections;

public class CelebiAttck : MonoBehaviour {

    [SerializeField]
    protected GameObject Fire;
    [SerializeField]
    protected Player Player;
    [SerializeField]
    protected float WaitForFire;
    protected float count;
    protected bool DoIt;
    [SerializeField]
    protected float Speed;
    public bool m_Attack = true;
    protected GameObject TempFireball;
    [SerializeField]
    protected int Amount;
    protected float OffSet;

    protected void Start()
    {
        DoIt = false;
    }

    protected void Update()
    {
        if (m_Attack)
        {
            if (DoIt && (Player.PlayerHp > 0))
            {
                for (int i = 0; i < Amount; i++)
                {
                    TempFireball = Instantiate(Fire, gameObject.transform.position, Quaternion.identity) as GameObject;
                    float ATang = Mathf.Atan((transform.position.y - Player.transform.position.y) / (transform.position.x - Player.transform.position.x));

                    // Correct the angle if we are in quadrant 1
                    if (transform.position.x > Player.transform.position.x && transform.position.y > Player.transform.position.y)
                        ATang += Mathf.PI;
                    // Correct the angle if we are in quadrant 4
                    if (transform.position.x > Player.transform.position.x && transform.position.y < Player.transform.position.y)
                        ATang -= Mathf.PI;

                    ATang += OffSet;
                    OffSet += Amount * (Mathf.PI / 180);
                    TempFireball.GetComponent<Rigidbody>().velocity = new Vector3(Speed * Mathf.Cos(ATang), Speed * Mathf.Sin(ATang), 0);
                    TempFireball.transform.Rotate(new Vector3(0, 0, ATang * (180 / Mathf.PI)));
                }
                DoIt = false;
            }
            else
            {
                count += Time.deltaTime;
                if (count >= WaitForFire)
                {
                    DoIt = true;
                    count = 0;
                }
            }
        }
    }
}
