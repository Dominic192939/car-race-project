namespace CarProject.Logic
{
    public class Track
    {
        #region Fields
        private readonly List<Section> _trackSections;
        private readonly bool _isLoopedTrack;
        #endregion

        #region Properties
        public Section? StartSection
        {
            get
            {
                if (_trackSections.Count > 0)
                {
                    return _trackSections[0];
                }
                return null;
            }
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

        public bool IsLoopedTrack
        {
            get
            {
                return _isLoopedTrack;
            }
        }
        #endregion

        #region Methods
        public void PrintSectionDebugInfo(int sectionIndex)
        {
            if (_trackSections.Count == 0)
            {
                Console.WriteLine("The track is empty.");
                return;
            }

            if (sectionIndex == -1)
            {
                for (int index = 0; index < _trackSections.Count; index++)
                {
                    PrintSectionDebugInfo(index);
                }
            }
            else if (sectionIndex < 0 || sectionIndex >= _trackSections.Count)
            {
                Console.WriteLine("Section index is out of range.");
            }
            else
            {
                Console.WriteLine(_trackSections[sectionIndex].ToString());
            }
        }
        #endregion

        #region Constructor
        public Track(List<Section>? sections, bool isLoopedTrack = false)
        {
            if (sections == null || sections.Count == 0)
            {
                throw new ArgumentNullException();
            }

            _trackSections = sections;
            _isLoopedTrack = isLoopedTrack;

            if (_isLoopedTrack)
            {
                Section lastSection = _trackSections[^1];
                Section firstSection = _trackSections[0];
                lastSection.AddAfterMe(firstSection);
            }
        }
        #endregion
    }
}
