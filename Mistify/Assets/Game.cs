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
    [SerializeField] AudioClip m_CorrectSound = null;
    [SerializeField] AudioClip m_FailSound = null;

    AudioSource m_AudioSource;
    ColorBlip m_ColorBlip;
    GameIterator m_GameIterator;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_ColorBlip = GetComponent<ColorBlip>();
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
            PlayClip(m_CorrectSound, 1.0f);
            m_ColorBlip.Yay();
        }
        else
        {
            print("Incorrect");
            PlayClip(m_CorrectSound, 0.4f);
            m_ColorBlip.Nay();
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

    void PlayClip(AudioClip clip, float pitch)
    {
        m_AudioSource.clip = clip;
        m_AudioSource.pitch = pitch;
        m_AudioSource.Play();
    }
}
