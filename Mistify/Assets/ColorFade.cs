using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFade : MonoBehaviour
{
    [SerializeField] Image m_Image = null;
    [SerializeField] Gradient m_ColorOverTime = null;
    [SerializeField] [Range(0.0f, 5.0f)] float m_TransitionTime = 1.0f;

    float m_Target = 0.0f;
    float m_Time = 0.0f;
    float m_Speed = 0.0f;

    private void Start()
    {
        m_Speed = 1.0f / m_TransitionTime;
    }

    private void Update()
    {
        float diff = m_Target - m_Time;
        if (m_Target == m_Time || Mathf.Abs(m_Time) > 1.0f) return;

        float sign = Mathf.Sign(diff);
        m_Time += Time.deltaTime * m_Speed * sign;
        m_Time = Mathf.Clamp(m_Time, 0.0f, 1.0f);

        m_Image.color = m_ColorOverTime.Evaluate(m_Time);
    }

    public void FadeIn()
    {
        m_Target = 1.0f;
    }

    public void FadeOut()
    {
        m_Target = 0.0f;
    }
}
