using MySAT;

namespace MySATTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var path = @"TestFiles/uf75-01.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test2()
        {
            var path = @"TestFiles/uf75-02.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test3()
        {
            var path = @"TestFiles/uf75-03.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test4()
        {
            var path = @"TestFiles/uf75-04.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test5()
        {
            var path = @"TestFiles/uf75-05.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test6()
        {
            var path = @"TestFiles/uf75-06.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test7()
        {
            var path = @"TestFiles/uf75-07.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test8()
        {
            var path = @"TestFiles/uf75-08.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test9()
        {
            var path = @"TestFiles/uf75-09.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
        [Test]
        public void Test10()
        {
            var path = @"TestFiles/uf75-010.cnf";
            var answer = SAT.Start(path);
            Assert.AreEqual(answer[0], "SAT");
        }
    }
}