/// <Node>
/// Node contains the weights, bias, and
/// activation functions necessary for computing
/// a singular output based on a set of input values.
/// </Node>
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

    private double ReLU(double value)
    {
        return Math.Max(0, value);
    }
}