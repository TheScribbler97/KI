using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UXRecombiner : IRecombiner
{
    public string Combine(string parentA, string parentB)
    {
        System.Random rand = new System.Random();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < parentA.Length; i++)
            sb.Append(rand.Next(100)>=50?parentA[i]:parentB[i]);
        return sb.ToString();
    }
}
