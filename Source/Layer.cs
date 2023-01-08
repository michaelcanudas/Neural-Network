public class Layer
{
    public Layer? Next;
    Node[] Nodes;

    public Layer(int size)
    {
        Next = null;

        Nodes = new Node[size];
        for (int i = 0; i < size; i++)
        {
            Nodes[i] = new Node(new double[] { 0, 0, 0 }, 0);
        }
    }

    public double[] Compute(double[] inputs)
    {
        double[] outputs = new double[Nodes.Length];
        for (int i = 0; i < outputs.Length; i++)
        {
            outputs[i] = Nodes[i].Compute(inputs);
        }

        return outputs;
    }
}