public class Program
{
    public static void Main(string[] args)
    {
        double[][] inputs =
        {
            Set(0, 0, 0),
            Set(0, 0, 1),
            Set(0, 1, 0),
            //Set(0, 1, 1), testing value
            Set(1, 0, 0),
            Set(1, 0, 1),
            Set(1, 1, 0),
            Set(1, 1, 1)
        };

        double[][] outputs =
        {
            Set(0, 0, 0),
            Set(0, 0, 0),
            Set(0, 1, 0),
            //Set(0, 1, 0), testing value
            Set(0, 0, 0),
            Set(0, 0, 0),
            Set(0, 1, 0),
            Set(0, 1, 0)
        };

        Network network = new Network(3, 3);
        network.Train(inputs, outputs, 10_000);

        double[] predictions = network.Compute(0, 1, 1);
        for (int i = 0; i < predictions.Length; i++)
        {
            Console.Write(predictions[i] + ", ");
        }
        Console.WriteLine();
    }

    private static double[] Set(params double[] values)
    {
        return values;
    }
}