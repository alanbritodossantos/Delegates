using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Agencias.DAL
{
    //classe parcial pode continuar sua definição em varios arquivos diferentes
    public partial class Agencia
    {
        
        public override string ToString() =>
            $"{Numero} - {Nome}".Trim();
    }
}
