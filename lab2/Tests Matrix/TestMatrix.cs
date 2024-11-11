using lab2;
namespace Tests_Matrix
{
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void SumMatrix()
        {
            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 4;

            Matrix<int> matrix2 = new Matrix<int>(2, 2);
            matrix2[0, 0] = 5;
            matrix2[0, 1] = 6;
            matrix2[1, 0] = 7;
            matrix2[1, 1] = 8;

            Matrix<int> result = matrix1 + matrix2;

            Assert.AreEqual(6, result[0, 0]);
            Assert.AreEqual(8, result[0, 1]);
            Assert.AreEqual(10, result[1, 0]);
            Assert.AreEqual(12, result[1, 1]);
        }
        [TestMethod]
        public void TestMatrixMultiplication()
        {
            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 4;

            Matrix<int> matrix2 = new Matrix<int>(2, 2);
            matrix2[0, 0] = 5;
            matrix2[0, 1] = 6;
            matrix2[1, 0] = 7;
            matrix2[1, 1] = 8;

            Matrix<int> result = matrix1 * matrix2;

            Assert.AreEqual(19, result[0, 0]);
            Assert.AreEqual(22, result[0, 1]);
            Assert.AreEqual(43, result[1, 0]);
            Assert.AreEqual(50, result[1, 1]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMatrixAdditionnecorrect()
        {
            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            Matrix<int> matrix2 = new Matrix<int>(3, 3);

            Matrix<int> result = matrix1 + matrix2;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMatrixMultiplicationnecorrect()
        {
            Matrix<int> matrix1 = new Matrix<int>(2, 3);
            Matrix<int> matrix2 = new Matrix<int>(2, 2);

            Matrix<int> result = matrix1 * matrix2;
        }
        [TestMethod]
        public void TestSaveMatrixToCSV()
        {
            Matrix<int> matrix = new Matrix<int>(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;

            string filePath = "test.csv";
            matrix.saveCSV(filePath);

            Assert.IsTrue(File.Exists(filePath));
            File.Delete(filePath);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateMatrixWithZero()
        {
            Matrix<int> matrix = new Matrix<int>(0, 0);
        }
        [TestMethod]
        public void TestMatrixAdditionWithZeroValues()
        {
            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            Matrix<int> matrix2 = new Matrix<int>(2, 2);

            Matrix<int> result = matrix1 + matrix2;

            Assert.AreEqual(0, result[0, 0]);
            Assert.AreEqual(0, result[0, 1]);
            Assert.AreEqual(0, result[1, 0]);
            Assert.AreEqual(0, result[1, 1]);
        }
        [TestMethod]
        public void TestMatrixMultiplicationWithZeroValues()
        {
            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            Matrix<int> matrix2 = new Matrix<int>(2, 2);

            Matrix<int> result = matrix1 * matrix2;

            Assert.AreEqual(0, result[0, 0]);
            Assert.AreEqual(0, result[0, 1]);
            Assert.AreEqual(0, result[1, 0]);
            Assert.AreEqual(0, result[1, 1]);
        }
    }
}