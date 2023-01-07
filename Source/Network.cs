/// <Network>
/// Network contains the linked-list of Layers, as
/// well as the start of the Compute chain.
/// </Network>
public class Network
{
    Layer Start;

    public Network(params int[] layout)
    {
        Start = new Layer(layout[0]);

        Layer next = Start;
        for (int i = 1; i < layout.Length; i++)
        {
            next.Next = new Layer(layout[i]);
            next = next.Next;
        }
    }

    public int[] Compute(params int[] inputs)
    {
        int[] outputs = inputs;

        Layer? next = Start;
        while (next is not null)
        {
            outputs = next.Compute(outputs);
            next = next.Next;
        }

        return outputs;
    }
}