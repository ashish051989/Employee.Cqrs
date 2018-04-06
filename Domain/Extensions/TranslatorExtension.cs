using Domain.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class TranslatorExtension
    {
        public static To Translate<From, To>(this ITranslator<From, To> translator, From from)
            where To : new()
        {
            return translator.Translate(from, new To());
        }
    }
}
