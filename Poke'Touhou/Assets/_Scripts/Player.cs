using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private float m_speed;
    [SerializeField]
    private Sprite m_Mega;
    [ReadOnly, SerializeField]
    private float m_BaseHp;
    [ReadOnly, SerializeField]
    private float m_BasePower;
    [ReadOnly, SerializeField]
    private float m_PlayerHp;
    [ReadOnly, SerializeField]
    private float m_PlayerPower;
    [ReadOnly, SerializeField]
    private int m_Mode;
    [SerializeField]
    private int m_maxPower;
    [SerializeField]
    protected GameObject Fire;
    protected GameObject TempFire;
    public int maxPower { get { return m_maxPower; } set { m_maxPower = value; } }
    public int Mode { get { return m_Mode; } set { m_Mode = value; } }
    public float power { get { return m_PlayerPower; } set { m_PlayerPower = value; } }
    public float speed { get { return m_speed; } set { m_speed = value; } }
    public float BasePower { get { return m_BasePower; } set { m_BasePower = value; } }
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
        m_Mode = 1;
        gameObject.transform.position = new Vector3(0, -4, 0);
        m_BaseHp = 40;
        m_PlayerHp = m_BaseHp;
        m_BasePower = 1;
        m_PlayerPower = m_BasePower;
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
        if (m_PlayerPower > m_maxPower)
        {
            m_Mode = 2;
            gameObject.GetComponent<SpriteRenderer>().sprite = m_Mega;
        }

        Lerp(Input.GetAxis("LeftJoystickX") * speed, -Input.GetAxis("LeftJoystickY") * speed, 0);

    if (Input.GetButton("A"))
        {
            if (Mode == 1)
            {
                if (DoIt)
                {
                    TempFire = Instantiate(Fire, gameObject.transform.position, Quaternion.identity) as GameObject;
                    TempFire.GetComponent<Rigidbody>().velocity = new Vector3(0, 20, 0);
                    TempFire.transform.Rotate(new Vector3(0, 0, 90));
                    DoIt = false;
                }
            }

            if (Mode == 2)
            {
                if (DoIt)
                {
                    TempFire = Instantiate(Fire, gameObject.transform.position, Quaternion.identity) as GameObject;
                    TempFire.GetComponent<Rigidbody>().velocity = new Vector3(0, 20, 0);
                    TempFire.transform.Rotate(new Vector3(0, 0, 90));

                    TempFire = Instantiate(Fire, gameObject.transform.position, Quaternion.identity) as GameObject;
                    TempFire.GetComponent<Rigidbody>().velocity = new Vector3(20, 20, 0);
                    TempFire.transform.Rotate(new Vector3(0, 0, 45));

                    TempFire = Instantiate(Fire, gameObject.transform.position, Quaternion.identity) as GameObject;
                    TempFire.GetComponent<Rigidbody>().velocity = new Vector3(-20, 20, 0);
                    TempFire.transform.Rotate(new Vector3(0, 0, 135));

                    DoIt = false;
                }
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
