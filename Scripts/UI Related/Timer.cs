using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject TextDisplay;

    public int secondsLeft;
    public bool Countdown = false;

    public void Start()
    {
        TextDisplay.GetComponent<Text>().text = secondsLeft.ToString();
    }

    public void Update()
    {
        if (Countdown == false && secondsLeft > 0)
        {
            StartCoroutine(Counter());
        }
    }

    public void GameOver()
    {
        TextDisplay.SetActive(false);
        Time.timeScale = 0f;
    }

    IEnumerator Counter()
    {
        Countdown = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        TextDisplay.GetComponent<Text>().text = secondsLeft.ToString();
        Countdown = false;
        if (secondsLeft == 0)
        {
            GameOver();
        }
    }

}
