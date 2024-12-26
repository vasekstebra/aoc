using Solutions2024;

string[] lines = File.ReadAllLines("2024/input/input02.txt");
Day01 solver = new();
int result = solver.SolvePart02(lines);
Console.WriteLine(result);
