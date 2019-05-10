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

    GameIterator m_GameIterator;

    private void Start()
    {
        m_Quiz.Init();
        m_GameIterator = m_Quiz.CreateGameIterator();
        UpdateText();
    }

    public void CheckCorrect(Button b)
    {
        Debug.ClearDeveloperConsole();
        if (b.GetComponentInChildren<Text>().text == m_GameIterator.Correct)
        {
            print("Correct!");
        }
        else
        {
            print("Incorrect");
        }

        Next();
        if (m_GameIterator.Finished)
        {
            Finish();
        }
    }

    public void Next()
    {
        m_GameIterator.Next();
        UpdateText();
    }

    void UpdateText()
    {
        m_GenreText.text = m_GameIterator.GenreText;
        m_TopicText.text = m_GameIterator.TopicText;
        m_QuestionText.text = m_GameIterator.QuestionText;
        for (int i = 0; i < m_Answers.Count; i++)
        {
            m_Answers[i].GetComponentInChildren<Text>().text = m_GameIterator.Answers[i];
        }
    }

    void Finish()
    {
        print("Done!");

    }
}
