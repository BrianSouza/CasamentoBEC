using System;
using System.Collections.Generic;
using System.Text;

namespace CasamentoBEC.Model
{
    public sealed class Convidado : BaseModel
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public bool PresencaConfirmada { get; set; }
            public string Identificador { get; set; }
    }
}
