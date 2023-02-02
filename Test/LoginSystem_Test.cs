using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LoginSystem;

namespace Test
{
    [TestClass]
    public class LoginSystem_Test
    {
        [TestMethod]
        public void EncontrarDuplicados_Funcion()
        {
            //Arrange
            string user = "jesucristo";
            string pass = "superstar";
            string passNoOk = "hola";
            string userNoOk = "hola";
            //act
            bool userOk = Program.Login(user, pass);
            bool userPassNo = Program.Login(user, passNoOk);
            bool userNo = Program.Login(userNoOk, passNoOk);
            //assert

            Assert.IsTrue(userOk == true && userPassNo == false && userNo == false);
        }
    }
}
