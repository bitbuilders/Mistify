using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlip : MonoBehaviour
{
    [SerializeField] Camera m_Camera = null;
    [SerializeField] Color m_GoodColor = Color.blue;
    [SerializeField] Color m_BadColor = Color.red;
    [SerializeField] AnimationCurve m_ColorOverTime = null;

    Color m_Start;

    private void Start()
    {
        m_Start = m_Camera.backgroundColor;
    }

    public void Yay()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(m_Camera.backgroundColor, m_GoodColor));
    }

    public void Nay()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(m_Camera.backgroundColor, m_BadColor));
    }

    IEnumerator Fade(Color start, Color target)
    {
        float speed = 3.0f;
        for (float i = 0.0f; i <= 1.0f; i += Time.deltaTime * speed)
        {
            float t = m_ColorOverTime.Evaluate(i);
            m_Camera.backgroundColor = Color.Lerp(start, target, t);
            yield return null;
        }

        for (float i = 0.0f; i <= 1.0f; i += Time.deltaTime * speed)
        {
            float t = m_ColorOverTime.Evaluate(1.0f - i);
            m_Camera.backgroundColor = Color.Lerp(m_Start, target, t);
            yield return null;
        }

        m_Camera.backgroundColor = m_Start;
    }
}
