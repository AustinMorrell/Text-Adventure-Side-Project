using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle_Script : MonoBehaviour {

    [SerializeField]
    Player player;
    [SerializeField]
    Enemy enemy;
    [SerializeField]
    Text Win;
    [SerializeField]
    Text Lose;
    [SerializeField]
    Canvas Can;
    private bool Doit;

	// Use this for initialization
	void Start ()
    {
        Doit = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Doit)
        {
            if (player.PlayerHp <= 0)
            {
                Doit = false;
                enemy.m_Attack = false;
                Text clone1 = Instantiate(Lose, new Vector3(0, 0, 0), Quaternion.identity) as Text;
                clone1.transform.SetParent(Can.transform, false);
                StartCoroutine(HoldFor(7));
            }

            if (enemy.EnemyHp <= 0)
            {
                Doit = false;
                enemy.m_Attack = false;
                Text clone2 = Instantiate(Win, new Vector3(0, 0, 0), Quaternion.identity) as Text;
                clone2.transform.SetParent(Can.transform, false);
                StartCoroutine(WaitFor(7));
            }
        }
    }

    IEnumerator HoldFor(float secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator WaitFor(float secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
