using System;
using System.Collections.Generic;
using System.Linq;


namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<PianoPiece> myPieces = GetAllPieces(number);

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] line = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = line[1];
                var matches = HasAny(piece, myPieces);

                if (line[0] == "Add")
                {
                    string composer = line[2];
                    string key = line[3];

                    if (matches)
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        myPieces.Add(CreateNewPiece(piece, composer, key));
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (line[0] == "Remove")
                {
                    if (!matches)
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        var removePiece = myPieces.FirstOrDefault(x => x.Piece == piece);
                        myPieces.Remove(removePiece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                }
                else if (line[0] == "ChangeKey")
                {
                    string newKey = line[2];
                    if (!matches)
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        var replace = myPieces.FirstOrDefault(x => x.Piece == piece);
                        replace.Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                }

                input = Console.ReadLine();
            }

            PrintList(myPieces);
        }

        private static void PrintList(List<PianoPiece> myPieces)
        {
            var ordered = myPieces.OrderBy(x => x.Piece).ThenBy(x => x.Composer);
            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Piece} -> Composer: {item.Composer}, Key: {item.Key}");
            }
        }

        private static PianoPiece CreateNewPiece(string piece, string composer, string key)
            => new PianoPiece()
            {
                Piece = piece,
                Composer = composer,
                Key = key
            };

        private static bool HasAny(string piece, List<PianoPiece> myPieces)
            => myPieces.Any(x => x.Piece == piece);


        private static List<PianoPiece> GetAllPieces(int number)
        {
            List<PianoPiece> myPieces = new List<PianoPiece>();

            for (int i = 0; i < number; i++)
            {
                string[] pieceInput = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string piece = pieceInput[0];
                string composer = pieceInput[1];
                string key = pieceInput[2];

                myPieces.Add(CreateNewPiece(piece, composer, key));
            }

            return myPieces;
        }
    }
}
