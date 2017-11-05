using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelector : ISelector
{
    public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
    {
        System.Random rand = new System.Random();
        List<string> ret = new List<string>();
        for(int i = 0; i < parentGeneration.Individuals.Count*2; i++)
            ret.Add(parentGeneration.Individuals[rand.Next(parentGeneration.Individuals.Count)].GeneSequence);
        return ret;
    }
}
