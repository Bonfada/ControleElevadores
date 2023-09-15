using Microsoft.AspNetCore.Mvc;
using ProvaAdmissionalCSharpApisul.Models;
using ProvaAdmissionalCSharpApisul.Service;
using System;
using System.Collections.Generic;
using System.Net;

namespace ProvaAdmissionalCSharpApisul.Controllers
{
    [ApiController]
    [Route("api/provaapisul/elevadores")]

    public class ElevadorController : Controller
    {

        private IElevadorService _service;

        public ElevadorController(IElevadorService service)
        {
            _service = service;

        }

        [HttpPost("Carregar")]
        public ActionResult<bool> Load(List<ElevadorModel> valores)
        {
            try
            {

                _service.Load(valores);
            }
            catch (Exception)
            {
                return BadRequest($"Ocorreu um erro ao processar sua requisição {HttpStatusCode.InternalServerError}");
            }

            return Ok(true);

        }


        [HttpPost("Andar-menos-utilizado")]
        public ActionResult<List<int>> AndarMenosUtilizado()
        {
            RetornoModel retorno = null;

            try
            {
                retorno = _service.AndarMenosUtilizado();

                if (retorno.Success == false)
                    return BadRequest($"Ocorreu um erro, {retorno.Message}");

            }
            catch (Exception)
            {
                return BadRequest($"Ocorreu um erro ao processar sua requisição {HttpStatusCode.InternalServerError}");
            }


            return Ok(retorno.Andares);

        }


        [HttpPost("Periodo-elevador-mais-frequentado")]
        public ActionResult<List<int>> PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            RetornoModel retorno = null;

            try
            {
                retorno = _service.PeriodoMaiorFluxoElevadorMaisFrequentado();
            }
            catch (Exception)
            {
                return BadRequest($"Ocorreu um erro ao processar sua requisição {HttpStatusCode.InternalServerError}");
            }

            return Ok(retorno);
        }

        [HttpPost("Periodo-elevador-menos-frequentado")]
        public ActionResult<List<int>> PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            RetornoModel retorno = null;

            try
            {
                retorno = _service.PeriodoMenorFluxoElevadorMenosFrequentado();
            }
            catch (Exception)
            {
                return BadRequest($"Ocorreu um erro ao processar sua requisição {HttpStatusCode.InternalServerError}");
            }

            return Ok(retorno);

        }


    }
}
