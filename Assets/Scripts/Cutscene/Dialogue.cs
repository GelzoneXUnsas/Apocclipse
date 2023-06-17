using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponment;

    public GameObject textbox;

    public string[] lines;

    public float textSpeed;

    private int index;

    private bool isStart = false;

    private int lineNum = 4;

    public CamerController cam;

    public bool isDialogue;

    private bool secondDialogue;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        textComponment.text = string.Empty;
        secondDialogue = false;

        // StartDialogue();
        textComponment.enabled = false;
        textbox.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.distance >= 60 && !secondDialogue)
        {
            secondDialogue = true;
            isDialogue = true;
            cam.isMoving = false;
            lineNum = lines.Length;
        }

        if (!cam.isMoving)
        {
            if (!isStart)
            {
                StartDialogue();

                /*audioSource.Play();*/
                isStart = true;
            }
            textComponment.enabled = true;
            textbox.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (textComponment.text == lines[index])
                {
                    NextLine();
                    textSpeed = 0.05f;
                }
                else
                {
                    //audioSource.enabled = false;
                    //StopAllCoroutines();
                    //textComponment.text = string.Empty;
                    //isDialogue = false;
                    textSpeed -= 1;
                }
            }
        }
        else
        {
            textbox.SetActive(false);

            //gameObject.SetActive(false);
            //index = 0;
            textComponment.enabled = false;
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine(true));
    }

    IEnumerator TypeLine(bool playAudio)
    {
        if (playAudio) audioSource.Play();
        foreach (char c in lines[index].ToCharArray())
        {
            textComponment.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        if (playAudio) audioSource.Pause();
    }

    void NextLine()
    {
        if (index < lineNum - 1)
        {
            index++;
            textComponment.text = string.Empty;
            StartCoroutine(TypeLine(true));
        }
        else
        {
            index++;
            textComponment.text = string.Empty;
            StartCoroutine(TypeLine(false));

            // textbox.SetActive(false);
            // gameObject.SetActive(false);
            isDialogue = false;
        }
    }
}
