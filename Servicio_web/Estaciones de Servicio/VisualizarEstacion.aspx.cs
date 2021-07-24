using Servicio_web_Model.DAL;
using Servicio_web_Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicio_web.Estaciones_de_Servicio
{
    public partial class VisualizarEstacion : System.Web.UI.Page
    {

        /*crear una tabla de datos*/
        DataTable dt = new DataTable();



        private void Cargar_tablas()
        {
            List<Estacion> estaciones = new EstacionDAL().GetEstacions();
            List<Region> regiones = new RegionDAL().GetRegiones();


            dt.Columns.AddRange(new DataColumn[6]{
                /*Crear las colummas de la Tabla de datos*/
            new DataColumn("Rut", typeof(string)),
            new DataColumn("Capacidad", typeof(int)),
            new DataColumn("Horario Inicio", typeof(string)),
            new DataColumn("Horario Cierre", typeof(string)),
            new DataColumn("Direcion", typeof(string)),
            new DataColumn("Region", typeof(string))
            });
            string Rut = "", direccion = "", region = "";
            int capacidad = 0; 

            string Hi = DateTime.Now.ToString("H:m"), HC = DateTime.Now.ToString("H:m");

            for (int i = 0; i < estaciones.Count; i++)
            {
                int relax = 0;
                Estacion e = new Estacion() { 
                Rut=estaciones[i].Rut,
                Capacidad=estaciones[i].Capacidad,
                Direccion=estaciones[i].Direccion,
                Hora_inicio=estaciones[i].Hora_inicio,
                Hora_cierre=estaciones[i].Hora_cierre,
                Region=estaciones[i].Region
                };
                for (int j = 0; j < regiones.Count; j++)
                {
                    Region R = new Region()
                    {
                        id_Region = regiones[j].id_Region,
                        Nombre = regiones[j].Nombre
                    };
                    if (relax==-1)
                    {

                    }
                    if (R.id_Region==e.Region)
                    {
                        Rut = e.Rut;
                        capacidad = e.Capacidad;
                        direccion = e.Direccion;
                        Hi = e.Hora_inicio.ToString("H:m");
                        HC= e.Hora_cierre.ToString("H:m");
                        region = R.Nombre;
                        relax = -1;
                    }
                }

                DataRow row = dt.NewRow();
                /*los datos se almacenados se guardaran en celdas por filas */
                row["Rut"] = Rut;
                row["Capacidad"] = capacidad;
                row["Horario Inicio"] = Hi;
                row["Horario Cierre"] = HC;
                row["Direcion"] = direccion;
                row["Region"] = region;
                dt.Rows.Add(row);


            }

            /*se mostraran los datos guardados de la filas por colummnas en el Gridview */
            EstacionGrid.DataSource = dt;
            EstacionGrid.DataBind();


        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                Cargar_tablas();


            }

        }

        protected void EstacionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {

                String eliminarut = e.CommandArgument.ToString();
                new EstacionDAL().Eliminar(eliminarut);
                Cargar_tablas();

            }

        }

    }
}