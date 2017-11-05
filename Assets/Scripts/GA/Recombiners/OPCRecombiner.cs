using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class OPCRecombiner : IRecombiner
{
    public string Combine(string parentA, string parentB)
    {
        int crosspoint = new System.Random().Next(parentA.Length);
        StringBuilder sb = new StringBuilder(parentA);
        sb.Length = crosspoint;
        sb.Append(parentB.Substring(crosspoint));
        return sb.ToString();
    }
}
