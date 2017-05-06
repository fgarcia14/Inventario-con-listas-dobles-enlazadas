using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
	class Inventario
	{
		Producto inicio;
		Producto ultimo;
		Producto temp;

		/// <summary>
		/// Se inicializa el inventario con el inicio vacio
		/// </summary>
		public Inventario()
		{
			inicio = null;
			ultimo = null;
		}

		/// <summary>
		/// Se agrega un nuevo producto al final de la lista, debe proporcionar un producto para agregarlo, el codigo del producto debe ser diferente al de otros productos agregados con anterioridad.
		/// </summary>
		/// <param name="nuevo"></param>
		public void agregarFinal(Producto nuevo)
		{
			if (inicio == null)
			{
				inicio = nuevo;
				ultimo = nuevo;
			}
			else
			{
				agregar(inicio, nuevo);
			}
		}

		private void agregar(Producto ultimo, Producto nuevo)
		{
			if (ultimo.siguiente == null)
			{
				nuevo.anterior = ultimo;
				ultimo.siguiente = nuevo;
				this.ultimo = nuevo;
			}
			else
			{
				agregar(ultimo.siguiente, nuevo);
			}
		}

		/// <summary>
		/// Se agrega un nuevo producto al inicio de la lista, debe proporcionar un producto para agregarlo con un numero diferente de codigo que no se haya utilizado anteriormente.
		/// </summary>
		/// <param name="nuevo"></param>
		public void agregarInicio(Producto nuevo)
		{
			bool ban = true;
			if (inicio==null)
			{
				inicio = nuevo;
				ultimo = nuevo;
			}
			else
			{
				temp = inicio;
				while (temp.siguiente!=null)
				{
					if (temp.codigo==nuevo.codigo)
					{
						ban = false;
					}
					temp = temp.siguiente;
				}
				if (temp.codigo != nuevo.codigo && ban)
				{
					inicio.anterior = nuevo;
					nuevo.siguiente = inicio;
					inicio = nuevo;
				}
			}
		}

		/// <summary>
		/// Devuelve un producto en caso de que exista o un valor nulo en caso contrario. Debe proporcionar un codigo de producto.
		/// </summary>
		/// <param name="codigo"></param>
		/// <returns></returns>
		public Producto buscar(int codigo)
		{
			temp = inicio;
			Producto producto = null;
			while (temp!=null)
			{
				if (temp.codigo==codigo)
				{
					producto = temp;
				}
				temp = temp.siguiente;
			}
			return producto;
		}

		/// <summary>
		/// Muestra una lista con todos los productos agregados
		/// </summary>
		/// <returns></returns>
		public String reporte()
		{
			String datos = "";
			temp = inicio;
			while (temp != null)
			{
				datos += temp.ToString()+Environment.NewLine;
				temp = temp.siguiente;
			}
			return datos;
		}

		public String reporteInverso()
		{
			String datos = "";
			temp = ultimo;
			while (temp != null)
			{
				datos += temp.ToString()+Environment.NewLine;
				temp = temp.anterior;
			}
			return datos;
		}

		/// <summary>
		/// Elimina un producto de la lista, debe proporcionar un numero de codigo del producto que desea eliminar.
		/// </summary>
		/// <param name="codigo"></param>
		public void eliminar(int codigo)
		{
			if (inicio.codigo == codigo)
			{
				inicio = inicio.siguiente;
				inicio.anterior = null;
			}
			else if (ultimo.codigo == codigo)
			{
				ultimo = ultimo.anterior;
				ultimo.siguiente = null;
			}
			else
			{
				temp = inicio;
				while (temp != null)
				{
					if (temp.codigo==codigo)
					{
						temp.anterior.siguiente = temp.siguiente;
						temp.siguiente.anterior = temp.anterior;
					}
					temp = temp.siguiente;
				}
			}
		}
		 
		/// <summary>
		/// Inserta un nuevo producto en determinada pocision, debera proporcionar el producto nuevo con un numero de codigo irrepetible a otros y el numero de pocision en el que desea insertar
		/// </summary>
		/// <param name="producto"></param>
		/// <param name="pos"></param>
		public void insertar(Producto producto, int pos)
		{
			temp = inicio;
			bool ban = true;
			while (temp != null)
			{
				if (producto.codigo==temp.codigo)
				{
					ban = false;
				}
				temp = temp.siguiente;
			}
			if (ban)
			{
				temp = inicio;
				if (pos == 1)
				{
					producto.siguiente = inicio;
					inicio = producto;

					producto.siguiente.anterior = inicio;
				}
				else
				{
					for (int i = 1; i < pos - 1; i++)
					{
						temp = temp.siguiente;
					}
					producto.siguiente = temp.siguiente;
					temp.siguiente = producto;


				}
			}
		}

		public void eliminarPrimero()
		{
			
			inicio = inicio.siguiente;
			inicio.anterior = null;
		}

		public void eliminarUltimo()
		{
			ultimo = ultimo.anterior;
			ultimo.siguiente = null;
		}
	}
}
