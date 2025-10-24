using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRumble : MonoBehaviour
{
    public Transform camTransform;

    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPos;


    // Start is called before the first frame update
    void Start()
    {
        camTransform = GetComponent<Transform>();


        originalPos = camTransform.localPosition;
    }

    //void Awake()
    //{
        //if (camTransform == null)
        //{
            //camTransform = GetComponent(typeof(Transform)) as Transform;
        //}
    //}

    //void OnEnable()
    //{
    //    originalPos = camTransform.localPosition;
    //}

    public void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    public void PlayerHit()
    {
        shakeDuration = 0.2f;
    }

}
