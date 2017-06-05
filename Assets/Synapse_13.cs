using UnityEngine;
[CreateAssetMenu(menuName = "T13/Synapse_13")]
public class Synapse_13 : ScriptableObject
{
    public float Weight;

    public Neuron_13 Input;
    public Neuron_13 Output;

    private void Awake()
    {
        Weight = UnityEngine.Random.Range(-1f, 1f);
    }

    internal void Init(Neuron_13 input, Neuron_13 output)
    {
        Input = input;
        Output = output;
    }
}
