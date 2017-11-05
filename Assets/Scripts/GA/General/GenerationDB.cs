using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationDB : MonoBehaviour {

    public GenerationStore generationStore;

    private List<Individual> topIndividuals;

    public int GenerationCount
    {
        get
        {
            return generationStore.generations.Count;
        }
    }

    public Generation CurrentGeneration
    {
        get
        {
            return generationStore.generations[generationStore.generations.Count-1];
        }
    }

    public List<string> CurrentSequences
    {
        get
        {
            List<string> ind = new List<string>();
            foreach(Individual individual in CurrentGeneration.Individuals)
            {
                ind.Add(individual.GeneSequence);
            }
            return ind;
        }
    }

    public Generation NewGeneration
    {
        get
        {
            UpdateHighScoreList(CurrentGeneration);
            Generation gen = new Generation();
            generationStore.generations.Add(gen);
            return gen;
        }
    }



    public Generation GetGeneration(int generation)
    {
        return generationStore.generations[generation];
    }

    public Individual GetFittestIndividualFromHistory()
    {

        if (generationStore.generations[0].Individuals.Count == 0)
            return null;
        Individual fittest = generationStore.generations[0].Individuals[0];
        foreach (Generation gen in generationStore.generations)
        {
            Individual potentialFittest = gen.Fittest;
            if (potentialFittest.Fitness > fittest.Fitness)
            {
                fittest = potentialFittest;
            }
        }
        return fittest;
    }
    
    void Awake () {

        generationStore = new GenerationStore();
        generationStore.generations = new List<Generation>();
        generationStore.generations.Add(new Generation());
        topIndividuals = new List<Individual>();
	}


    public void Reset()
    {
        generationStore = new GenerationStore();
        generationStore.generations = new List<Generation>();
        generationStore.generations.Add(new Generation());
    }

    public void UpdateHighScoreList(Generation gen)
    {
        topIndividuals.AddRange(gen.Individuals);
        topIndividuals.Sort((x, y) => x.fitnessValue.CompareTo(y.fitnessValue));
        topIndividuals.RemoveRange(10, topIndividuals.Count - 10);
        topIndividuals.Sort((x, y) => x.fitnessValue.CompareTo(y.fitnessValue));
        HighScoreManager.SetHighScores(topIndividuals);
    }
    public class GenerationStore
    {
        public List<Generation> generations;


    }

    public class Generation
    {
        public List<Individual> individuals;

        public List<Individual> Individuals
        {
            get
            {
                return individuals;
            }
        }
        
        public Generation()
        {
            individuals = new List<Individual>();
        }

        public void Add(Individual newIndividual)
        {
            individuals.Add(newIndividual);
        }
        public void Add(List<Individual> newIndividuals)
        {
            individuals.AddRange(newIndividuals);
        }
        public void Add(List<string> newIndividuals)
        {
            foreach(string ind in newIndividuals)
            {
                Individual individual = new Individual();
                individual.GeneSequence = ind;
                individuals.Add(individual);
            }
        }

        public void Sort()
        {
            individuals.Sort((x, y) => x.Fitness.CompareTo(y.Fitness));
        }

        public Individual Fittest
        {
            get
            {
                Sort();
                return individuals[0];
            }
        }
    }



}
