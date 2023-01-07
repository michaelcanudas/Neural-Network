/// <Program>
/// Program is the entry-point of the neural network,
/// and is used as a CLI for processing data.
/// </Program>
public class Program
{
    public static void Main(string[] args)
    {
        Network network = new Network(3, 3);
        double[] outputs = network.Compute(0, 1, 0);
    }
}