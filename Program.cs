public class Program
{
    public static void Main(string[] args)
    {
        Network network = new Network(3, 3);
        int[] outputs = network.Compute(0, 1, 0);
        for (int i = 0; i < outputs.Length; i++)
        {
            Console.Write(outputs[i] + ", ");
        }
        Console.WriteLine();

        Console.ReadLine();
    }
}

class Network
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

        Layer next = Start;
        while (next.Next != null)
        {
            outputs = next.Compute(outputs);
            next = next.Next;
        }

        return outputs;
    }
}

class Layer
{
    public Layer? Next;
    Node[] Nodes;

    public Layer(int size)
    {
        Next = null;

        Nodes = new Node[size];
        for (int i = 0; i < size; i++)
        {
            if (i == 0)
            {
                Nodes[i] = new Node(new int[] { 0, 0, 0 }, 0);
            }
            else
            {
                Nodes[i] = new Node(new int[] { 1, 1, 1 }, 0);
            }
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

class Node
{
    int[] Weights;
    int Bias;

    public Node(int[] weights, int bias)
    {
        Weights = weights;
        Bias = bias;
    }

    public int Compute(int[] inputs)
    {
        int output = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            output += inputs[i] * Weights[i] + Bias;
        }

        return output;
    }
}