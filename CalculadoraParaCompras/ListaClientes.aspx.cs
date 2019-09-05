using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculadoraParaCompras
{
    public partial class ListaClientes : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                llenaCombox();
            }
        }

        protected void btConsultar_Click(object sender, EventArgs e)
        {
            int posicion = listaClients.SelectedIndex;
            lstTotalcompras.Items.Clear();

            string strArchivo = "C:\\Users\\Juan\\Desktop\\Calculadora\\calculadoraParaCompras\\CrearTxt.txt";
            string[] arrLeerArchivo = File.ReadAllLines(strArchivo);
            int intTamaño = arrLeerArchivo.Length;
            WebForm1.Datos[] arrDatos = new WebForm1.Datos[intTamaño];
            int cont = 0;

            if (intTamaño > 0)
            {
                 foreach (var item in arrLeerArchivo)
                {
                    string[] valores = item.Split(',');
                    arrDatos[cont].nombre = valores[0];
                    arrDatos[cont].montos = valores[1];

                    string[] montos = arrDatos[cont].montos.Split('-');

                    if (posicion == cont)
                    {
                        foreach (var val in montos)
                        {
                            lstTotalcompras.Items.Add(val);
                        }
                    }
                    cont++;
                }

            }

        }

        public void llenaCombox() {
            string strArchivo = "C:\\Users\\Juan\\Desktop\\Calculadora\\calculadoraParaCompras\\CrearTxt.txt";
            string[] arrLeerArchivo = File.ReadAllLines(strArchivo);

            foreach (var item in arrLeerArchivo)
            {
                string[] nombre = item.Split(',');
                listaClients.Items.Add(nombre[0]);
            }
        }
    }
}