using System;
using System.Collections.Generic;
using System.Text;

namespace JerarquiaFiguras
{
    public class Cuadrado : Figura
    {
        public float Base;

        public override float Area()
        {
            return Base * Base;
        }
        public override float Perimeter()
        {
            return Base * 4f;
        }
    }
}
