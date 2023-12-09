using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

int[,] trainData =
{
    { 1 , 2 },
    { 2 , 4 },
    { 3 , 6 },
    { 4 , 8 }
};

float rand(float min,float max)
{
    var r = new Random().Next();
    return (r % (max - min) + min) + ((float)r / int.MaxValue);
}

float cost(float w,float b)
{
    int trainCount = trainData.Length / 2;
    float result = 0;
    for (int i = 0; i < trainCount; i++)
    {
        float x = trainData[i, 0];
        float y = x * w + b;
        float def = (y - trainData[i, 1]);
        result += def * def;
    }

    return result / trainCount;
}


void train(float rate,float eps)
{


    float w = 7;//rand(0, 10);
    float b = 5;// rand(0, 10);


    for (int i = 0; i < 100_000; i++)
    {

        float c = cost(w, b);
        float deff = (cost(w + eps, b) - c);
        w -= deff * rate;

        deff = (cost(w, b + eps) - c);

        b -= deff * rate;


        //Console.WriteLine($"Cost : {c,10}, w = {w,5}, b = {b,5}" );
    }

    Console.WriteLine($"Final Cost : {cost(w, b),10}, w = {w,5}, b = {b,5}");
    Console.WriteLine("Result : " + w * 5);

    
}

int run()
{
    float eps = 0.01f;
    float rate = 0.01f;

    train(rate, eps);
    
    return 0;
}

run();
