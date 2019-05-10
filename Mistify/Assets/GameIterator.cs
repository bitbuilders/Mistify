using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameIterator
{
    Quiz m_Quiz;

    public List<string> Answers { get; private set; }
    public string GenreText { get; private set; }
    public string TopicText { get; private set; }
    public string QuestionText { get; private set; }
    public string Correct { get; private set; }
    public bool Finished { get; private set; }

    public GameIterator(Quiz quiz)
    {
        Answers = Enumerable.Repeat("", 4).ToList();

        m_Quiz = quiz;

        DoNextGenre();
        DoNextTopic();
        DoNextQuestion();
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
        else
        {
            Finished = true;
        }
    }

    void DoNextQuestion()
    {
        QuestionText = m_Quiz.SwitchQuestionSet();
        List<QuizLeaf> questions = m_Quiz.CreateQuestions();
        for (int i = 0; i < questions.Count; i++)
        {
            Answers[i] = questions[i].Title;
            if (questions[i].CorrectAnswer) Correct = Answers[i];
        }
    }

    void DoNextTopic()
    {
        TopicText = m_Quiz.SwitchTopic();
    }

    void DoNextGenre()
    {
        GenreText = m_Quiz.SwitchGenre();
    }
}
