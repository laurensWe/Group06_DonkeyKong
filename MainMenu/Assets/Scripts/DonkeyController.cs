using UnityEngine;
using System.Collections;

public class DonkeyController : MonoBehaviour {

    public bool Action;
    private float randomNumber;
    private float Timer1;
    private Animator anim;
    // public Animator anim;

    // Use this for initialization
    void Start () {
        anim.GetComponent<Animator>();
        anim.SetBool("Action", Action);
        Timer1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer1 = Timer1 + 1;
        if(Timer1 > 100) {
            randomNumber = Random.Range(0, 1);
            if (randomNumber < 1)
            {
                Debug.Log("hallo");
            anim.SetBool("Action", Action);
            }
    }
        //anim.SetBool("Action", false);
    }
}
