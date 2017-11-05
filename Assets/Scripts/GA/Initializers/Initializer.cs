using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Initializer : IInitializer
{
    private List<char> ids = new List<char>();

    public void AssignGene(char ID)
    {
        ids.Add(ID);
    }

    public List<Individual> CreateInitialGeneration(int generationSize, int individualSize)
    {
        System.Random rand = new System.Random();
        List<Individual> ret = new List<Individual>(generationSize);
        for (int i = 0; i < generationSize; i++)
        {
            Individual iva = new Individual();
            StringBuilder seq = new StringBuilder();
            seq.Append('B');
            for (int j = 0; j < individualSize - 2; j++)
                seq.Append(ids[rand.Next(ids.Count)]);
            seq.Append('E');
            iva.GeneSequence = seq.ToString();
            ret.Add(iva);
        }
        return ret;
    }
}
