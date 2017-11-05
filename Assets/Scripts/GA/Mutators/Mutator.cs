using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Mutator : IMutator
{
    private List<char> ids = new List<char>();

    public void AssignGene(char ID)
    {
        ids.Add(ID);
    }

    public string Mutate(string original)
    {
        StringBuilder sb = new StringBuilder(original);
        for (int i = 0; i < original.Length; i++)
            if (new System.Random().Next(100) >= 90)
                sb[i] = ids[new System.Random().Next(ids.Count)];
        return sb.ToString();
    }
}
