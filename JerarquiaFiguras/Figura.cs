using System;
using System.Collections.Generic;
using System.Text;

namespace JerarquiaFiguras
{
    public abstract class  Figura
    {
        public float posX;
        public float posY;

        public abstract float Area();
        public abstract float Perimeter();
    }
}
