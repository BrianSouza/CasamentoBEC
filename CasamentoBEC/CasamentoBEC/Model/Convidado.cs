using System;
using System.Collections.Generic;
using System.Text;

namespace CasamentoBEC.Model
{
    public class Convidado
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public bool PresencaConfirmada { get; set; }
            public string Identificador { get; set; }
    }
}
