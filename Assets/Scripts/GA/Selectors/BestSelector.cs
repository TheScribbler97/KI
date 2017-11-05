using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestSelector : ISelector
{
    public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
    {
        List<string> best50 = new List<string>();
        parentGeneration.Individuals.Sort((i1,i2)=>(int)(i1.Fitness*100-i2.Fitness*100));
        foreach (Individual iva in parentGeneration.Individuals)
            best50.Add(iva.GeneSequence);
        best50.RemoveRange(best50.Count/2,best50.Count/2);
        System.Random rand = new System.Random();
        List<string> ret = new List<string>();
        for (int i = 0; i < parentGeneration.Individuals.Count * 2; i++)
            ret.Add(best50[rand.Next(best50.Count)]);
        return ret;
    }
}
