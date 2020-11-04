using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocios
{
    public class N_contactos
    {

        D_contactos objDato = new D_contactos();
        public List<E_contactos> ListarContactos(string buscar)
        {
            return objDato.ListarContactos(buscar);
        }

        public void InsertandoContactos(E_contactos categorias)
        {
            objDato.insertarContacto(categorias);
        }
        public void EditandoContactos(E_contactos categoria)
        {
            objDato.EditarContacto(categoria);

        }
        public void EliminandoContactos(E_contactos categoria)
        {
            objDato.EliminarContactos(categoria);
        }
    }
}
