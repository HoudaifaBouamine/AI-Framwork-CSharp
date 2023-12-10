using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

int[,] trainData =
{
    { 1 , 2 },
    { 2 , 4 },
    { 3 , 6 },
    { 4 , 8 },

};

double rand(double min,double max)
{
    var r = new Random().Next();
    return (r % (max - min) + min) + ((double)r / int.MaxValue);
}

double cost(double w,double b)
{
    int trainCount = trainData.Length / 2;
    double result = 0;
    for (int i = 0; i < trainCount; i++)
    {
        double x = trainData[i, 0];
        double y = x * w + b;
        double def = (y - trainData[i, 1]);
        result += def * def;
    }

    return result / trainCount;
}

double train(double rate,double eps)
{


    double w = 7;//rand(0, 10);
    double b = 5;// rand(0, 10);


    for (int i = 0; i < 5000; i++)
    {

        double c = cost(w, b);
        double deff = (cost(w + eps, b) - c);
        w -= deff * rate;

        deff = (cost(w, b + eps) - c);

        b -= deff * rate;


        //.WriteLine($"Cost : {c,10}, w = {w,5}, b = {b,5}" );
    }

    double finalCost = cost(w, b);

    //if (finalCost < 0.2)
    //{
    //    Console.WriteLine($"Final Cost : {finalCost,10}, w = {w,5}, b = {b,5}");
    //    Console.WriteLine("Result : " + w * 5);
    //}
    return finalCost;
}

void trainTheTrainer(double w_rate,double w_eps) 
{
    double eps = 0.01f;
    double rate = 0.000001f;
    double c = 100;
    for(int i = 0; i < 100_000; i++)
    {
        c = train(w_rate, w_eps); 
        double dw_rate = (train(w_rate + eps, w_eps      ) - c) / eps;
        double dw_eps  = (train(w_rate      , w_eps + eps) - c) / eps;

        w_rate -= dw_rate * rate;
        w_eps  -= dw_eps  * rate;

        if(i % 1000 == 0)
            Console.WriteLine($"\nround {i,8}, w rate : {w_rate,8}, w eps : {w_eps,8} => cost = {c,8}");
    }
    Console.WriteLine("End");
            Console.WriteLine($"\nround {100_000,8}, w rate : {w_rate,8}, w eps : {w_eps,8} => cost = {c,8}");

}
int run()
{
    double eps = 0.02f;
    double rate = 0.02f;

    // The training resut : rate : 0.2481 & eps = 0.1194  in 5000 test => cost = 0.1197 

    trainTheTrainer(rate, eps);
    
    return 0;
}

run();
