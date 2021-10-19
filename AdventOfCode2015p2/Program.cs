using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2015p2
{
    class Program
    {
        class PacketMeasurement
        {
            public int lenght { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        static PacketMeasurement ConvertStringToMeasurement(string measurement)
        {
            PacketMeasurement Ameasurement = new PacketMeasurement();
            string sign = "";
            string stringValue = "";
            int value = 0;
            int distanceNumber = 0;
            int lengthValue = 0;
            int widthValue = 0;
            int heightValue = 0;
            for (int i = 0; i <= measurement.Length; i++)
            {
                try
                {
                    sign = Convert.ToString(measurement[i]);
                }
                catch (IndexOutOfRangeException)
                {
                    sign = "x";
                }
                switch (sign)
                {
                    case "1":
                        stringValue = stringValue + sign;
                        break;
                    case "2":
                        stringValue = stringValue + sign;
                        break;
                    case "3":
                        stringValue = stringValue + sign;
                        break;
                    case "4":
                        stringValue = stringValue + sign;
                        break;
                    case "5":
                        stringValue = stringValue + sign;
                        break;
                    case "6":
                        stringValue = stringValue + sign;
                        break;
                    case "7":
                        stringValue = stringValue + sign;
                        break;
                    case "8":
                        stringValue = stringValue + sign;
                        break;
                    case "9":
                        stringValue = stringValue + sign;
                        break;
                    case "0":
                        stringValue = stringValue + sign;
                        break;

                    default:
                        value = Convert.ToInt32(stringValue);
                        stringValue = "";
                        if (distanceNumber == 2)
                        {
                            heightValue = value;
                            distanceNumber++;
                        }
                        if (distanceNumber == 1)
                        {
                            widthValue = value;
                            distanceNumber++;
                        }
                        if (distanceNumber == 0)
                        {
                            lengthValue = value;
                            distanceNumber++;
                        }
                        break;
                }
            }
            Ameasurement.lenght = lengthValue;
            Ameasurement.width = widthValue;
            Ameasurement.height = heightValue;
            return Ameasurement;
        }


        static void Main(string[] args)
        {
            var measurements = File.ReadAllLines("C:\\Users\\christian\\Documents\\advent of code\\2015\\p2\\santas helpers wrap measurements.txt");
            List<PacketMeasurement> christmasPresents = new List<PacketMeasurement>();
            var amountOfWrapPaper = 0;
            foreach (var measure in measurements)
            {
                christmasPresents.Add(ConvertStringToMeasurement(measure));
            }
            foreach (var package in christmasPresents)
            {
                amountOfWrapPaper = amountOfWrapPaper + calculatePackageArea(package);
            }
            Console.WriteLine(amountOfWrapPaper);
            Console.ReadLine();
        }

        private static int calculatePackageArea(PacketMeasurement package)
        {
            var lengthWidthArea = 2 * package.lenght * package.width;
            var lengthHeightArea = 2 * package.lenght * package.height;
            var widthHeightArea = 2 * package.width * package.height;
            var lowestArea = 0;
            if ((lengthWidthArea < lengthHeightArea )&&(lengthWidthArea<widthHeightArea))
            {
                lowestArea = lengthWidthArea/2;
            }
            else if ((lengthHeightArea<lengthWidthArea)&&(lengthHeightArea<widthHeightArea))
            {
                lowestArea = lengthHeightArea/2;
            }
            else if ((widthHeightArea < lengthWidthArea)&&(widthHeightArea<lengthHeightArea))
            {
                lowestArea = widthHeightArea/2;
            }
            return (lengthWidthArea + lengthHeightArea + widthHeightArea + lowestArea);
        }
    }
}
