using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class TrackBuilder
    {
        #region Fields
        private readonly (int Start, int End)[] _sectionDetails;
        private readonly Track? _raceTrack;
        #endregion

        #region Properties
        public Track? RaceTrack => _raceTrack;
        #endregion

        #region Constructor
        public TrackBuilder((int Start, int End)[] sectionDetails, bool isTrackLooping = false)
        {
            _sectionDetails = sectionDetails; 

            List<Section> sections = new List<Section>();
            Section? previousSection = null;

            foreach ((int start, int end) in _sectionDetails)
            {
                Section currentSection = new Section(start, end); // For Unit Test purposes

                if (sections.Count > 0)
                {
                    previousSection!.AddAfterMe(currentSection);
                }

                previousSection = currentSection;
                sections.Add(currentSection); // Add sections to the list
            }

            _raceTrack = new Track(sections, isTrackLooping); // For TrackBuilderTest
        }
        #endregion
    }
}
