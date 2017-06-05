using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "T13/Neuron_13")]
public class Neuron_13 : ScriptableObject
{
    public float Value;
    public List<Synapse_13> InputSynapses;
    public List<Synapse_13> OutputSynapses;

    private void Awake()
    {
        InputSynapses = new List<Synapse_13>();
        OutputSynapses = new List<Synapse_13>();
    }

    internal void Init(Layer_13 inp)
    {
        foreach (var item in inp.Neurons)
        {
            var s = ScriptableObject.CreateInstance("Synapse_13") as Synapse_13;
            s.Init(item, this);
            item.OutputSynapses.Add(s);
            InputSynapses.Add(s);
        }
    }

    internal float CalculateValue()
    {
        Value = Sigmoid_13.HyperbolicTangtent((float)InputSynapses.Sum(a => a.Weight * a.Input.Value));
        //if(Value<0)
        //Debug.Log();
        return Value;
    }

    internal void Randomize()
    {
        Debug.Log("Randomize!");
    }
}
