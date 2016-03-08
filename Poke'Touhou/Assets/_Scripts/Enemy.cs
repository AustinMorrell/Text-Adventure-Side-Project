using UnityEngine;
using System.Collections;

public class Enemy : Platform {

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
    protected GameObject TempFireball;
    [SerializeField]
    protected int Amount;
    protected float OffSet;
    [SerializeField]
    private float m_BaseEHp;
    [ReadOnly, SerializeField]
    private float m_EnemyHp;
    [SerializeField]
    protected string m_Direction;
    [ReadOnly, SerializeField]
    protected bool m_Reverse = false;
    public bool m_Attack = true;
    public float BaseEHp { get { return m_BaseEHp; } set { m_BaseEHp = value; } }
    public float EnemyHp { get { return m_EnemyHp; } set { m_EnemyHp = value; } }

    protected override void Start ()
    {
        base.Start();
        m_EnemyHp = m_BaseEHp;
        DoIt = false;
	}
	
	protected override void Update ()
    {
        base.Update();
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

    void FixedUpdate()
    {
        m_Velocity = new Vector3(0, 0, 0);
        switch (m_Direction)
        {
            case "right":
                if (!m_Reverse)
                {
                    MoveForward();
                    if (m_Origin.x + m_Distance.x <= transform.position.x)
                    {
                        m_Reverse = true;
                    }
                }
                if (m_Reverse)
                {
                    MoveBack();
                    if (m_Origin.x >= transform.position.x)
                    {
                        m_Reverse = false;
                    }
                }
                break;

            case "left":
                if (!m_Reverse)
                {
                    MoveBack();
                    if (m_Origin.x - m_Distance.x >= transform.position.x)
                    {
                        m_Reverse = true;
                    }
                }
                if (m_Reverse)
                {
                    MoveForward();
                    if (m_Origin.x <= transform.position.x)
                    {
                        m_Reverse = false;
                    }
                }
                break;

            case "up":
                if (!m_Reverse)
                {
                    MoveUp();
                    if (m_Origin.y + m_Distance.y <= transform.position.y)
                    {
                        m_Reverse = true;
                    }
                }
                if (m_Reverse)
                {
                    MoveDown();
                    if (m_Origin.y >= transform.position.y)
                    {
                        m_Reverse = false;
                    }
                }
                break;

            case "down":
                if (!m_Reverse)
                {
                    MoveDown();
                    if (m_Origin.y - m_Distance.y >= transform.position.y)
                    {
                        m_Reverse = true;
                    }
                }
                if (m_Reverse)
                {
                    MoveUp();
                    if (m_Origin.y <= transform.position.y)
                    {
                        m_Reverse = false;
                    }
                }
                break;
        }
    }
}
