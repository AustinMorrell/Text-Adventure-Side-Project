using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private float m_speed;
    [ReadOnly, SerializeField]
    private float m_BaseHp;
    [ReadOnly, SerializeField]
    private float m_PlayerHp;
    [SerializeField]
    protected GameObject Fire;
    protected GameObject TempFire;
    public float speed { get { return m_PlayerHp; } set { m_PlayerHp = value; } }
    public float BaseHp { get { return m_PlayerHp; } set { m_PlayerHp = value; } }
    public float PlayerHp { get { return m_PlayerHp; } set { m_PlayerHp = value; } }

    // Use this for initialization
    void Start ()
    {
        gameObject.transform.position = new Vector3(0, -4, 0);
        m_BaseHp = 40;
        m_PlayerHp = m_BaseHp;
	}

    void Lerp(float a, float b, float c)
    {
        gameObject.transform.position = new Vector3(transform.position.x + a, transform.position.y + b, transform.position.z + c);
    }

    // Update is called once per frame
    void Update ()
    {
    if (Input.GetKey("up"))
        {
            Lerp(0, 1 * Time.deltaTime * m_speed, 0);
        }

    if (Input.GetKey("down"))
        {
            Lerp(0, -1 * Time.deltaTime * m_speed, 0);
        }

    if (Input.GetKey("left"))
        {
            Lerp(-1 * Time.deltaTime * m_speed, 0, 0);
        }

    if (Input.GetKey("right"))
        {
            Lerp(1 * Time.deltaTime * m_speed, 0, 0);
        }
    if (Input.GetKey("space"))
        {
           TempFire = Instantiate(Fire, gameObject.transform.position, Quaternion.identity) as GameObject;
            TempFire.GetComponent<Rigidbody>().velocity = new Vector3(20 * Mathf.Cos(0), 20 * Mathf.Sin(0), 0);
        }
    }
}
