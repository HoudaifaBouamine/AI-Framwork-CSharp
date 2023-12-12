
int[,] trainOR =
{
    {0,0,0 },
    {0,1,1 },
    {1,0,1 },
    {1,1,1 }
};

int trainLength = 4;

double activation(double x)
{
    return (Math.Atan((x - 0.5) * 1000) + Math.PI / 2)/Math.PI;
}

double cost(double w1,double w2,double b)
{
    double result = 0;
    for(int i = 0;i < trainLength; i++)
    {
        int x1 = trainOR[i,0];
        int x2 = trainOR[i, 1];
        double deff = activation(w1 * x1 + w2 * x2 + b) - trainOR[i,2];
        result += deff * deff * 5;
    }

    return result;
}

void printXOR(double w1,double w2,double b)
{
    
    Console.WriteLine("\n-----------------------------");
    Console.WriteLine($" x1  x2 =>  y  (expected)");
    for (int i = 0; i < trainLength; i++)
    {
        int x1 = trainOR[i, 0];
        int x2 = trainOR[i, 1];
        int expected_y = trainOR[i, 2];
        float y = (float)activation(w1 * x1 + w2 * x2 + b);

        Console.WriteLine($" {x1} || {x2} => {y,10} (expected : {expected_y})");
    }
    Console.WriteLine("-----------------------------");
}

double train(double rate,double eps)
{
    double c = 100;
    double w1 = 4, w2 = 7, b = 2;

    for(int i = 0; i < 100_000;i++)
    {
        c = cost(w1, w2, b);

        double dw1 = (cost(w1 + eps, w2      , b + eps) - c) / eps;
        double dw2 = (cost(w1      , w2 + eps, b + eps) - c) / eps;
        double db  = (cost(w1      , w2      , b + eps) - c) / eps;

        w1 -= dw1 * rate;
        w2 -= dw2 * rate;
        b  -= db  * rate;

        //Console.WriteLine($"Result : w1 : {w1,6}, w2 : {w2,6}, b : {b,6}");
        if (i % 1000 == 0) {
            Console.WriteLine($"Result : w1 : {w1,25}, w2 : {w2,25}, b : {b,25} => Cost : {c,12}");
            printXOR(w1, w2, b);

        }
    }

//    Console.WriteLine($"Result : w1 : {w1,6}, w2 : {w2,6}, b : {b,6} => Cost : {c,6}");

    return c;

}

int run()
{
    train(0.01,0.1);
    return 0;
}

run();
