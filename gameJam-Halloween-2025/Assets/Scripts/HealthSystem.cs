using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using EZCameraShake;

public class HealthSystem : MonoBehaviour
{
    public Sprite[] heartUI = new Sprite[2];
    public Image imgSource;
    private int currentImg = 0;

    public GameObject deathScreen;

    void Awake()
    {
        if (deathScreen) deathScreen.SetActive(false); 
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Maze01Enemy"))
        {
            Destroy(col.gameObject);
            ChangeHeart();
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .5f);

            //CameraShaker.Instance.ShakeOnce(1f, 2f, .1f, 1f);
        }
    }

    public void ChangeHeart()
    {
        if (currentImg < heartUI.Length)
        {
            imgSource.sprite = heartUI[currentImg];
            currentImg ++;
            Debug.Log("ouch me hit");
        }

        if (currentImg >= heartUI.Length)
        {
            DieSequence();
        }
    }
     private void DieSequence()
    {
        Debug.Log("you died");

        if (deathScreen)
            deathScreen.SetActive(true);
    }


}
