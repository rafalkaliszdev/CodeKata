using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeKata;

namespace CodeKata.Tests {
    [TestClass]
    public class GaderypolukiTests {
        [TestMethod]
        public void TestMethod1() {
            var key = "GADERYPOLUKI";
            var encodedText = "thd nlmbdy pf ydougcdmdnts sgvd kn thd gyygr kn thd knedx cpyydsopnekna tp thd sruugbud. thd knedxds mlst bd kn thd guohgbdtkcgu pyedy pf thd sruugbuds pf thd dncpekna idr, d.a. fpy thd idr 'odig' thd fkyst knedx wplue cpyydsopne tp 'ig' gne thd sdcpne knedx tp 'od' sruugbud.";
            var expectedText = "the number of replacements save in the array in the index corresponding to the syllable. the indexes must be in the alphabetical order of the syllables of the encoding key, e.g. for the key 'peka' the first index would correspond to 'ka' and the second index to 'pe' syllable.";
            Tuple<string, int[]> actual = Gaderypoluki.Encode(key, encodedText);
            
            Assert.AreEqual(expectedText.ToLower(),actual.Item1.ToLower());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod2() {
            var key = "GADERYPOLUK";
            var encodedText = "thd nlmbdy pf ydougcdmdnts sgvd kn thd gyygr kn thd knedx cpyydsopnekna tp thd sruugbud. thd knedxds mlst bd kn thd guohgbdtkcgu pyedy pf thd sruugbuds pf thd dncpekna idr, d.a. fpy thd idr 'odig' thd fkyst knedx wplue cpyydsopne tp 'ig' gne thd sdcpne knedx tp 'od' sruugbud.";
            try {
                Gaderypoluki.Encode(key, encodedText);

                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentException ex) {
                Assert.AreEqual("The number of letters in the encryption key must be even.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod3() {
            var key = "GADARYPOLUKI";
            var encodedText = "thd nlmbdy pf ydougcdmdnts sgvd kn thd gyygr kn thd knedx cpyydsopnekna tp thd sruugbud. thd knedxds mlst bd kn thd guohgbdtkcgu pyedy pf thd sruugbuds pf thd dncpekna idr, d.a. fpy thd idr 'odig' thd fkyst knedx wplue cpyydsopne tp 'ig' gne thd sdcpne knedx tp 'od' sruugbud.";
            try {
                Gaderypoluki.Encode(key, encodedText);

                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentException ex) {
                Assert.AreEqual("The encryption key is invalid. Each letter in the entire key must be unique.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod4() {
            var key = "GAAERYPOLUKI";
            var encodedText = "thd nlmbdy pf ydougcdmdnts sgvd kn thd gyygr kn thd knedx cpyydsopnekna tp thd sruugbud. thd knedxds mlst bd kn thd guohgbdtkcgu pyedy pf thd sruugbuds pf thd dncpekna idr, d.a. fpy thd idr 'odig' thd fkyst knedx wplue cpyydsopne tp 'ig' gne thd sdcpne knedx tp 'od' sruugbud.";
            try {
                Gaderypoluki.Encode(key, encodedText);

                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ArgumentException ex) {
                Assert.AreEqual("The encryption key is invalid. Each letter in the entire key must be unique.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void TestMethod5() {
            var key = "GADERYPOLUKI";
            var encodedText = "thd nlmbdy pf ydougcdmdnts sgvd kn thd gyygr kn thd knedx cpyydsopnekna tp thd sruugbud. thd knedxds mlst bd kn thd guohgbdtkcgu pyedy pf thd sruugbuds pf thd dncpekna idr, d.a. fpy thd idr 'odig' thd fkyst knedx wplue cpyydsopne tp 'ig' gne thd sdcpne knedx tp 'od' sruugbud.";
            Tuple<string, int[]> actual = Gaderypoluki.Encode(key, encodedText);

            Assert.AreEqual(47, actual.Item2[0]);
            Assert.AreEqual(16, actual.Item2[1]);
            Assert.AreEqual(15, actual.Item2[2]);
            Assert.AreEqual(16, actual.Item2[3]);
            Assert.AreEqual(21, actual.Item2[4]);
            Assert.AreEqual(18, actual.Item2[5]);
        }
    }
}

