using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class Track
    {
        #region Fields
        private readonly List<Section> _trackSections;
        private readonly bool _isLoopedTrack;
        #endregion

        public Track(List<Section> trackList)
        {
            this._trackSections = trackList;
        }

        public int TotalLength
        {
            get
            {
                int totalLength = 0;
                foreach (Section section in _trackSections)
                {
                    totalLength += section.Length;
                }
                return totalLength;
            }
        }
        public int MaximumSpeed
        {
            get
            {
                int maxSpeed = 0;
                foreach (Section section in _trackSections)
                {
                    if (section.MaxSpeed > maxSpeed)
                    {
                        maxSpeed = section.MaxSpeed;
                    }
                }
                return maxSpeed;
            }
        }

        public Section? StartSection { get => _trackSections[0]; }
    }
}
