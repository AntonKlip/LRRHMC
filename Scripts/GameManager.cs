using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform zoomPlace;
    public GameObject LetterPanel, answerPanel, emailPanel, answerIntruction, inputText, buttonSend;

    public string userEMail;

    private void Awake()
    {
        instance = this;
    }
    public void AnswerButton()
    {
        LetterPanel.SetActive(false);
        answerPanel.SetActive(true);
    }
    public void CloseAnswerPanel()
    {
        //answerIntruction.SetActive(false);
        //buttonSend.SetActive(false);
        //makeSmall = true;
        StartCoroutine(FadeOutAnswer());

        //inputText.transform.localScale *= 0.25f;
    }
    IEnumerator FadeOutAnswer()
    {
        yield return new WaitForSeconds(1f);
        answerPanel.SetActive(false);
    }
    public void closeEmailPanel()
    {
        emailPanel.SetActive(false);
    }
    bool makeSmall;
    public void littleMessage()
    {
        makeSmall = true;
    }
    int n = 0;
    private void Update()
    {
        if (makeSmall)
            while (inputText.transform.localScale.x > 0.25f && n++ < 200)
            {
                float newScale = Mathf.Lerp(1, 0.25f, Time.time/10);
                inputText.transform.localScale = new Vector3(newScale, newScale, newScale);
                Debug.Log(newScale + " smaller");
            }
    }
}
