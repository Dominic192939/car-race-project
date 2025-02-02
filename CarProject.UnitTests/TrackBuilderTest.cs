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

        [TestMethod]
        public void ItShouldBuildAConnectedTrack_ValidateManualTrackMatch()
        {
            (int, int)[] sectionDetails = { (10, 10), (20, 20), (30, 30) };

            Section startSection = new(sectionDetails[0].Item1, sectionDetails[0].Item2);
            Section middleSection = new(sectionDetails[1].Item1, sectionDetails[1].Item2);
            Section endSection = new(sectionDetails[2].Item1, sectionDetails[2].Item2);

            startSection.AddAfterMe(middleSection);
            middleSection.AddAfterMe(endSection);

            Track manuallyBuiltTrack = new(new List<Section> { startSection, middleSection, endSection });
            TrackBuilder builder = new(sectionDetails);

            Assert.AreEqual(manuallyBuiltTrack.StartSection!.Length, builder.RaceTrack!.StartSection!.Length);
            Assert.AreEqual(manuallyBuiltTrack.StartSection.MaxSpeed, builder.RaceTrack.StartSection.MaxSpeed);
            Assert.AreEqual(manuallyBuiltTrack.StartSection.NextSection!.Length, builder.RaceTrack.StartSection.NextSection!.Length);
            Assert.AreEqual(manuallyBuiltTrack.StartSection.NextSection!.MaxSpeed, builder.RaceTrack.StartSection.NextSection!.MaxSpeed);
            Assert.AreEqual(manuallyBuiltTrack.StartSection.NextSection!.NextSection!.Length, builder.RaceTrack.StartSection.NextSection!.NextSection!.Length);
            Assert.AreEqual(manuallyBuiltTrack.StartSection.NextSection!.NextSection!.MaxSpeed, builder.RaceTrack.StartSection.NextSection!.NextSection!.MaxSpeed);
        }

        [TestMethod]
        public void ItShouldConnectTheLastSegmentToTheFirst_GivenAnAdditionalParameterForALoopedTrack()
        {
            (int, int)[] sectionDetails = { (10, 10), (30, 30) };

            TrackBuilder builder = new(sectionDetails, isTrackLooping: true);

            Assert.IsTrue(builder.RaceTrack!.IsLoopedTrack);
        }
    }
}
