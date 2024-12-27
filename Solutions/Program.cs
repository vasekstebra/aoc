using Solutions2024;

string[] lines = File.ReadAllLines("2024/input/input03.txt");
Day03 solver = new();
int result = solver.SolvePart02(lines);
Console.WriteLine(result);
