/*public List<SdtBulkActionInformation> prueba(List<SdtBulkActionInformation> valores)
{


}*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusquedaSumatoria
{
    public class BuscadorCombinaciones
    {

        public List<int> EncontrarCombinaciones(List<int> valores, int objetivo)
        {
            List<int> resultado = new List<int>();

            // Marcar con 1 aquellos valores que forman parte de la combinación que cumple con el objetivo
            for (int i = 0; i < Math.Pow(2, valores.Count); i++)
            {
                List<int> combinacion = new List<int>();

                // Utilizar la representación binaria de i para seleccionar los valores
                for (int j = 0; j < valores.Count; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        combinacion.Add(valores[j]);
                    }
                }

                // Verificar si la combinación suma el objetivo
                if (combinacion.Sum() == objetivo)
                {
                    resultado.AddRange(combinacion);
                }
            }

            // Eliminar duplicados y devolver la lista de valores que cumplen con el objetivo
            return resultado.Distinct().ToList();
        }
    }
}
