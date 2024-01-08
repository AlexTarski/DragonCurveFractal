using System;

namespace Fractals;

internal static class DragonFractalTask
{
    public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
    {
        /*
        Начните с точки (1, 0)
        Создайте генератор рандомных чисел с сидом seed
        
        На каждой итерации:

        1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

            Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
            x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
            y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

            Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
            x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
            y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
    
        2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

        */
        var random = new Random(seed);
        double x = 1;
        double y = 0;
        double sin45 = Math.Sin(45 * Math.PI / 180);
        double cos45 = Math.Cos(45 * Math.PI / 180);
        double sin135 = Math.Sin(135 * Math.PI / 180);
        double cos135 = Math.Cos(135 * Math.PI / 180);
        while (iterationsCount > 0)
        {
            var number = random.Next(2);
            if (number == 1) 
            {
                double x1 = (x * cos45 - y * sin45) / Math.Sqrt(2);
                double y1 = (x * sin45 + y * cos45) / Math.Sqrt(2);
                x = x1;
                y = y1;
                pixels.SetPixel(x, y);
                iterationsCount--;
            }
            else
            {
                double x1 = (x * cos135 - y * sin135) / Math.Sqrt(2) + 1;
                double y1 = (x * sin135 + y * cos135) / Math.Sqrt(2);
                x = x1;
                y = y1;
                pixels.SetPixel(x, y);
                iterationsCount--;
            }
        }
    }
}