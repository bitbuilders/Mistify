using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuizComponent : MonoBehaviour
{
    [SerializeField] public string Title = null;
    [SerializeField] protected List<QuizComponent> m_Children;

    private void Awake()
    {
        m_Children = new List<QuizComponent>();
        m_Children.Add(this);
    }

    virtual public void Create()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            QuizComponent quizComponent = child.GetComponent<QuizComponent>();
            m_Children.Add(quizComponent);
            quizComponent.Create();
        }
    }

    virtual public QuizIterator CreateIterator()
    {
        return new QuizList(m_Children);
    }
}
