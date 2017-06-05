using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Bot_13 : MonoBehaviour
{
    public bool canMove;
    public bool canRotate;
    public float Fitness;
    [Space(5)]
    public int Inputs;
    public List<int> Hiddens;
    public int Outputs;
    [Space(5)]
    public float[] Output;

    public NN_13 NN;
    public int IgnoreLayer;
    private Vector3 StartPoint;
    private Leg_Controller_1[] Legs;
    private Torso_Controller_1 tc;

    private void Start()
    {
        StartPoint = transform.root.position;
        Legs = GetComponentsInChildren<Leg_Controller_1>();
        tc = GetComponentInChildren<Torso_Controller_1>();
        //NN = ScriptableObject.CreateInstance("NN_13") as NN_13;
        //NN.Init(Inputs, Hiddens, Outputs);
    }

    public void Init(NN_13 nn)
    {
        NN = nn;
    }

    private void FixedUpdate()
    {
        if (NN == null)
        {
            return;
        }

        float[] inps = new float[Inputs];

        for (int i = 0; i < Legs.Length; i++)
        {
            inps[i] = Legs[i].GetLegAngle();
            //Debug.Log("Inp: "+ inps[i]);
        }

        Output = NN.Compute(inps);
        //Debug.Log(Output[0]+" - " + Output[1] + " - " + Output[2] + " - " + Output[3]);
        for (int i = 0; i < Legs.Length; i++)
        {
            Legs[i].Force = Output[i];
            //Debug.Log("Out: " + Output[i]);
        }

        Fitness = Mathf.Abs(Vector3.Distance(Vector3.zero, tc.transform.position));
        //Fitness = Mathf.Abs(tc.transform.position.x);
    }
}
