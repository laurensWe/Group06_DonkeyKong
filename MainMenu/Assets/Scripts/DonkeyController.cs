using UnityEngine;
using System.Collections;

public class DonkeyController : MonoBehaviour {

    public bool Action;
    private float randomNumber;
    private int Timer1;
    public Animator anim;
    // public Animator anim;

    // Use this for initialization
    void Start () {
        anim.GetComponent<Animator>();
        Timer1 = 0;
    }

    void Update()
    {
        randomNumber = Random.Range(1, 100);
        if (randomNumber <= 2)
        {
            Action = true;
            anim.SetBool("Action", Action);
            Timer1 = 1;
        }
            
        
    }
}
