using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] lines;
    public GameObject linesArray;
    public GameObject[] finalLines;
    public GameObject finalLinesArray;
    public int index;
    public GameObject transition;

    public GameObject continueButton;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject gameOver;

    public static bool finalDay;

    void Start()
    {
        if(finalDay)
        {
            finalLinesArray.SetActive(true);
            linesArray.SetActive(false);
        }
    }

    public void NextLine()
    {
        if(!finalDay)
        {
            if(lines[0].activeSelf)
            {
                lines[0].SetActive(false);
                lines[1].SetActive(true);
                index=1;
            }
            else
            {
                if(index!=lines.Length-1)
                {
                    lines[index].SetActive(false);
                    lines[index+1].SetActive(true);
                    index++;
                }
                else
                {
                    index=0;
                    continueButton.SetActive(false);
                    yesButton.SetActive(true);
                    noButton.SetActive(true);
                }
            }
        }
        else
        {
            if(finalLines[0].activeSelf)
            {
                finalLines[0].SetActive(false);
                finalLines[1].SetActive(true);
                index=1;
            }
            else
            {
                if(index!=finalLines.Length-1)
                {
                    finalLines[index].SetActive(false);
                    finalLines[index+1].SetActive(true);
                    index++;
                }
                else
                {
                    StartCoroutine(EndTransition());
                }
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("DialogueStart");
    }

    public void No()
    {
        StartCoroutine(NoTransition());
    }

    public void MakeTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator NoTransition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        gameOver.SetActive(true);
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Dock");
    }

    IEnumerator EndTransition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Credits");
    }    
}
