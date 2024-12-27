using Solutions2024;

string[] lines = File.ReadAllLines("2024/input/input04.txt");
Day04 solver = new();
int result = solver.SolvePart02(lines);
Console.WriteLine(result);
