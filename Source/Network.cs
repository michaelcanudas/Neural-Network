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
        double cost = AverageCost(inputs, outputs);

        // do things with average cost
    }

    private double AverageCost(double[][] inputs, double[][] outputs)
    {
        double totalCost = 0;
        for (int i = 0; i < inputs.Length; i++)
        {
            totalCost += Cost(inputs[i], outputs[i]);
        }

        return totalCost /= inputs.Length;
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