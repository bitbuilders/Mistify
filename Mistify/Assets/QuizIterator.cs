using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuizIterator : IEnumerator
{
    protected List<QuizComponent> m_Components;
    protected int m_Index = -1;

    protected QuizIterator(List<QuizComponent> components)
    {
        m_Components = components;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public QuizComponent Current
    {
        get
        {
            return m_Components[m_Index];
        }
    }
    
    virtual public bool MoveNext()
    {
        m_Index++;
        return m_Index < m_Components.Count;
    }

    virtual public void Reset()
    {
        m_Index = -1;
    }

    virtual public bool HasNext()
    {
        return m_Index + 1 < m_Components.Count && m_Index >= 0;
    }
}
