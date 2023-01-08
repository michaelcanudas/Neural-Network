public class Node
{
    public double[] Weights;
    public double Bias;

    public Node(double[] weights, double bias)
    {
        Weights = weights;
        Bias = bias;
    }

    public double Compute(double[] inputs)
    {
        double output = Bias;
        for (int i = 0; i < inputs.Length; i++)
        {
            output += inputs[i] * Weights[i];
        }

        output = ReLU(output);

        return output;
    }

    // ReLU = { 0, x < 0; x, x >= 0 }
    private double ReLU(double value)
    {
        return Math.Max(0, value);
    }
}