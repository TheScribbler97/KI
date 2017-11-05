using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectInitializer : IInitializer
{
    public void AssignGene(char ID)
    {}

    public List<Individual> CreateInitialGeneration(int generationSize, int individualSize)
    {
        List<Individual> lst = new List<Individual>();
        for (int i = 0; i < generationSize; i++)
        {
            Individual iva = new Individual();
            iva.GeneSequence = "BCBCCCCBCEEEBBDDABEADCEEDCDCDE";
            lst.Add(iva);
        }
        return lst;
    }
}
