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
    }
}
