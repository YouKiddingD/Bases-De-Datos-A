using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bases_de_Datos
{
    public class Atributo
    {
        private string strNombre = "";
        private int tipoDato = 0;
        private int ancho = 0;
        private int key = 0;
        private string IDTabla;

        public Atributo(string nombre, int dataType, int tam, int llave, string IDTabla)
        {
            strNombre = nombre;
            tipoDato = dataType;
            ancho = tam;
            key = llave;
            this.IDTabla = IDTabla;
        }

        public string Nombre
        {
            get
            {
                return strNombre;
            }
            set
            {
                strNombre = value;
            }
        }

        public int TipoDato
        {
            get
            {
                return tipoDato;
            }
            set
            {
                tipoDato = value;
            }
        }

        public int Size
        {
            get
            {
                return ancho;
            }
            set
            {
                ancho = value;
            }
        }

        public int Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        public string TablaOrigen
        {
            get
            {
                return IDTabla;
            }
            set
            {
                IDTabla = value;
            }
        }
    }
}
