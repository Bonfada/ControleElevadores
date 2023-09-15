using ProvaAdmissionalCSharpApisul.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProvaAdmissionalCSharpApisul.Service
{
    public class ElevadorService : IElevadorService
    {
        public List<ElevadorModel> _valores { get; set; }

        public void Load(List<ElevadorModel> valores) => _valores = valores;

        public RetornoModel AndarMenosUtilizado()
        {
            RetornoModel retorno = new();
            List<int> listaAndares = new();

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }


            var dict = _valores
                        .GroupBy(x => new { x.Andar })
                        .Where(g => g.Count() == 1)
                        .ToDictionary(x => x.Key, x => x.Count());

            foreach (var item in dict)
            {
                listaAndares.Add(Convert.ToInt32(item.Key.Andar));
            }

            retorno.Andares = listaAndares;
            retorno.Success = true;
            return retorno;
        }

        public List<int> DeveRetornarUmaListaMenorAndar()
        {
            RetornoModel retorno = new();
            List<int> listaAndares = new();
            var dict = _valores
                        .GroupBy(x => new { x.Andar })
                        .Where(g => g.Count() == 1)
                        .ToDictionary(x => x.Key, x => x.Count());


            var itens = dict.ToList();

            foreach (var item in itens)
            {
                listaAndares.Add(Convert.ToInt32(item.Key.Andar));
            }

            retorno.Andares = listaAndares;

            return listaAndares;
        }

        public RetornoModel ElevadorMaisFrequentado()
        {
            RetornoModel retorno = new();
            List<char> listaElevadores = new();

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            var dict = _valores
                        .GroupBy(x => new { x.Elevador })
                        .Where(g => g.Count() > 1)
                        .ToDictionary(x => x.Key, x => x.Count());

            var itens = dict.ToList();

            foreach (var item in itens)
            {
                listaElevadores.Add(Convert.ToChar(item.Key.Elevador));
            }

            retorno.Elevadores = listaElevadores;

            return retorno;

        }

        public RetornoModel ElevadorMenosFrequentado()
        {
            RetornoModel retorno = new();
            List<char> listaElevadores = new();


            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            var dict = _valores
                        .GroupBy(x => new { x.Elevador })
                        .Where(g => g.Count() == 1)
                        .ToDictionary(x => x.Key, x => x.Count());


            var itens = dict.ToList();

            foreach (var item in itens)
            {
                listaElevadores.Add(Convert.ToChar(item.Key.Elevador));
            }

            retorno.Elevadores = listaElevadores;
            retorno.Success = true;
            return retorno;
        }

        public RetornoModel PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            RetornoModel retorno = new();
            List<char> turnos = new();

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            retorno = ElevadorMaisFrequentado();

            foreach (char elevador in retorno.Elevadores)
            {
                char celevador = Convert.ToChar(elevador);
                List<ElevadorModel> lista = _valores.Where(x => x.Elevador.Equals(celevador)).ToList();
                var _dict = lista
                        .GroupBy(x => new { x.Turno })
                        .Where(g => g.Count() > 1)
                        .ToDictionary(x => x.Key, x => x.Count());

                var maxValueKey = _dict.OrderByDescending(x => x.Value).First().Key;
                var turnoMaiorFluxo = Convert.ToChar(maxValueKey.Turno);
                turnos.Add(turnoMaiorFluxo);
            }

            retorno.Turnos = turnos;
            retorno.Success = true;
            return retorno;

        }

        public RetornoModel PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            RetornoModel retorno = new();
            List<char> turnos = new();

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            retorno = ElevadorMenosFrequentado();

            foreach (char elevador in retorno.Elevadores)
            {
                char celevador = Convert.ToChar(elevador);
                List<ElevadorModel> lista = _valores.Where(x => x.Elevador.Equals(celevador)).ToList();
                var _dict = lista
                        .GroupBy(x => new { x.Turno })
                        .Where(g => g.Count() == 1)
                        .ToDictionary(x => x.Key, x => x.Count());

                var maxValueKey = _dict.OrderByDescending(x => x.Value).First().Key;
                var turnoMaiorFluxo = Convert.ToChar(maxValueKey.Turno);
                turnos.Add(turnoMaiorFluxo);
            }

            retorno.Turnos = turnos;
            retorno.Success = true;
            return retorno;
        }


        public RetornoModel PeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            RetornoModel retorno = new();
            List<char> listaTurnos = new();

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            var dict = _valores
                        .GroupBy(x => new { x.Turno })
                        .Where(g => g.Count() > 1)
                        .ToDictionary(x => x.Key, x => x.Count());

            var itens = dict.ToList();

            foreach (var item in itens)
            {
                listaTurnos.Add(Convert.ToChar(item.Key.Turno));
            }

            retorno.Turnos = listaTurnos;

            return retorno;
        }


        public RetornoModel PercentualDeUsoElevadorA()
        {
            RetornoModel retorno = new();
            decimal percentualUsoElevador = 0;

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            var el = _valores
                        .Where(x => x.Elevador.Equals('A'))
                        .ToList();

            var totalElevadores = _valores.Count();
            var quantidadeElevadorA = el.Count();

            percentualUsoElevador = quantidadeElevadorA / totalElevadores * 100;

            retorno.PercentualUso = decimal.Parse(percentualUsoElevador.ToString("N2"));
            retorno.Success = true;
            return retorno;
        }

        public RetornoModel PercentualDeUsoElevadorB()
        {
            RetornoModel retorno = new RetornoModel();
            decimal percentualUsoElevador = 0;

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            var el = _valores
                        .Where(x => x.Elevador.Equals('B'))
                        .ToList();

            var totalElevadores = _valores.Count();
            var quantidadeElevadorB = el.Count();

            percentualUsoElevador = quantidadeElevadorB / totalElevadores * 100;

            retorno.PercentualUso = decimal.Parse(percentualUsoElevador.ToString("N2"));
            retorno.Success = true;
            return retorno;
        }

        public RetornoModel PercentualDeUsoElevadorC()
        {
            RetornoModel retorno = new();
            decimal percentualUsoElevador = 0;


            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            var el = _valores
                        .Where(x => x.Elevador.Equals('C'))
                        .ToList();

            var totalElevadores = _valores.Count();
            var quantidadeElevadorC = el.Count();

            percentualUsoElevador = quantidadeElevadorC / totalElevadores * 100;

            retorno.PercentualUso = decimal.Parse(percentualUsoElevador.ToString("N2"));
            retorno.Success = true;
            return retorno;
        }

        public RetornoModel PercentualDeUsoElevadorD()
        {
            RetornoModel retorno = new();
            decimal percentualUsoElevador = 0;

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            var el = _valores
                        .Where(x => x.Elevador.Equals('D'))
                        .ToList();

            var totalElevadores = _valores.Count();
            var quantidadeElevadorD = el.Count();

            percentualUsoElevador = quantidadeElevadorD / totalElevadores * 100;

            retorno.PercentualUso = decimal.Parse(percentualUsoElevador.ToString("N2"));
            retorno.Success = true;
            return retorno;
        }

        public RetornoModel PercentualDeUsoElevadorE()
        {
            RetornoModel retorno = new();
            decimal percentualUsoElevador = 0;

            if (_valores == null)
            {
                retorno.Success = false;
                retorno.Message = "Nenhum arquivo encontrado. Carregue um novo arquivo para continuar";
                return retorno;
            }

            var el = _valores
                        .Where(x => x.Elevador.Equals('E'))
                        .ToList();

            var totalElevadores = _valores.Count();
            var quantidadeElevadorE = el.Count();

            percentualUsoElevador = quantidadeElevadorE / totalElevadores * 100;

            retorno.PercentualUso = decimal.Parse(percentualUsoElevador.ToString("N2"));
            retorno.Success = true;
            return retorno;
        }


    }
}

