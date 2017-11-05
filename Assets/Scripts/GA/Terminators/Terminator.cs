using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator : ITerminator
{
    public bool JudgementDay(GenerationDB.Generation generation)
    {
        return Math.Abs(generation.Fittest.Fitness) <= 0.2;
    }
}
