using System;
using System.Collections.Generic;
using System.Text;

namespace JerarquiaFiguras
{
    internal class Rectangulo : Cuadrado
    {
        public float altura;

        public override float Area()
        {
            return Base * altura;
        }
        public override float Perimeter()
        {
            return Base * 2f + altura * 2f;
        }
    }
}
