using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRumble : MonoBehaviour
{
    public Transform camTransform;
    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = GetComponent<Transform>();
    }

    //void Awake()
    //{
        //if (camTransform == null)
        //{
            //camTransform = GetComponent(typeof(Transform)) as Transform;
        //}
    //}

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    public void PlayerHit()
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
}
