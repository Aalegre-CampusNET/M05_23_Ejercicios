using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EncontrarDuplicados;
using System.Linq;

namespace Test
{
    [TestClass]
    public class EncontrarDuplicados_Test
    {
        [TestMethod]
        public void EncontrarDuplicados_Funcion()
        {
            //Arrange
            List<string> palabras = Program.GenerateRandomWords(100);
            List<string> palabrasUnicas = palabras.Distinct().ToList();
            bool duplicatesOK = false;
            for (int i = 0; i < palabras.Count; i++)
            {
                if(palabras[i] != palabrasUnicas[i])
                {
                    duplicatesOK = true;
                    break;
                }
            }
            //Act
            bool duplicatesTest = Program.CheckDuplicates(palabras);
            //Assert
            Assert.IsTrue(duplicatesTest == duplicatesOK);
        }
    }
}
