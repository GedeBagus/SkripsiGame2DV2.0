using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    // public GameObject CurrentStory;
    // public GameObject NextStory;
    // public GameObject BackStory;
    public GameObject Tutorial;
    public GameObject [] popUp;
    private int popUpIndex;
    [SerializeField] private AudioSource buttonEffect;
    
    // public GameObject closeButton;
    // AudioSource sound;
    void Awake()
    {
        // sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        for (int i = 0; i < popUp.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUp[i].SetActive(true);
                // buttonEffect.Play();
            }
            else
            {
                popUp[i].SetActive(false);
                // buttonEffect.Play();
            }
        }
    }
    public void Next()
    {
        // sound.Play();
        // CurrentStory.SetActive(false);
        // NextStory.SetActive(true);
        if (popUpIndex == 0)
        {
            popUpIndex++;
            buttonEffect.Play();
        }
        else if (popUpIndex == 1)
        {
            popUpIndex++;
            buttonEffect.Play();
        }
        else if (popUpIndex == 2)
        {
            popUpIndex++;
            buttonEffect.Play();
        }
        // else if (popUpIndex == 2)
        // {
        //     popUpIndex++
        // }
    }
    public void Back()
    {
        // sound.Play();
        // CurrentStory.SetActive(false);
        // BackStory.SetActive(true);
        if (popUpIndex == 1)
        {
            popUpIndex--;
            buttonEffect.Play();
        }
        else if (popUpIndex == 2)
        {
            popUpIndex--;
            buttonEffect.Play();
        }
        else if (popUpIndex == 3)
        {
            popUpIndex--;
            buttonEffect.Play();
        }
    }

    public void Close()
    {
        // sound.Play();
        Tutorial.SetActive(false);
        buttonEffect.Play();
        // BackStory.SetActive(true);
    }


    // public void Finish(string scenename)
    // {
    //     // sound.Play();
    //     Time.timeScale = 1f;
    //     // CurrentStory.SetActive(false);
    //     SceneManager.LoadScene(scenename);
    // }
}
