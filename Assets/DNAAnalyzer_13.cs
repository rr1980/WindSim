using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public static class DNAAnalyzer_13
{
    public static List<float> ReadNN(NN_13 nn)
    {
        List<float> netraw = new List<float>();

        foreach (var l in nn.Layers)
        {
            foreach (var n in l.Neurons)
            {
                foreach (var i in n.OutputSynapses)
                {
                    netraw.Add(i.Weight);
                }
            }
        }

        return netraw;
    }

    public static NN_13 BuildNN(List<float> nn, int inputs, List<int> hiddens, int outputs)
    {
        var NN = ScriptableObject.CreateInstance("NN_13") as NN_13;
        NN.Init(inputs, hiddens, outputs);
        int index = 0;

        for (int l = 0; l < NN.Layers.Count; l++)
        {
            for (int n = 0; n < NN.Layers[l].Neurons.Count; n++)
            {
                for (int s = 0; s < NN.Layers[l].Neurons[n].OutputSynapses.Count; s++)
                {
                    NN.Layers[l].Neurons[n].OutputSynapses[s].Weight = nn[index];
                    index++;
                }
            }
        }

        return NN;
    }

    public static List<List<float>> Sex(List<float> rawnn0, List<float> rawnn1, int crossFactor, float mutateChance, float perbetuation)
    {
        var childs = cross(rawnn0, rawnn1, crossFactor);
        List<float> c1 = mutation(childs[0], mutateChance, perbetuation);
        List<float> c2 = mutation(childs[1], mutateChance, perbetuation);

        return new List<List<float>>() { c1, c2 };
    }

    private static List<float> mutation(List<float> n, float mutateChance, float perbetuation)
    {
        for (int i = 0; i < n.Count; i++)
        {
            if (UnityEngine.Random.Range(0f, 1f) < mutateChance)
            {
                var t = UnityEngine.Random.Range(-1f, 1f) * perbetuation;
                n[i] = Math.Min(0.99f, Math.Max(n[i] + t, -0.99f));
            }
        }

        return n;
    }

    private static List<List<float>> cross(List<float> rawnn0, List<float> rawnn1, int crossFactor)
    {
        List<float> p0 = new List<float>();
        List<float> p1 = new List<float>();
        List<int> crosses = buildCrosses(crossFactor, rawnn0.Count);
        int cross_index = 0;
        bool cross = false;

        for (int i = 0; i < rawnn0.Count; i++)
        {
            if (i == crosses[cross_index])
            {
                cross = !cross;
                if (cross_index + 1 < crosses.Count)
                {
                    cross_index++;
                }
            }

            if (cross)
            {
                p0.Add(rawnn0[i]);
                p1.Add(rawnn1[i]);
            }
            else
            {
                p0.Add(rawnn1[i]);
                p1.Add(rawnn0[i]);
            }
        }

        return new List<List<float>>() { p0, p1 };
    }

    private static List<int> buildCrosses(int crossFactor, int count)
    {
        List<int> crosses = new List<int>();
        for (int i = 0; i < crossFactor + 1; i++)
        {
            crosses.Add(UnityEngine.Random.Range(1, count - 1));
        }

        crosses = crosses.OrderBy(c => c).ToList();

        return crosses;
    }

    internal static void WriteDnasToCsv(List<float> p1, List<float> p2, List<float> c1, List<float> c2)
    {
        var csv = new Dictionary<string, List<float>>
        {
            { "parent_1", p1 },
            { "parent_2", p2 },
            { "child_1", c1 },
            { "child_2", c2 }
        };
        buildCrossDnaCsv(csv);
    }

    private static void buildCrossDnaCsv(Dictionary<string, List<float>> csv)
    {
        var str = String.Empty;
        for (int i = 0; i < csv["parent_1"].Count; i++)
        {
            str += csv["parent_1"][i].ToString() + "," + csv["parent_2"][i].ToString() + "," + csv["child_1"][i].ToString() + "," + csv["child_2"][i].ToString() + Environment.NewLine;
        }

        System.IO.File.WriteAllText("CrossDna_13" + ".csv", str);
    }
}