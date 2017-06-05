using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "T13/NN_13")]
public class NN_13 : ScriptableObject
{
    public List<Layer_13> Layers;

    public int Index;

    private void Awake()
    {
        Layers = new List<Layer_13>();
    }

    public void Init(int inputs, List<int> hiddens, int outputs)
    {
        var li = ScriptableObject.CreateInstance("Layer_13") as Layer_13;
        li.Init(inputs);
        Layers.Add(li);

        for (int i = 0; i < hiddens.Count; i++)
        {
            var lh = ScriptableObject.CreateInstance("Layer_13") as Layer_13;
            lh.Init(li, hiddens[i]);
            Layers.Add(lh);
            li = lh;
        }

        var lo = ScriptableObject.CreateInstance("Layer_13") as Layer_13;
        lo.Init(li, outputs);
        Layers.Add(lo);
    }

    internal float[] Compute(float[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            Layers[0].Neurons[i].Value = inputs[i];
        }

        for (int i = 1; i < Layers.Count - 1; i++)
        {
            for (int o = 0; o < Layers[i].Neurons.Count; o++)
            {
                Layers[i].Neurons[o].CalculateValue();
            }
        }

        for (int o = 0; o < Layers.Last().Neurons.Count; o++)
        {
            Layers.Last().Neurons[o].CalculateValue();
        }

        return Layers.Last().Neurons.Select(o => o.Value).ToArray();

        ////InputLayer.ForEach(a => a.Value = inputs[i++]);
        //HiddenLayer1.ForEach(a => a.CalculateValue());
        //if (HiddenLayer2 != null)
        //{
        //    HiddenLayer2.ForEach(a => a.CalculateValue());
        //}
        //if (HiddenLayer3 != null)
        //{
        //    HiddenLayer3.ForEach(a => a.CalculateValue());
        //}
        //OutputLayer.ForEach(a => a.CalculateValue());
    }

    internal void Randomize()
    {
        foreach (var item in Layers)
        {
            item.Randomize();
        }
    }

}

public static class Sigmoid_13
{
    public static float Output(float x)
    {
        //return Math.Tanh(x);
        return x < -45.0f ? 0.0f : x > 45.0f ? 1.0f : 1.0f / (1.0f + (float)Math.Exp(-x));
    }

    public static float HyperbolicTangtent(float x)
    {
        if (x < -45.0f) return -1.0f;
        else if (x > 45.0f) return 1.0f;
        else return (float)Math.Tanh(x);
    }

    public static float BiPolarSigmoid(float a, float p)
    {
        float ap = (-a) / p;
        return (2 / (1 + Mathf.Exp(ap)) - 1);
    }

    public static double Derivative(double x)
    {
        return x * (1 - x);
    }
}
