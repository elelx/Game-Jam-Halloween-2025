using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Sprite[] heartUI = new Sprite[2];
    public Image imgSource;
    private int currentImg = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            ChangeHeart();
        }
    }

    public void ChangeHeart()
    {
        if (currentImg < heartUI.Length)
        {
            imgSource.sprite = heartUI[currentImg];
            currentImg ++;
        }

        if (heartUI.Length == 2)
        {
            DieSequence();
        }
    }

    private void DieSequence()
    {
        Debug.Log("you died");
    }
}
