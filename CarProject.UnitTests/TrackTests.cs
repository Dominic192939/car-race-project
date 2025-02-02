using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarProject.Logic;

namespace CarProject.UnitTests
{
    [TestClass]
    public class TrackTests
    {
        [TestMethod]
        public void ItShouldSaveTheStartSectionOfATrack_GivenAnyNumberOfSections()
        {
            Section startSection = new(50, 300);
            Section middleSection = new(70, 500);
            Section lastSection = new(60, 200);
            List<Section> sections = new() { startSection, middleSection, lastSection };

            Track track = new(sections);

            Assert.AreEqual(startSection, track.StartSection);
        }

        [TestMethod]
        public void ItShouldReturnTotalLength_GivenMultipleSections()
        {
            Section startSection = new(50, 300);
            Section middleSection = new(70, 500);
            Section lastSection = new(60, 200);
            List<Section> sections = new() { startSection, middleSection, lastSection };

            Track track = new(sections);

            Assert.AreEqual(1000, track.TotalLength);
        }
    }
}
