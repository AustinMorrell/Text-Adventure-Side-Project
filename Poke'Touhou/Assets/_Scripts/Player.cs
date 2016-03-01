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
    public float speed { get { return m_speed; } set { m_speed = value; } }
    public float BaseHp { get { return m_BaseHp; } set { m_BaseHp = value; } }
    public float PlayerHp { get { return m_PlayerHp; } set { m_PlayerHp = value; } }
    private bool DoIt;
    private float Counter;

    [System.Serializable]
    protected class Box
    {
        public float MinX, MinY, MaxX, MaxY;
    }

    [SerializeField]
    protected Box m_ScreenBorders;

    void Awake()
    {
        gameObject.transform.position = new Vector3(0, -4, 0);
        m_BaseHp = 40;
        m_PlayerHp = m_BaseHp;
        Counter = 0;
    }

    // Use this for initialization
    void Start ()
    {

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
            if (DoIt)
            {
                TempFire = Instantiate(Fire, gameObject.transform.position, Quaternion.identity) as GameObject;
                TempFire.GetComponent<Rigidbody>().velocity = new Vector3(0, 20, 0);
                TempFire.transform.Rotate(new Vector3(0, 0, 90));
                DoIt = false;
            }
            if (DoIt == false)
            {
                Counter += Time.deltaTime;
                if (Counter >= .2)
                {
                    DoIt = true;
                    Counter = 0;
                }
            }
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, m_ScreenBorders.MinX, m_ScreenBorders.MaxX), Mathf.Clamp(transform.position.y, m_ScreenBorders.MinY, m_ScreenBorders.MaxY), transform.position.z);
    }
}
