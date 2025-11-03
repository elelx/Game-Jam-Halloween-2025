using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextTypingSequence : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed; //Text Speed

    public GameObject[] bgImages;

    private int index;
    public GameObject NextSceneButton;
    public int NextSceneNum;

    // Start is called before the first frame update
    void Start()
    {
        NextSceneButton.SetActive(false);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Space= Audio and Line Progression
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                NextImage();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue() //Start Dialoge
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) //Speed and characters
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            NextSceneButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void NextImage()
    {
        if (index < bgImages.Length - 1)
        {
            bgImages[index].SetActive(true);
        }   
    }

    public void NextScene()
    {
        SceneManager.LoadScene(NextSceneNum);
    }
}


