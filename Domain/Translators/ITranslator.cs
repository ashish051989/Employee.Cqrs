using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Translators
{
    public interface ITranslator<From, To>
        where To : new()
    {
        To Translate(From from, To to);
    }
}
