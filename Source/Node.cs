/// <Node>
/// Node contains the weights, bias, and
/// activation functions necessary for computing
/// a singular output based on a set of input values.
/// </Node>
public class Node
{
    public int[] Weights;
    public int Bias;

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

        output = ReLU(output);

        return output;
    }

    private int ReLU(int value)
    {
        return Math.Max(0, value);
    }
}