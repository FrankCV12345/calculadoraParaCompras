using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CalculadoraParaCompras
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnGuarda_Click(object sender, EventArgs e)
        {
            string strArchivo = "C:\\Users\\FCV\\Desktop\\master calculadora para compras  .net\\calculadoraParaCompras\\CrearTxt.txt";
            string[] arrLeerArchivo = File.ReadAllLines(strArchivo);
            int intTamaño = arrLeerArchivo.Length;
            Datos[] arrDatos = new Datos[intTamaño];
            string strNombre = txtNombre.Text;
            string strMonto = txtTotal.Text;
            bool bolNuevo = true;
            Datos[] arrTemp = new Datos[intTamaño + 1];

            if (intTamaño == 0)
            {
                arrTemp[intTamaño].nombre = strNombre;
                arrTemp[intTamaño].montos = strMonto;
            }
            else
            {
                for (int i = 0; i < intTamaño; i++)
                {
                    string[] aux = arrLeerArchivo[i].Split(',');
                    arrDatos[i].nombre = aux[0];

                    if (arrDatos[i].nombre.Equals(strNombre))
                    {
                        aux[1] += "-" + strMonto;
                        bolNuevo = false;
                    }
                    arrDatos[i].montos = aux[1];
                }

                if (bolNuevo)
                {
                    for (int i = 0; i < arrDatos.Length; i++)
                    {
                        arrTemp[i].nombre = arrDatos[i].nombre;
                        arrTemp[i].montos = arrDatos[i].montos;
                    }

                    arrTemp[intTamaño].nombre = strNombre;
                    arrTemp[intTamaño].montos = strMonto;
                }
                else
                {
                    arrTemp = arrDatos;
                }
            }

            using (StreamWriter outputfile = new StreamWriter(strArchivo))
            {
                for (int i = 0; i < arrTemp.Length; i++)
                {
                    outputfile.WriteLine(arrTemp[i].nombre + "," + arrTemp[i].montos);
                }
            }
        }
        public struct Datos
        {
            public string nombre;
            public string montos;
        }
    }
}