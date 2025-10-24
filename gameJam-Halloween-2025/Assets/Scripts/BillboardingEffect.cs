using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardingEffect : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void LateUpdate()
    {
        if (!Camera.main)
        {
            return;
                }

        Vector3 fwd = Camera.main.transform.forward;
        fwd.y = 0f;

        if (fwd.sqrMagnitude > 0.0001f)
        {
            transform.forward = fwd.normalized;
        }

    }
}
