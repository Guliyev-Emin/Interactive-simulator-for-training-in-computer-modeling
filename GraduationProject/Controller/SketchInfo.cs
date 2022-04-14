using System.Collections.Generic;

namespace GraduationProject.Controller
{
    public class SketchInfo
    {
        public string SketchName { get; set; }

        public bool PointStatus { get; set; }
        public int PointCount { get; set; }
        public List<string> PointCoordinates { get; set; }

        public bool LineStatus { get; set; }
        public int LineCount { get; set; }
        public List<string> LineCoordinates { get; set; }

        public bool ArcStatus { get; set; }
        public int ArcCount { get; set; }
        public List<string> ArcCoordinates { get; set; }

        public bool EllipseStatus { get; set; }
        public int EllipseCount { get; set; }
        public List<string> EllipseCoordinates { get; set; }

        public bool ParabolaStatus { get; set; }
        public int ParabolaCount { get; set; }
        public List<string> ParabolaCoordinates { get; set; }
    }
}