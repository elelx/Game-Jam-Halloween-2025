using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

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

        float distanceMoved = frameMove.magnitude; ;

        if (distanceMoved > 0.001f)
        {
            lastMoveDir = frameMove.normalized;

        }


        if (distanceMoved < 0.05f)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= maxAmoutofIdle && currentHand == null)
            {

                Vector3 dirToCam = (Camera.main.transform.position - player.position);
                dirToCam.y = 0f;
                dirToCam.Normalize();

                Vector3 spawnPos = player.position + dirToCam * spawnZomDistance;

            
                currentHand = Instantiate(zombieHandPrefab, spawnPos, Quaternion.identity);

                currentHand.transform.position = spawnPos;   // enforce world pos once

                var sr = currentHand.GetComponent<SpriteRenderer>();
                if (sr) sr.sortingOrder = 100;

                CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .5f);

                if (health) {

                        health.ChangeHeart();
                }


                idleTimer = 0f;
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
