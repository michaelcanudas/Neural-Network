/// <Layer>
/// Layer is a linked-list, which contains the
/// next (possibly null) element. It also contains
/// the Nodes which are used in computation.
/// </Layer>
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
            Nodes[i] = new Node(new int[] { 0, 0, 0 }, 0);
        }
    }

    public int[] Compute(int[] inputs)
    {
        int[] outputs = new int[Nodes.Length];
        for (int i = 0; i < outputs.Length; i++)
        {
            outputs[i] = Nodes[i].Compute(inputs);
        }

        return outputs;
    }
}