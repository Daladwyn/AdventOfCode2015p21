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
            var numberOfParcels = 0;
            var measurements = File.ReadAllLines("C:\\Users\\christian\\Documents\\advent of code\\2015\\p2\\santas helpers wrap measurements.txt");
            List<PacketMeasurement> christmasPresents = new List<PacketMeasurement>();
            var amountOfWrapPaper = 0;
            var amountOfRibbon = 0;
            foreach (var measure in measurements)
            {
                christmasPresents.Add(ConvertStringToMeasurement(measure));
            }
            foreach (var package in christmasPresents)
            {
                amountOfWrapPaper = amountOfWrapPaper + calculatePackageArea(package);
                numberOfParcels++;
                //Following two lines is for debuging
                //Console.WriteLine("packet nr {0} behöver {1} papper.", numberOfParcels, amountOfWrapPaper);
                //Console.ReadLine();
            }
            foreach (var package in christmasPresents)
            {
                amountOfRibbon = amountOfRibbon + calculateRibbon(package);
            }
            Console.WriteLine("Antal packet: {0} ", numberOfParcels);
            Console.WriteLine("Antal squarefeet papper som behövs: {0} ", amountOfWrapPaper);
            Console.WriteLine("Antal feet som behövs för att slå in presenterna: {0}", amountOfRibbon);
            Console.ReadLine();
        }

        private static int calculateRibbon(PacketMeasurement package)
        {
            var ribbonOfPackage = 0;
            if ((package.height >= package.width) && (package.height >= package.lenght))
            {
                ribbonOfPackage = package.width * 2 + package.lenght * 2;
            }
            else if ((package.width >= package.height) && (package.width >= package.lenght))
            {
                ribbonOfPackage = package.height * 2 + package.lenght * 2;
            }
            else if ((package.lenght >= package.height) && (package.lenght >= package.width))
            {
                ribbonOfPackage = package.height * 2 + package.width * 2;
            }
            else if ((package.lenght == package.height) && (package.lenght == package.width))
            {
                ribbonOfPackage = package.lenght * 4;
            }
            ribbonOfPackage = ribbonOfPackage + package.height * package.lenght * package.width;
            return ribbonOfPackage;
        }

        private static int calculatePackageArea(PacketMeasurement package)
        {
            var lengthWidthArea = package.lenght * package.width;
            var lengthHeightArea = package.lenght * package.height;
            var widthHeightArea = package.width * package.height;
            var lowestArea = 0;
            if ((lengthWidthArea <= lengthHeightArea) && (lengthWidthArea <= widthHeightArea))
            {
                lowestArea = lengthWidthArea;
            }
            else if ((lengthHeightArea <= lengthWidthArea) && (lengthHeightArea <= widthHeightArea))
            {
                lowestArea = lengthHeightArea;
            }
            else if ((widthHeightArea <= lengthWidthArea) && (widthHeightArea <= lengthHeightArea))
            {
                lowestArea = widthHeightArea;
            }
            //Following line is for debuging
            //Console.WriteLine("Areas is {0},{1},{2}, Smallest is {3}", lengthWidthArea, lengthHeightArea, widthHeightArea, lowestArea);
            return (2 * lengthWidthArea + 2 * lengthHeightArea + 2 * widthHeightArea + lowestArea);
        }
    }
}
