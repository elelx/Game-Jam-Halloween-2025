using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNewHeartTrig : MonoBehaviour
{
    public HealthSystem healthSystem;

    private void OnCollisionEnter(Collision col)

    {
        if (col.gameObject.CompareTag("Player"))
        {
            healthSystem.GetHeart();
            Destroy(gameObject);
        }
    }


}
