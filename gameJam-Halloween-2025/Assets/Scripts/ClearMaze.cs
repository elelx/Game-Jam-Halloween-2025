using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMaze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject[] chasers = GameObject.FindGameObjectsWithTag("Maze01Enemy");
        foreach (GameObject chaser in chasers)
        {
            Destroy(chaser);
        }
        Debug.Log("enemies from maze 1 wiped");

        if (other.gameObject.CompareTag("2to3trgiier"))
        {
            GameObject[] aaaa = GameObject.FindGameObjectsWithTag("Maze02Enemy");
            foreach (GameObject aaa in aaaa)
            {
                Destroy(aaa);
            }
            Debug.Log("enemies from maze 2 wiped");
        }
    }
}
