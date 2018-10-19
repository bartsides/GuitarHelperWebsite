using System;
using System.Collections.Generic;
using System.Text;
using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;
using NUnit.Framework;

namespace GuitarHelperWebsite.Tests.Services
{
    [TestFixture]
    public class TuningServiceTest
    {
        private TuningService tuningService;

        public TuningServiceTest()
        {
            tuningService = new TuningService();
        }

        [Test]
        public void whenTuningsRequested_returnTunings()
        {
            Assert.IsNotEmpty(tuningService.GetTunings());
        }

        [Test]
        public void whenGivenNoteCsv_returnMatchingTuning()
        {
            Assert.AreEqual(tuningService.GetTuning("D,A,D,G,B,E").Name, "Drop D");
        }
    }
}
