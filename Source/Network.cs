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

    public double[] Compute(params double[] inputs)
    {
        double[] outputs = inputs;

        Layer? next = Start;
        while (next is not null)
        {
            outputs = next.Compute(outputs);
            next = next.Next;
        }

        return outputs;
    }

    public void Train(double[][] inputs, double[][] outputs, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            Train(inputs, outputs);
        }
    }

    private void Train(double[][] inputs, double[][] outputs)
    {
        double cost = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            cost += Cost(inputs[i], outputs[i]);
        }
        cost /= inputs.Length;

        // do things with average cost
    }

    // Cost = (Σ |p - o|) / n
    private double Cost(double[] inputs, double[] outputs)
    {
        double[] predictions = Compute(inputs);

        double error = 0;
        for (int i = 0; i < predictions.Length; i++)
        {
            error += Math.Abs(predictions[i] - outputs[i]);
        }
        error /= predictions.Length;

        return error;
    }
}