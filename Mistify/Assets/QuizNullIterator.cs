using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizNullIterator : QuizIterator
{
    public QuizNullIterator(List<QuizComponent> components) : base(components) { }

    public override bool MoveNext()
    {
        return false;
    }
}
