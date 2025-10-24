using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHandSpawn : MonoBehaviour
{
    public Transform player;
    public GameObject zombieHandPrefab;
    private GameObject currentHand;

    public float maxAmoutofIdle = 5f;
    private float idleTimer = 0f;

    public float spawnZomDistance = 2f;

    private Vector3 lastPosition;
     private Vector3 lastMoveDir = Vector3.back;


    public LayerMask groundMask;

    public HealthSystem health;


    // Start is called before the first frame update
    void Start()
    {
        if (player)
        {
            lastPosition = player.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 frameMove = player.position - lastPosition;

        float distanceMoved = Vector3.Distance(player.position, lastPosition);

        if (distanceMoved > 0.001f)
        {
            lastMoveDir = frameMove.normalized;

        }


        if (distanceMoved < 0.05f)
        {
            idleTimer += Time.deltaTime;

            if(idleTimer >= maxAmoutofIdle && currentHand == null)
            {
                Vector3 spawnPos = player.position - lastMoveDir * spawnZomDistance;


                if (zombieHandPrefab)
                {
                    Quaternion rot = Quaternion.LookRotation((player.position - spawnPos).normalized, Vector3.up);

                    currentHand = Instantiate(zombieHandPrefab, spawnPos, rot);

                    var sr = currentHand.GetComponent<SpriteRenderer>();
                    if (sr)
                    {
                        Vector3 dirToPlayer = (player.position - spawnPos).normalized;


                        if (Mathf.Abs(dirToPlayer.x) >= Mathf.Abs(dirToPlayer.z))
                        {
                            sr.flipX = dirToPlayer.x < 0f;
                        }
                        else
                        {
                            // up/down (if you have separate sprites, you could swap here)
                            // sr.sprite = upSprite / downSprite;
                        }
                    }

                    var animation = currentHand.GetComponent<Animator>();
                    if (animation)
                    {
                        animation.SetTrigger("ZombieGrab");
                    }

                    if (health)
                    {
                        health.ChangeHeart();
                        Debug.Log("minus a heart Zombie hit me");
                    }

                    idleTimer = 0f;
                }
            }
        }

        else
        {
            idleTimer = 0f;


            //lastPosition = player.position;

            if (currentHand)
            {
                Destroy(currentHand);
                currentHand = null;
            }

        }

        lastPosition = player.position;
    }
}
