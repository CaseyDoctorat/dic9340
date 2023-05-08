using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class Questionnaire : MonoBehaviour
{

    [SerializeField]
    GameObject Q1;

    [SerializeField]
    TMP_Dropdown F1;
    [SerializeField]
    TMP_Dropdown F2;
    [SerializeField]
    TMP_Dropdown F3;
    [SerializeField]
    TMP_Dropdown F4;

    int score;

    void Start()
    {
        
    }


    public void ValidateAnswers()
    {
        if (F1.value == 2)
        {
            score++;
            Debug.Log("Reponse 1");
        }
        if (F2.value == 1)
        {
            score++;
            Debug.Log("Reponse 2");
        }
        if (F3.value == 3)
        {
            score++;
            Debug.Log("Reponse 3");
        }
        if (F4.value == 0)
        {
            score++;
            Debug.Log("Reponse 4");
        }
        

        Debug.Log("Val" + score);

        
        Q1.SetActive(false);

        File.WriteAllText("./dataEyeTracking.csv" + System.DateTime.Now, score.ToString());
    }
}
