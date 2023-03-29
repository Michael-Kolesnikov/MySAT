using MySAT;

namespace MySATTests
{
    public class UNSATtests
    {
        [Test]
        public void Test1()
        {
            var path = @"TestFiles/aim-50-1_6-no-1.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "UNSAT");
        }
        [Test]
        public void Test2()
        {
            var path = @"TestFiles/aim-50-1_6-no-2.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "UNSAT");
        }
        [Test]
        public void Test3()
        {
            var path = @"TestFiles/aim-50-1_6-no-3.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "UNSAT");
        }
        [Test]
        public void Test4()
        {
            var path = @"TestFiles/aim-50-1_6-no-4.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "UNSAT");
        }
    }
}
