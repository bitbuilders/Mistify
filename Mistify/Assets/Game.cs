using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Quiz m_Quiz = null;
    [SerializeField] Text m_GenreText = null;
    [SerializeField] Text m_TopicText = null;
    [SerializeField] Text m_QuestionText = null;
    [SerializeField] List<Button> m_Answers = null;

    Button m_Correct = null;

    private void Start()
    {
        m_Quiz.Init();

        DoNextGenre();
        DoNextTopic();
        DoNextQuestion();
    }

    public void CheckCorrect(Button b)
    {
        if (b == m_Correct)
        {
            print("Correct!");
        }
        else
        {
            print("Incorrect");
        }
    }

    public void Next()
    {
        if (m_Quiz.HasNextQuestion())
        {
            DoNextQuestion();
        }
        else if (m_Quiz.HasNextTopic())
        {
            DoNextTopic();
        }
        else if (m_Quiz.HasNextGenre())
        {
            DoNextGenre();
        }
    }

    void DoNextQuestion()
    {
        m_QuestionText.text = m_Quiz.SwitchQuestionSet();
        List<QuizLeaf> questions = m_Quiz.CreateQuestions();
        for (int i = 0; i < questions.Count; i++)
        {
            m_Answers[i].GetComponentInChildren<Text>().text = questions[i].Title;
            if (questions[i].CorrectAnswer) m_Correct = m_Answers[i];
        }
    }

    void DoNextTopic()
    {
        m_TopicText.text = m_Quiz.SwitchTopic();
    }

    void DoNextGenre()
    {
        m_GenreText.text = m_Quiz.SwitchGenre();
    }
}
