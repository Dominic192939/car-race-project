using CarProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarProject.UnitTests
{
    [TestClass]
    public class TrackBuilderTest
    {
        [TestMethod]
        public void ItShouldBuildAConnectedTrack_ValidateStartSectionLength()
        {
            (int, int)[] sectionDetails = { (10, 10), (20, 20), (30, 30) };
            TrackBuilder builder = new(sectionDetails);

            Assert.AreEqual(10, builder.RaceTrack!.StartSection!.Length);
        }

        [TestMethod]
        public void ItShouldBuildAConnectedTrack_ValidateStartSectionMaxSpeed()
        {
            (int, int)[] sectionDetails = { (10, 10), (20, 20), (30, 30) };
            TrackBuilder builder = new(sectionDetails);

            Assert.AreEqual(10, builder.RaceTrack!.StartSection!.MaxSpeed);
        }

        [TestMethod]
        public void ItShouldBuildAConnectedTrack_ValidateSectionConnections()
        {
            (int, int)[] sectionDetails = { (10, 10), (20, 20), (30, 30) };

            TrackBuilder builder = new(sectionDetails);
            Section firstSection = builder.RaceTrack!.StartSection!;
            Section secondSection = firstSection.NextSection!;
            Section thirdSection = secondSection.NextSection!;

            Assert.AreEqual(20, secondSection.Length);
            Assert.AreEqual(20, secondSection.MaxSpeed);

            Assert.AreEqual(30, thirdSection.Length);
            Assert.AreEqual(30, thirdSection.MaxSpeed);
        }
    }
}
