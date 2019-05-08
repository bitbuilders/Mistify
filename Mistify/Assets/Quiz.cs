using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField] [Range(0, 8)] int m_QuestionsPerSet = 4;

    QuizIterator m_Genres;
    QuizIterator m_Topics;
    QuizIterator m_QuestionSets;
    QuizComponent m_QuizComponent;

    public void Init()
    {
        m_QuizComponent = GetComponent<QuizComponent>();
        m_QuizComponent.Create();
        m_Genres = m_QuizComponent.CreateIterator();
        m_Genres.MoveNext();
    }

    public string SwitchGenre()
    {
        m_Genres.MoveNext();

        m_Topics = m_Genres.Current.CreateIterator();
        m_Topics.MoveNext();

        return m_Genres.Current.Title;
    }

    public string SwitchTopic()
    {
        m_Topics.MoveNext();

        m_QuestionSets = m_Topics.Current.CreateIterator();
        m_QuestionSets.MoveNext();

        return m_Topics.Current.Title;
    }

    public string SwitchQuestionSet()
    {
        m_QuestionSets.MoveNext();

        return m_QuestionSets.Current.Title;
    }

    public List<QuizLeaf> CreateQuestions()
    {
        List<QuizLeaf> questions = new List<QuizLeaf>();
        QuizIterator it = m_QuestionSets.Current.CreateIterator();
        it.MoveNext();
        for (int i = 0; i < m_QuestionsPerSet; i++)
        {
            it.MoveNext();
            questions.Add((QuizLeaf)it.Current);
        }

        return questions;
    }

    public bool HasNextQuestion()
    {
        return m_QuestionSets.HasNext();
    }

    public bool HasNextTopic()
    {
        return m_Topics.HasNext();
    }

    public bool HasNextGenre()
    {
        return m_Genres.HasNext();
    }
}
