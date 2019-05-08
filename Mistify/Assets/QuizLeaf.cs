using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizLeaf : QuizComponent
{
    [SerializeField] public bool CorrectAnswer = false;

    public override QuizIterator CreateIterator()
    {
        return new QuizNullIterator(null);
    }
}
