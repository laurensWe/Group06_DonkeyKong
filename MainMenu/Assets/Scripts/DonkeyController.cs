using UnityEngine;
using System.Collections;


public class DonkeyController : MonoBehaviour
{

    public bool Action;
    private int randomNumber;
    private int Timer1;
    public Animator anim;
    // public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim.GetComponent<Animator>();
        Timer1 = 0;

    }

    void Update()
    {
        randomNumber = Random.Range(1, 500);
        if (randomNumber <= 2)
        {
            Action = true;
            StartCoroutine(Example());
        }


    }

    IEnumerator Example()
    {
        anim.SetBool("Action", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("Action", false);
    }
}
