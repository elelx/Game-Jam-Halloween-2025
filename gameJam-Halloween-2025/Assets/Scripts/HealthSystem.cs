using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class HealthSystem : MonoBehaviour
{
    public Sprite[] heartUI = new Sprite[2];
    public Image imgSource;
    private int currentImg = 0;
    //public CameraRumble cr;

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Maze01Enemy"))
        {
            Destroy(col.gameObject);
            ChangeHeart();
            //cr.PlayerHit();
        }
    }

    public void ChangeHeart()
    {
        if (currentImg < heartUI.Length)
        {
            imgSource.sprite = heartUI[currentImg];
            currentImg ++;
        }

        if (heartUI.Length == 4)
        {
            DieSequence();
        }
    }

    private void DieSequence()
    {
        Debug.Log("you died");
    }
}
