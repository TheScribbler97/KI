using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessFunction : IFitnessFunction
{
    public float DetermineFitness(CarState state)
    {
        return state.DistanceFromGoal()+state.AngleToGoal()*10+state.CurrentVelocity()*10+state.NumberOfCollisions()*1000;
    }
}
 