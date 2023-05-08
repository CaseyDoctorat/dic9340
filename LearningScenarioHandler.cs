using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningScenarioHandler : MonoBehaviour
{
    [SerializeField]
    GameObject Q1;
    float time=10;// mettre le temps du speech;

    IEnumerator StartQuestions()
    {
        yield return new WaitForSeconds(time);
        Q1.SetActive(true);
    }
}
