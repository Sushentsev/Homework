namespace Task_1.Tests
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Text.RegularExpressions;
    using Task_1.Model;

    /// <summary>
    /// Loads data from file.
    /// </summary>
    public class DataClass
    {
        public DataClass(string linesPath, string pointsPath)
        {
            this.Lines = new List<Line>();
            this.Points = new List<IList<Point>>();
            this.LoadLines(linesPath);
            this.LoadPoints(pointsPath);
        }

        public IList<Line> Lines { get; }

        public IList<IList<Point>> Points { get; }

        private void LoadLines(string path)
        {
            try
            {
                using (var file = new StreamReader(Path.GetFullPath(path)))
                {
                    while (!file.EndOfStream)
                    {
                        var line = file.ReadLine();
                        var bits = Regex.Split(line, @"\D+");

                        var p1 = new Point(int.Parse(bits[1]), int.Parse(bits[2]));
                        var p2 = new Point(int.Parse(bits[3]), int.Parse(bits[4]));

                        this.Lines.Add(new Line(p1, p2));
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException($"The file could not be read: {e.Message}");
            }
        }

        private void LoadPoints(string path)
        {
            try
            {
                using (var file = new StreamReader(Path.GetFullPath(path)))
                {
                    var index = 0;

                    while (!file.EndOfStream)
                    {
                        this.Points.Add(new List<Point>());

                        var line = file.ReadLine();
                        var bits = Regex.Split(line, @"\D+");

                        for (var i = 1; i <= bits.Length - 2; i+=2)
                        {
                            this.Points[index].Add(new Point(int.Parse(bits[i]), int.Parse(bits[i + 1])));
                        }

                        ++index;
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException($"The file could not be read: {e.Message}");
            }
        }
    }
}