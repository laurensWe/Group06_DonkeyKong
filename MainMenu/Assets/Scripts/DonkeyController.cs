using UnityEngine;
using System.Collections;


public class DonkeyController : MonoBehaviour{ 
    private int randomNumber;

    public ParticleSystem smokey1;
    public ParticleSystem smokey2;

    public Animator anim;
    // public Animator anim;

    // Use this for initialization
    void Start(){
        anim.GetComponent<Animator>();
    }

    void Update(){
        randomNumber = Random.Range(1, 500);
        if (randomNumber <= 2){
            StartCoroutine(Example());
        }
    }

    IEnumerator Example(){
        anim.SetBool("Action", true);
        smokey1.Play();
        smokey2.Play();
        yield return new WaitForSeconds(1);
        anim.SetBool("Action", false);
    }
}
