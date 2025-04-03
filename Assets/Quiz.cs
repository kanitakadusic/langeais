using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public GameObject poi;
    public GameObject quiz;
    public Material quizOptionMaterial;
    public Sprite awardIcon;
    public Sprite likeIcon;
    public Sprite medalIcon;

    private int currentQuestionIndex;

    public void QuizHandler(Button button)
    {
        TMP_Text tmp = button.GetComponentInChildren<TMP_Text>();

        switch (tmp.text)
        {
            case "Quiz":
            {
                Initialize();
                tmp.text = "Play";
                button.GetComponentInChildren<Image>().sprite = likeIcon;
                break;
            }
            case "Play":
            {
                Play();
                tmp.text = "Next";
                break;
            }
            case "Next":
            {
                if (!NextQuestion())
                {
                    tmp.text = "Finish";
                    button.GetComponentInChildren<Image>().sprite = medalIcon;
                }
                break;
            }
            case "Finish":
            {
                Deinitialize();
                tmp.text = "Quiz";
                button.GetComponentInChildren<Image>().sprite = awardIcon;
                break;
            }
        }
    }

    private void Initialize()
    {
        poi.SetActive(false);
        quiz.SetActive(true);
        quiz.transform.Find("Welcome").gameObject.SetActive(true);
    }

    private void Play()
    {
        quiz.transform.Find("Welcome").gameObject.SetActive(false);
        currentQuestionIndex = 1;
        ShowQuestion(currentQuestionIndex);
    }

    private void Deinitialize()
    {
        quiz.transform.Find("Goodbye").gameObject.SetActive(false);
        quiz.SetActive(false);
        poi.SetActive(true);
    }

    private bool NextQuestion()
    {
        try
        {
            HideQuestion(currentQuestionIndex);
            ShowQuestion(++currentQuestionIndex);
        }
        catch (Exception)
        {
            quiz.transform.Find("Goodbye").gameObject.SetActive(true);
            return false;
        }

        return true;
    }

    private void ShowQuestion(int questionIndex)
    {
        Transform question = quiz.transform.Find("Q" + questionIndex);
        Transform[] options = question.GetComponentsInChildren<Transform>();

        foreach (Transform option in options)
        {
            if (option.name.StartsWith("Option-"))
            {
                option.GetComponent<Renderer>().material = quizOptionMaterial;
            }
        }

        question.gameObject.SetActive(true);
    }

    private void HideQuestion(int questionIndex)
    {
        quiz.transform.Find("Q" + questionIndex).gameObject.SetActive(false);
    }
}