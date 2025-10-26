using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class Swooping : MonoBehaviour
{
   // public GameObject[] CrowImages;
    public HealthSystem health;

    public Animator animator;

    private float attackTimer;
    public float crowTimerMin = 40f;
    public float crowTimerMax = 180f;

    private bool isAttacking = false;

    public AudioSource enemyAudioSource;
    public AudioClip crowMiss;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = Random.Range(crowTimerMin, crowTimerMax);

    }

    // Update is called once per frame
    void Update()
    {
 
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {

            StartCoroutine(Attack());

        }

    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        animator.SetTrigger("CrowSwoop");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);



        isAttacking = false;

        animator.SetTrigger("Idle");

        attackTimer = Random.Range(crowTimerMin, crowTimerMax);


    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .5f);

            enemyAudioSource.PlayOneShot(crowMiss);

            Debug.Log("I HIT HIM MEHEH");


            if (health)
            {

                health.ChangeHeart();
            }
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .5f);
    //      Debug.Log("I HIT HIM MEHEH");

    //        if (health) health.ChangeHeart();
    //    }
    //}

}
