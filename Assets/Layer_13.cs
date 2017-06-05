using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "T13/Layer_13")]
public class Layer_13 : ScriptableObject
{
    public List<Neuron_13> Neurons;

    private void Awake()
    {
        Neurons = new List<Neuron_13>();
    }

    internal void Init(int neuronCount)
    {
        for (int i = 0; i < neuronCount; i++)
        {
            var n = ScriptableObject.CreateInstance("Neuron_13") as Neuron_13;
            Neurons.Add(n);
        }
    }

    internal void Init(Layer_13 inp, int neuronCount)
    {
        for (int i = 0; i < neuronCount; i++)
        {
            var n = ScriptableObject.CreateInstance("Neuron_13") as Neuron_13;
            n.Init(inp);
            Neurons.Add(n);
        }
    }

    internal void Randomize()
    {
        foreach (var item in Neurons)
        {
            item.Randomize();
        }
    }
}
