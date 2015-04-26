using PaginaDados.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PaginaDados
{
    public class Principal
    {
        public int LIMITE_REGISTROS { get; set; }

        public Principal(int limiteRegistros)
        {
            LIMITE_REGISTROS = limiteRegistros;
        }

        public void Pagina(IList<NotasDTO> notas)
        {
            if (notas.Count > LIMITE_REGISTROS)
            {
                decimal totalPaginas = notas.Count / LIMITE_REGISTROS;

                Debug.WriteLine("Total de paginas:= " + totalPaginas.ToString());

                for (int i = 0; i <= totalPaginas; i++)
                {
                    var nextPage = LIMITE_REGISTROS * i;

                    Debug.WriteLine("PAGINA:= " + nextPage);
                    Debug.WriteLine("=========================================");
                    Debug.WriteLine("LOTE " + i);

                    var lote = notas.Select(n => n).Skip(nextPage).Take(LIMITE_REGISTROS);
                    
                    var contador = 0;
                    
                    foreach (var item in lote)
	                {
                        Debug.WriteLine("ITEM: {0} || INDICE: {1} || NOTA:= {2} ", contador, item.Indice, item.CodNotas);
                        
                        contador++;
	                }

                    Debug.WriteLine("=========================================");
                }

                Debug.WriteLine("LOTES PROCESSADOS COM SUCESSO");
            }
            else
            {
                Debug.WriteLine("LOTE ENVIADO");
            }
        }
    }
}
