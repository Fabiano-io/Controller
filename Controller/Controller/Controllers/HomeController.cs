using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    // Considera as boas práticas pra todas os verbos implementados
    [ApiConventionType(typeof(DefaultApiConventions))]

    [Route("[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public void Exemplo0()
        {

        }


        [HttpGet("{id}")]
        public string Exemplo1(string id)
        {
            return "Exemplo1";
        }


        [HttpGet("Exemplo2/{id}")]
        public ActionResult<IEnumerable<string>> Exemplo2(string id)
        {
            var valores = new string[] { "Exemplo2", "Exemplo2" };
            return Ok(valores);
        }


        [HttpGet]
        [Route("Exemplo3/{id}")]
        public async Task<ActionResult<IEnumerable<string>>> Exemplo3(string id)
        {
            var t1 = Task.Run(() => { });
            await Task.WhenAll(t1);

            var data = new
            {
                d1 = "Exemplo3",
                d2 = "Exemplo3"
            };

            return Ok(data);
        }


        [HttpGet, Route("Exemplo4/{id}")]
        public string Exemplo4(string id)
        {
            return "Exemplo4";
        }


        [HttpGet("Exemplo5/{id:int}")]
        public string Exemplo5(int id)
        {
            return id.ToString();
        }


        [HttpPost("Exemplo6/")]
        public ActionResult<Contato> Exemplo6([FromBody] Contato contato)
        {
            return Ok(contato);
        }


        [HttpPost("Exemplo7/{id:int}")]
        public ActionResult<Contato> Exemplo7([FromRoute] int id, [FromBody] Contato contato)
        {
            return Ok(new
            {
                id = id,
                Data = contato
            });
        }


        [HttpPut("Exemplo8/")]
        // Por convenção, já adiciona os modificadores BadRequest e NoContent
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public ActionResult<string> Exemplo8([FromBody] Contato contato)
        {
            if (contato.nome == "") return BadRequest();

            // Vai retornar o código 201 - Created
            return CreatedAtAction("Post", contato);
        }


        [HttpPut("Exemplo9/")]

        // Modificadores, modificam o comportamento da ActionResult especificando o tipo de resultado
        [ProducesResponseType(typeof(Contato), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        // Para situações de mais de um status code de retorno para um mesmo erro.
        [ProducesDefaultResponseType]   
        public ActionResult<Contato> PExemplo9ut([FromBody] Contato contato)
        {
            return Ok(contato);
        }


        [HttpDelete("Exemplo10/{id:int}")]
        public string Exemplo10(int id)
        {
            return id.ToString();
        }
    }

    public class Contato
    {
        public string nome { get; set; }

        public string email { get; set; }
    }

    //  1	    Lista de códigos de status HTTP
    //  2	    1xx Informativa
    //  2.1	    100 Continuar
    //  2.2	    101 Mudando protocolos
    //  2.3	    102 Processamento(WebDAV) (RFC 2518)
    //  2.4	    122 Pedido-URI muito longo
    //  3	    2xx Sucesso
    //  3.1	    201 Criado
    //  3.2	    202 Aceito
    //  3.3	    203 não-autorizado(desde HTTP/1.1)
    //  3.4	    204 Nenhum conteúdo
    //  3.5	    205 Reset
    //  3.6	    206 Conteúdo parcial
    //  3.7	    207-Status Multi(WebDAV) (RFC 4918)
    //  4	    3xx Redirecionamento
    //  4.1	    300 Múltipla escolha
    //  4.2	    301 Movido
    //  4.3	    302 Encontrado
    //  4.4	    303 Consulte Outros
    //  4.5	    304 Não modificado
    //  4.6	    305 Use Proxy(desde HTTP/1.1)
    //  4.7	    306 Proxy Switch
    //  4.8	    307 Redirecionamento temporário(desde HTTP/1.1)
    //  4.9	    308 Redirecionamento permanente(RFC 7538[2])
    //  5	    4xx Erro de cliente
    //  5.1	    400 Requisição inválida
    //  5.2	    401 Não autorizado
    //  5.3	    402 Pagamento necessário
    //  5.4	    403 Proibido
    //  5.5	    404 Não encontrado
    //  5.6	    405 Método não permitido
    //  5.7	    406 Não Aceitável
    //  5.8	    407 Autenticação de proxy necessária
    //  5.9	    408 Tempo de requisição esgotou(Timeout)
    //  5.10	409 Conflito geral
    //  5.11	410 Gone
    //  5.12	411 comprimento necessário
    //  5.13	412 Pré-condição falhou
    //  5.14	413 Entidade de solicitação muito grande
    //  5.15	414 Pedido-URI Too Long
    //  5.16	415 Tipo de mídia não suportado
    //  5.17	416 Solicitada de Faixa Não Satisfatória
    //  5.18	417 Falha na expectativa
    //  5.19	418 Eu sou um bule de chá
    //  5.20	422 Entidade improcessável(WebDAV) (RFC 4918)
    //  5.21	423 Fechado(WebDAV) (RFC 4918)
    //  5.22	424 Falha de Dependência(WebDAV) (RFC 4918)
    //  5.23	425 coleção não ordenada(RFC 3648)
    //  5.24	426 Upgrade Obrigatório(RFC 2817)
    //  5.25	429 pedidos em excesso
    //  5.26	450 bloqueados pelo Controle de Pais do Windows
    //  5.27	499 cliente fechou Pedido(utilizado em ERPs/VPSA)
    //  6	    5xx outros erros
    //  6.1	    500 Erro interno do servidor(Internal Server Error)
    //  6.2	    501 Não implementado(Not implemented)
    //  6.3	    502 Bad Gateway
    //  6.4	    503 Serviço indisponível(Service Unavailable)
    //  6.5	    504 Gateway Time-Out
    //  6.6	    505 HTTP Version not supported
    //  7	    Ligações externas
    //
    // Referência: https://pt.wikipedia.org/wiki/Lista_de_c%C3%B3digos_de_estado_HTTP
}