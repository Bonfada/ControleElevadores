using ProvaAdmissionalCSharpApisul.Models;
using System.Collections.Generic;

namespace ProvaAdmissionalCSharpApisul.Service
{
    public interface IElevadorService
    {
        void Load(List<ElevadorModel> valores);
        /// <summary> Deve retornar uma List contendo o(s) andar(es) menos utilizado(s). </summary> 
        RetornoModel AndarMenosUtilizado();

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s). </summary> 
        RetornoModel ElevadorMaisFrequentado();

        /// <summary> Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores mais frequentados (se houver mais de um). </summary> 
        RetornoModel PeriodoMaiorFluxoElevadorMaisFrequentado();

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) menos frequentado(s). </summary> 
        RetornoModel ElevadorMenosFrequentado();

        /// <summary> Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um). </summary> 
        RetornoModel PeriodoMenorFluxoElevadorMenosFrequentado();

        /// <summary> Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores. </summary> 
        RetornoModel PeriodoMaiorUtilizacaoConjuntoElevadores();

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relação a todos os serviços prestados. </summary> 
        RetornoModel PercentualDeUsoElevadorA();

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador B em relação a todos os serviços prestados. </summary> 
        RetornoModel PercentualDeUsoElevadorB();

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador C em relação a todos os serviços prestados. </summary> 
        RetornoModel PercentualDeUsoElevadorC();

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador D em relação a todos os serviços prestados. </summary> 
        RetornoModel PercentualDeUsoElevadorD();

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador E em relação a todos os serviços prestados. </summary> 
        RetornoModel PercentualDeUsoElevadorE();
    }
}
