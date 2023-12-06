using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode23
{
    public class Advent02
    {
        public Advent02()
        {
            run();
        }

        void run()
        {
            string input = "Game 1: 7 blue, 6 green, 3 red; 3 red, 5 green, 1 blue; 1 red, 5 green, 8 blue; 3 red, 1 green, 5 blue\r\nGame 2: 9 green, 1 blue, 12 red; 1 blue, 18 green, 8 red; 2 blue, 6 green, 13 red; 3 blue, 13 red, 7 green; 5 blue, 4 red, 4 green; 6 blue, 7 green, 4 red\r\nGame 3: 5 blue, 9 red, 14 green; 10 green, 3 blue; 11 red, 2 blue, 8 green; 5 red, 2 blue; 5 blue, 7 green, 8 red\r\nGame 4: 2 red, 3 blue, 2 green; 17 green, 6 blue, 1 red; 3 blue, 5 green, 1 red; 4 red, 1 blue, 16 green; 5 red, 4 blue, 13 green; 14 green, 5 blue, 6 red\r\nGame 5: 3 red, 17 green, 10 blue; 9 blue, 5 green; 14 green, 9 blue, 11 red\r\nGame 6: 4 green, 18 blue, 3 red; 6 green, 8 blue, 9 red; 4 green, 9 blue, 7 red; 9 red, 1 green, 12 blue\r\nGame 7: 1 blue, 14 green; 1 red, 4 blue, 15 green; 3 blue, 6 green; 3 blue, 2 green, 1 red; 1 red, 3 green, 1 blue\r\nGame 8: 10 red, 3 blue, 3 green; 5 blue, 7 red, 3 green; 3 red, 3 green, 11 blue; 1 red, 7 green, 10 blue; 13 blue, 5 green, 5 red; 1 green, 17 blue, 3 red\r\nGame 9: 1 blue, 6 green; 7 green, 2 red; 3 red, 2 green; 1 blue, 4 red, 3 green; 7 green, 1 blue, 1 red\r\nGame 10: 14 green, 6 blue, 1 red; 8 green, 5 red, 1 blue; 8 green, 5 blue, 5 red; 2 green, 3 blue, 5 red\r\nGame 11: 1 blue, 2 green; 1 blue, 1 green, 7 red; 1 blue, 4 green, 7 red; 2 red, 2 green, 1 blue\r\nGame 12: 5 blue, 12 green, 12 red; 11 green, 3 red; 14 green, 3 blue, 18 red\r\nGame 13: 2 green, 6 red; 6 red, 5 blue; 7 red, 3 blue, 8 green; 7 red, 8 green; 3 blue, 2 green, 3 red; 1 blue, 8 red, 6 green\r\nGame 14: 18 green, 6 blue, 5 red; 5 blue, 15 red, 19 green; 7 green, 11 blue, 20 red; 5 red, 18 green, 7 blue\r\nGame 15: 3 red, 16 green, 1 blue; 11 green, 6 red, 1 blue; 12 green, 2 red; 17 green, 1 blue, 14 red\r\nGame 16: 3 red, 2 green, 5 blue; 1 green, 6 blue, 1 red; 1 green, 2 blue, 3 red; 1 blue, 1 red; 5 blue, 1 green, 2 red\r\nGame 17: 3 blue, 6 red; 1 blue, 2 red; 1 blue, 1 green, 7 red; 1 green, 7 red, 2 blue; 7 red, 1 blue; 1 green, 8 red, 1 blue\r\nGame 18: 6 green, 10 red; 6 red, 7 green; 10 red, 11 green; 10 red, 2 blue, 5 green\r\nGame 19: 2 blue; 1 blue, 4 green, 6 red; 7 green, 6 red, 2 blue; 2 blue, 5 red, 4 green; 1 green, 10 red\r\nGame 20: 6 red, 5 green, 10 blue; 5 blue, 5 green, 9 red; 7 blue, 3 green, 3 red; 9 blue, 12 red, 1 green\r\nGame 21: 4 red, 18 blue, 14 green; 3 green, 14 blue, 5 red; 5 green, 12 blue; 1 blue, 2 red, 1 green; 5 red, 11 green, 7 blue; 17 green, 4 red, 15 blue\r\nGame 22: 1 blue, 14 green, 4 red; 7 green, 10 red; 9 green, 1 blue, 9 red; 1 blue, 8 green, 5 red\r\nGame 23: 4 blue, 5 green, 2 red; 6 blue, 8 red, 4 green; 4 blue, 17 red, 14 green\r\nGame 24: 3 green, 8 blue; 3 blue, 5 green, 13 red; 17 red, 4 green\r\nGame 25: 19 red, 9 blue, 1 green; 3 green, 18 red, 6 blue; 1 green, 7 red, 7 blue; 8 blue, 1 red\r\nGame 26: 10 green, 12 blue, 2 red; 9 red; 10 blue, 12 green, 9 red\r\nGame 27: 2 blue, 8 green, 6 red; 5 green, 9 red; 4 red, 11 green\r\nGame 28: 10 blue, 20 red; 14 blue, 3 green, 2 red; 9 red, 12 blue, 1 green\r\nGame 29: 4 red, 1 blue, 2 green; 1 green, 6 red, 1 blue; 15 red\r\nGame 30: 1 red, 13 blue, 6 green; 3 blue, 4 green; 19 blue, 11 green; 1 red, 11 green, 14 blue\r\nGame 31: 10 red, 12 green; 12 green, 10 red; 2 blue, 15 red, 12 green; 2 green, 2 blue, 15 red; 9 green, 5 red, 2 blue\r\nGame 32: 5 blue, 5 green, 8 red; 5 green, 6 red; 5 blue, 8 red, 4 green; 5 green, 3 blue, 6 red\r\nGame 33: 1 red, 9 green, 5 blue; 17 green, 4 blue; 3 green, 2 blue; 10 green, 2 blue; 1 blue, 4 green; 2 green, 9 blue\r\nGame 34: 11 blue, 11 red, 9 green; 13 red, 3 blue, 5 green; 9 green, 12 blue, 5 red; 13 red, 8 blue, 5 green\r\nGame 35: 1 green, 3 red, 7 blue; 1 red, 3 green, 9 blue; 1 blue, 2 green, 1 red; 11 blue, 5 red, 6 green\r\nGame 36: 4 blue, 12 green, 16 red; 7 blue, 11 green; 8 green, 5 blue, 1 red; 14 green, 3 red\r\nGame 37: 13 red, 5 blue, 9 green; 1 red, 10 blue, 14 green; 1 green, 2 blue, 10 red; 13 red, 10 blue; 1 blue, 8 green\r\nGame 38: 3 red, 4 blue, 8 green; 1 red, 11 blue, 4 green; 13 blue, 8 green; 3 red, 3 green, 10 blue; 1 red, 1 blue, 1 green; 1 green, 2 red, 10 blue\r\nGame 39: 9 red, 7 blue, 1 green; 15 red, 4 green, 1 blue; 2 green, 8 blue, 7 red; 6 blue, 11 red; 12 red, 2 blue, 7 green\r\nGame 40: 13 red, 3 green, 1 blue; 3 green, 10 red; 16 red\r\nGame 41: 1 blue, 3 red; 7 blue, 5 red, 3 green; 4 red, 3 blue, 2 green; 2 blue, 5 red, 1 green; 3 green, 4 red, 3 blue; 5 blue, 2 red\r\nGame 42: 1 red, 4 green; 11 red, 4 green; 13 red; 1 blue, 10 red; 1 blue, 2 red, 4 green\r\nGame 43: 11 green, 13 red, 1 blue; 11 green, 9 red, 2 blue; 7 green; 13 green, 15 red; 1 blue, 14 green\r\nGame 44: 5 green, 14 blue, 15 red; 13 blue, 15 green; 9 green, 15 red, 6 blue\r\nGame 45: 16 red, 8 blue; 1 green, 4 blue, 6 red; 4 blue, 8 red; 12 red, 3 blue, 3 green; 2 green, 4 red, 4 blue; 2 green, 8 blue, 10 red\r\nGame 46: 12 blue, 3 green, 12 red; 9 red, 9 blue; 3 green, 12 red; 10 red, 6 green; 2 red, 7 blue\r\nGame 47: 9 green, 6 red; 1 blue, 7 red, 10 green; 1 green, 2 red; 1 red, 3 green\r\nGame 48: 9 blue, 5 green, 13 red; 14 green, 4 red; 15 red, 9 green, 1 blue; 4 blue, 6 red, 13 green; 9 green, 8 blue, 8 red\r\nGame 49: 5 blue, 3 red; 1 green, 2 red, 5 blue; 1 green, 7 blue; 3 green\r\nGame 50: 8 red, 6 green; 10 blue, 4 green, 6 red; 8 green, 11 blue, 9 red\r\nGame 51: 5 blue; 13 blue; 1 red, 2 blue, 1 green; 1 red, 8 blue\r\nGame 52: 7 blue; 1 red, 2 green, 12 blue; 1 red, 5 blue; 2 red, 7 blue, 4 green; 3 green, 2 red, 2 blue\r\nGame 53: 10 blue, 12 red; 3 green, 5 blue, 3 red; 14 red, 4 green, 7 blue; 1 red, 14 blue\r\nGame 54: 2 blue, 14 red, 3 green; 3 green, 7 red; 2 blue, 3 green, 9 red; 3 green, 7 red; 1 green, 14 red, 1 blue\r\nGame 55: 3 green, 9 red, 12 blue; 5 blue, 5 green, 2 red; 7 green, 14 red, 12 blue\r\nGame 56: 1 blue, 3 red, 4 green; 5 red, 8 green, 1 blue; 3 green, 1 blue, 2 red\r\nGame 57: 8 blue, 13 red, 2 green; 3 blue, 5 red; 7 red, 2 green; 2 red, 5 blue, 3 green; 1 green, 4 blue\r\nGame 58: 4 green, 3 red, 2 blue; 5 green, 2 blue, 10 red; 11 green, 1 red, 2 blue; 4 red, 5 green\r\nGame 59: 5 green; 4 green, 2 blue; 1 red, 9 green; 7 green, 2 blue; 16 green, 1 blue\r\nGame 60: 6 green, 5 blue, 1 red; 5 blue, 3 green, 6 red; 1 green, 5 blue, 14 red; 6 red, 4 blue, 3 green\r\nGame 61: 2 green, 6 red, 6 blue; 6 blue, 3 red; 1 green, 2 red, 2 blue; 1 red, 2 green; 5 red, 1 green, 2 blue; 2 green, 6 red, 6 blue\r\nGame 62: 18 green, 8 blue, 1 red; 8 green, 4 red; 13 blue, 1 red, 3 green; 7 blue, 2 green, 4 red; 4 blue, 12 green, 5 red; 12 green, 11 blue\r\nGame 63: 2 red, 3 blue; 10 green, 13 red, 1 blue; 11 red, 3 green, 4 blue\r\nGame 64: 1 green, 16 red; 17 blue, 9 red, 1 green; 14 red, 7 blue\r\nGame 65: 7 blue, 11 red, 11 green; 7 red, 11 green; 3 blue, 13 red, 11 green; 5 green, 6 blue; 11 blue, 8 red, 3 green\r\nGame 66: 3 blue, 1 green, 3 red; 5 blue, 2 green, 5 red; 1 blue, 2 green, 7 red; 2 blue, 6 red; 7 red, 2 green, 2 blue; 2 red\r\nGame 67: 1 blue, 6 red, 2 green; 1 blue, 10 green, 6 red; 8 red, 2 blue, 4 green; 7 green, 9 red, 1 blue; 8 red, 7 green; 5 green, 1 blue\r\nGame 68: 15 blue, 8 green, 2 red; 6 blue, 2 green; 5 red, 6 green, 8 blue; 6 red, 11 green, 7 blue; 1 red, 3 blue; 5 red, 6 green, 5 blue\r\nGame 69: 5 blue, 4 green; 1 green, 11 red, 9 blue; 4 green, 15 blue, 6 red; 11 blue, 4 green, 5 red; 8 red, 3 green; 5 blue, 8 red\r\nGame 70: 5 blue, 4 red, 8 green; 6 blue, 6 green; 14 blue, 7 red, 1 green; 2 green, 6 blue, 3 red; 7 red, 11 blue, 3 green\r\nGame 71: 13 red, 6 blue, 10 green; 7 red, 12 green; 9 green, 14 red, 2 blue\r\nGame 72: 9 red, 3 green, 3 blue; 8 red, 7 blue, 5 green; 3 blue, 2 green, 1 red; 1 red, 2 blue, 2 green; 10 red, 7 green, 6 blue\r\nGame 73: 4 green, 3 red; 1 red; 2 red, 2 blue, 2 green; 1 blue, 3 red, 1 green; 2 blue, 3 red, 2 green; 1 red, 1 blue\r\nGame 74: 12 green, 4 red, 4 blue; 3 red, 13 green; 1 red, 13 green, 1 blue; 1 red, 3 blue, 6 green; 6 blue, 5 red, 4 green; 7 blue, 5 green, 1 red\r\nGame 75: 11 red, 1 green; 12 blue, 1 red; 2 blue, 1 green, 4 red; 11 red; 12 red, 6 green, 10 blue; 4 green, 5 blue, 7 red\r\nGame 76: 2 blue, 5 red, 6 green; 1 red, 10 green, 11 blue; 7 red, 11 green; 4 red, 10 blue, 10 green; 7 blue, 16 green, 2 red\r\nGame 77: 2 blue, 11 red, 4 green; 6 green, 3 blue, 2 red; 2 blue, 2 red, 7 green; 8 red, 14 blue, 5 green; 5 green, 2 blue, 18 red\r\nGame 78: 9 red, 7 green, 6 blue; 12 blue, 6 red; 1 red, 15 blue, 7 green; 3 blue, 11 green, 1 red\r\nGame 79: 3 blue; 1 blue; 1 red, 1 blue, 1 green; 3 blue; 5 blue, 1 red; 1 blue, 1 green, 1 red\r\nGame 80: 18 blue, 13 green, 7 red; 18 blue, 3 green, 3 red; 2 red, 9 blue, 14 green\r\nGame 81: 11 blue, 6 green, 3 red; 8 green, 12 red, 10 blue; 5 red, 4 blue, 13 green\r\nGame 82: 2 blue, 3 red; 4 blue, 17 red; 9 red; 12 red; 1 green, 6 blue, 7 red; 20 red\r\nGame 83: 1 blue, 1 red; 3 red, 1 blue; 3 red, 5 green; 1 blue, 2 green, 4 red; 5 green, 3 blue, 2 red\r\nGame 84: 4 red, 2 blue, 2 green; 8 red, 10 blue; 1 green, 15 red, 8 blue\r\nGame 85: 15 green; 11 red, 2 blue, 5 green; 8 red, 2 blue, 12 green; 15 red, 10 green; 10 red, 15 green; 17 red, 1 blue, 11 green\r\nGame 86: 6 blue, 1 red; 2 green, 1 red, 8 blue; 2 green, 10 blue; 10 blue, 2 green; 1 red, 5 blue\r\nGame 87: 4 red, 4 blue; 18 red, 8 blue; 16 red; 4 red, 1 green, 3 blue; 14 red, 9 blue\r\nGame 88: 11 green, 7 blue, 4 red; 3 red; 2 blue, 12 red, 19 green; 13 red, 3 blue, 2 green\r\nGame 89: 1 green, 1 red; 1 blue, 1 red, 6 green; 6 green, 3 red; 5 green, 2 red, 6 blue; 7 blue, 2 red, 8 green; 1 red, 2 blue\r\nGame 90: 3 green, 3 red, 3 blue; 5 green, 2 blue, 3 red; 1 blue, 2 red; 11 green, 1 blue, 2 red; 1 green, 3 blue, 4 red\r\nGame 91: 7 blue, 2 red; 2 blue, 1 red, 1 green; 6 blue, 1 red; 1 red, 7 blue\r\nGame 92: 11 green, 16 blue; 17 red, 7 blue, 9 green; 11 green, 3 blue, 12 red; 2 blue, 1 green, 6 red\r\nGame 93: 6 red, 1 blue, 3 green; 1 blue, 8 red, 7 green; 3 red, 5 green; 1 red, 2 green; 3 red, 7 green; 2 green, 15 red, 1 blue\r\nGame 94: 7 blue, 2 red, 2 green; 9 blue, 4 red, 2 green; 9 blue, 5 red, 3 green; 1 blue, 4 red, 3 green; 4 red, 1 green, 7 blue; 9 blue, 3 green, 3 red\r\nGame 95: 1 blue, 2 green, 2 red; 6 green, 6 red, 1 blue; 3 blue, 5 red, 2 green; 1 blue; 5 green, 2 red, 2 blue\r\nGame 96: 3 blue, 6 red, 5 green; 5 blue, 8 green, 9 red; 2 red, 5 green, 1 blue; 6 green, 4 blue, 3 red; 2 green, 2 blue; 6 blue, 4 green\r\nGame 97: 6 green, 8 blue, 5 red; 9 green, 6 blue; 3 green, 3 blue; 2 blue, 10 green, 4 red\r\nGame 98: 11 blue, 1 green, 9 red; 5 green, 1 blue, 6 red; 13 blue, 6 green, 10 red; 6 blue, 4 green, 9 red\r\nGame 99: 4 red, 3 green, 3 blue; 6 blue, 4 green, 11 red; 3 green, 15 red; 1 blue, 6 green, 14 red\r\nGame 100: 14 green, 6 blue, 12 red; 2 green, 1 blue, 2 red; 12 red, 7 blue, 3 green; 1 blue, 12 red, 8 green";

            string[] games = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int counter = 0;

            int max_red = 12;
            int max_green = 13;
            int max_blue = 14;

            int result = 0;
            int power_result = 0;

            foreach (var game in games)
            {
                int min_blue = 0;
                int min_red = 0;
                int min_green = 0;
                bool color_overload = false;

                string[] gameParts = game.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                //string gameNumber = gameParts[0].Trim();
                int gameNumber = Int32.Parse(Regex.Match(gameParts[0].Trim(), @"\d+").Value);
                string colorInfo = gameParts[1].Trim();
                string[] colorQuantities = colorInfo.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                //Console.WriteLine($"Spiel {gameNumber}:");
                //Console.WriteLine($"Info: {colorInfo}");


                foreach (var colorQuantity in colorQuantities)
                {
                    //Console.WriteLine($"Quantity: {colorQuantity}");
                    string[] parts = colorQuantity.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var part in parts)
                    {
                        string resultString = Regex.Match(part, @"\d+").Value;
                        int int_digit = Int32.Parse(resultString);

                        //Console.WriteLine("digit: " + int_digit);
                        if (part.Contains("blue"))
                        {
                            if(min_blue < int_digit) min_blue = int_digit;
                            if (int_digit > max_blue) color_overload = true;
                        }
                        if (part.Contains("red"))
                        {
                            if (min_red < int_digit) min_red = int_digit;
                            if (int_digit > max_red) color_overload = true;
                        }
                        if (part.Contains("green"))
                        {
                            if (min_green < int_digit) min_green = int_digit;
                            if (int_digit > max_green) color_overload = true;
                        }
                    }
                }

                if (!color_overload) result += gameNumber;
                power_result += min_blue * min_red * min_green;
            }

            Console.WriteLine("result: " + result);
            Console.WriteLine("power result " + power_result);
        }
    }
}


