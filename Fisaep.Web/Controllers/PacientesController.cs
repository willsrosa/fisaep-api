using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Firebase.Storage;
using Fisaep.Data;
using Fisaep.Data.Models;
using Fisaep.Web.Models;
using Geocoding;
using Geocoding.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ViaCEP;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fisaep.Web.Controllers
{
    public class PacientesController : BaseController
    {

        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PacientesController(IHttpContextAccessor httpContextAccessor, ApplicationContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }
        [HttpGet]
        [Route("api/Pacientes/GetPacientes")]
        public IEnumerable<Pacientes> GetPacientes()
        {
            string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
            DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
            var sql = (from e in _context.Especialista_Paciente
                       join c in _context.Cadastro_Especialista on e.id_especialista equals c.Id
                       join p in _context.Cadastro_Pacientes on e.Id_paciente equals p.Id
                       where (e.data_exclusao == null || e.data_exclusao.Value.AddMonths(1) > DateTime.Now)
                       where (c.id_usuario == usuarioResponse.Id)
                       orderby (p.c_nome)
                       group p by p.Id into g
                       select new Pacientes
                       {
                           Id = g.Select(c => c.Id).FirstOrDefault(),
                           Nome = g.Select(c => c.c_nome).FirstOrDefault(),
                           Convenio = "",
                           tipo_avaliacao = BuscarTipoAvaliacao(g.Select(c => c.dt_nascimento).FirstOrDefault(), usuarioResponse.especialidade)
                       }).Take(100);

            return sql;
        }

        private string BuscarTipoAvaliacao(DateTime? dt_nascimento, string area)
        {

            var id_area_atuacao = Convert.ToInt32(area);
            int idade = 0;
            if (dt_nascimento != null)
            {
                idade = CalcularIdade(dt_nascimento.Value);
            }
            if (id_area_atuacao == 1 && idade <= 4)
            {
                return "FI";
            }
            if (id_area_atuacao == 1)
            {
                return "FA";
            }
            if (id_area_atuacao == 2)
            {
                return "FO";
            }
            if (id_area_atuacao == 3)
            {
                return "TO";
            }
            if (id_area_atuacao == 4)
            {
                return "NU";
            }
            else
            {
                return "";
            }

        }
        public static int CalcularIdade(DateTime birthDate)
        {
            DateTime now = DateTime.Today;
            int years = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                --years;

            return years;
        }
        [HttpGet]
        [Route("api/Pacientes/GetPacienteAgenda/{id:int}")]
        public pacientesMeses GetPacienteAgenda(int id)
        {
            string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
            DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
            var paciente = (from f in _context.Cadastro_Pacientes
                            where (f.Id == id)
                            select new
                            {
                                f.Id,
                                f.c_nome
                            }).FirstOrDefault();

            var especialista = (from f in _context.Cadastro_Especialista
                                where f.id_usuario == usuarioResponse.Id
                                select f).FirstOrDefault();



            //var especialistapaciente = (from f in _context.Especialista_Paciente
            //                            where f.id_especialista == especialista.Id
            //                            where f.Id_paciente == id
            //                            orderby f.Id descending
            //                            select f.data_exclusao).FirstOrDefault();
            //var especialistapaciente = (from f in _context.Especialista_Paciente
            //                            where (f.id_especialista == especialista.Id)
            //                            where (f.Id_paciente == id)
            //                            where (f.data_exclusao == null)
            //                            //orderby f.data_exclusao == null , f.Id ascending
            //                            select f).FirstOrDefault();
            var sql = "SELECT * FROM Especialista_Paciente e WHERE e.id_especialista = " + especialista.Id + " and e.id_paciente = " + paciente.Id + " ORDER BY e.data_exclusao = NULL, e.Id DESC ";

            var especialistapaciente = (from f in _context.Especialista_Paciente.FromSql(sql)
                                        select f).FirstOrDefault();


            var obj = new pacientesMeses();
            obj.Nome = paciente.c_nome;
            obj.PacienteId = id;
            obj.Meses = (from f in _context.Programacao_Pacientes
                         orderby f.Id descending
                         where (f.id_paciente == id)
                         where (especialistapaciente.data_exclusao == null || f.d_inicio_programacao <= especialistapaciente.data_exclusao)
                         where (f.id_especialidade == especialista.id_area_atuacao)
                         select f.d_termino_programacao.Month.ToString().PadLeft(2, '0') + "/" + f.d_termino_programacao.Year
                       ).Distinct().ToList();




            return obj;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("api/Pacientes/BuscarAgendamentoPaciente")]
        public IList<EvolutivosPacientes> BuscarAgendamentoPaciente(int paciente, string faturamento)
        {
            string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
            DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);


            int mesFaturamento = 0;
            int AnoFaturamento = 0;

            if (!string.IsNullOrEmpty(faturamento))
            {
                mesFaturamento = Convert.ToInt32(faturamento.Split('/')[0]);
                AnoFaturamento = Convert.ToInt32(faturamento.Split('/')[1]);
            }

            var especialista = (from f in _context.Cadastro_Especialista
                                where f.id_usuario == usuarioResponse.Id
                                select f).FirstOrDefault();


            // var busca = "SELECT c.nome, c.cnpj,c.id FROM clientes c where REPLACE(REPLACE(REPLACE(cnpj, '/', ''), '-', ''), '.', '') like'%" + text + "%' or nome like'%" + text + "%'";
            var busca = "SELECT * FROM EvolucaoPacienteTxt e WHERE MONTH(e.data) = " + mesFaturamento + " AND YEAR(e.data) = " + AnoFaturamento + " AND e.Id_Paciente = " + paciente + " AND e.Especialidade =" + especialista.id_area_atuacao + " ";

            var evolutivos = (from f in _context.EvolucaoPacienteTxt.FromSql(busca)
                              select f).ToList();
            var especialidades = (from e in _context.Especialidades
                                  select e).ToList();
            var diasPreencher = (from d in _context.Programa_Sugestao_Dias
                                 select d).ToList();
            var programacao = (from p in _context.Programacao_Pacientes
                               where p.id_paciente == paciente
                               where p.d_inicio_programacao.Month == mesFaturamento
                               where p.d_inicio_programacao.Year == AnoFaturamento
                               where (p.n_limite > 0)
                               where (p.id_especialidade == especialista.id_area_atuacao)
                               select p).ToList();
            var program = (from f in _context.Programa
                           select f).ToList();
            var dadosPaciente = programacao.ToList();
            var Lista = new List<EvolutivosPacientes>();
            var usuarios = _context.AspNetUsers.ToList();
            foreach (var item2 in dadosPaciente)
            {
                var dates = new List<DateTime>();

                var diasprogramacao = diasPreencher.Where(c => c.id_programa == item2.id_programa && c.data_exclusao == null).Select(c => c.id_dia).ToList();
                var diasLimite = diasPreencher.Where(c => c.id_programa == item2.id_programa && c.data_exclusao == null).ToList();

                var descricaoPrograma = (from f in program
                                         where (f.Id == item2.id_programa)
                                         select f).ToList();

                for (var dt = item2.d_inicio_programacao; dt <= item2.d_termino_programacao; dt = dt.AddDays(1))
                {
                    if (!dates.Contains(dt))
                    {
                        dates.Add(dt);
                    }
                }




                var sql = "SELECT * FROM Especialista_Paciente e WHERE e.id_especialista = " + especialista.Id + " and e.id_paciente = " + paciente + " ORDER BY e.data_exclusao = NULL, e.Id DESC ";

                var especialistapaciente = (from f in _context.Especialista_Paciente.FromSql(sql)
                                            select f).FirstOrDefault();



                foreach (var item3 in dates)
                {
                    var dataDia = (int)item3.DayOfWeek;
                    if (diasprogramacao.Contains(dataDia))
                    {
                        var obj = new EvolutivosPacientes();
                        obj.Data = item3;
                        obj.data_formatada = item3.ToString("dd/MM/yyyy");
                        obj.Inseridos = evolutivos.Where(c => c.Data == item3).Count();
                        obj.Limite = item2.n_limite;
                        obj.Paciente = paciente;
                        obj.LimiteDiario = diasLimite.Where(c => c.id_dia == dataDia).FirstOrDefault().atendimentos_dia;
                        obj.checkout = _context.Checkin.Where(c => c.id_paciente == item2.id_paciente && c.Data.Date == item3).Count();
                        if (especialistapaciente.data_exclusao == null || item3 <= especialistapaciente.data_exclusao)
                        {
                            Lista.Add(obj);
                        }
                    }
                }
            }

            return Lista;


        }

        [HttpGet]
        [Route("api/Pacientes/listarevolutivosPacientes")]
        public IList<listarevolutivosviewmodel> listarevolutivosPacientes(int paciente, DateTime data_evolutivo)
        {
            string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
            DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);

            var especialista = (from f in _context.Cadastro_Especialista
                                where f.id_usuario == usuarioResponse.Id
                                select f).FirstOrDefault();

            var lista = (from f in _context.EvolucaoPacienteTxt
                         where (f.Id_Paciente == paciente)
                         where (f.Id_especialista == especialista.Id)
                         where (f.Data.Date == data_evolutivo.Date)
                         select new listarevolutivosviewmodel
                         {
                             texto = f.ConteudoTxt,
                             data = f.Data.ToShortDateString(),
                             imagem_url = f.imagem_url
                         }).ToList();


            return lista;
        }

        [HttpGet]
        [Route("api/Pacientes/ListarFichas")]
        public IList<listarfichas> ListarFichas(int paciente, string data_evolutivo)
        {
            string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
            DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);

            var especialista = (from f in _context.Cadastro_Especialista
                                where f.id_usuario == usuarioResponse.Id
                                select f).FirstOrDefault();

            var lista = (from f in _context.Produtividade_Mensal
                         where (f.paciente == paciente)
                         where (f.id_especialista == especialista.Id)
                         where (f.periodo == data_evolutivo)
                         select new listarfichas
                         {
                             texto = f.observacao,
                             atendimentos = "Atendimentos: " + f.atendimentos_dentro_imagem,
                             imagem_url = f.url_google
                         }).ToList();


            return lista;
        }



        [HttpPost]
        [Route("api/Pacientes/Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] EvolucaoPacienteTxtViewModel request)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    var obj2 = new EvolucaoPacienteTxt();
                    string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                    DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                    var especialista = (from f in _context.Cadastro_Especialista
                                        where (f.id_usuario == usuarioResponse.Id)
                                        select f).FirstOrDefault();




                    var verificaInternacao = (from f in _context.Paciente_Internacao
                                              where (f.data_exclusao == null)
                                              where (f.d_internacao >= request.dataevolutivo && f.d_internacao <= request.dataevolutivo || f.d_alta >= request.dataevolutivo && f.d_alta <= request.dataevolutivo)
                                              where (f.id_paciente == request.id_paciente)
                                              select f).Count();
                    if (verificaInternacao > 0)
                    {
                        return Ok("Paciente Internado");

                    }

                    if (!string.IsNullOrEmpty(request.imagem_url))
                    {
                        var encodedTextBytes = Convert.FromBase64String(request.imagem_url);
                        Stream stream = new MemoryStream(encodedTextBytes);
                        Guid id = Guid.NewGuid();
                        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                        .Child(id + ".jpg")
                        .PutAsync(stream);
                        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
                        var downloadUrl = await task;
                        obj2.imagem_url = downloadUrl;
                        obj2.sem_ficha = "Sim";
                    }
                    else
                    {
                        return Ok("A Imagem é obrigatória");

                    }


                    var dt = request.dataevolutivo.Value.ToString("yyyy-MM-dd");
                    //var programa_paciente = _context.Programacao_Pacientes.Where(c => dt.Day  >= c.d_inicio_programacao.Day && dt.Month >= c.d_inicio_programacao.Month  && dt.Year >= c.d_inicio_programacao.Year && c.id_especialidade == especialista.id_area_atuacao && c.id_paciente == request.id_paciente).FirstOrDefault();

                    var sql = "SELECT * FROM Programacao_Pacientes p WHERE p.id_paciente = " + request.id_paciente + " AND '" + dt + "' between p.d_inicio_programacao  AND  p.d_termino_programacao AND p.n_limite > 0 AND  id_especialidade = " + especialista.id_area_atuacao;

                    var programa_paciente = (from f in _context.Programacao_Pacientes.FromSql(sql)
                                             select f).Sum(c => c.n_limite);





                    //var programa_paciente = (
                    //    from f in _context.Programacao_Pacientes
                    //    where( f.d_inicio_programacao = dt && f.d_inicio_programacao <= dt)
                    //    where(f.id_especialidade == especialista.id_area_atuacao)
                    //    where(f.id_paciente == request.id_paciente)
                    //    select f
                    //    ).FirstOrDefault();
                    var pendentes = _context.pgto_pendentes.Where(c => c.Profissional == especialista.Id).ToList();
                    var hoje = DateTime.Now;
                    var pendentesn = (from p in pendentes
                                      where (hoje >= p.DataInicio.Date && hoje <= p.DataTermino.Date)
                                      where (p.Paciente == request.id_paciente && p.Profissional == especialista.Id)
                                      select p).Count() > 0 ? "Sim" : "Nao";
                    var evolutiva = _context.EvolucaoPacienteTxt.Where(c => c.Data == request.dataevolutivo && c.Id_Paciente == request.id_paciente && c.Especialidade == especialista.id_area_atuacao).Count();



                    var mesRef = request.dataevolutivo.Value.Month.ToString().PadLeft(2, '0') + "/" + request.dataevolutivo.Value.Year.ToString();
                    var faturado = _context.Faturamento.Where(c => c.id_paciente == request.id_paciente && c.id_especialista == especialista.Id && c.mes_referencia == mesRef && c.data_exclusao == null).Count();

                    var dataDia = (int)request.dataevolutivo.Value.DayOfWeek;
 
                    //if ((evolutiva) >= programa)
                    //{
                    //    return Ok("limite de atendimentos no mês já preenchidos");

                    //}
                    var dataCorte = DateTime.Now.AddMonths(-1);
                    var mesliberado = (hoje.Day <= 2 && request.dataevolutivo.Value.Date >= dataCorte.Date) ? "Sim" : "Nao";


                    var historicoClinico = _context.Cadastro_Historico_Pacientes.Where(c => c.id_paciente == request.id_paciente).Where(c => c.n_status == 1 || c.n_status == 2 || request.dataevolutivo.Value <= c.d_termino).FirstOrDefault();



                    obj2.Data = request.dataevolutivo.Value;
                    obj2.HoraInicio = DateTime.Now.ToString("hh:mm");
                    obj2.HoraTermino = DateTime.Now.AddHours(1).ToString("hh:mm");
                    obj2.data_inclusao = DateTime.Now;
                    obj2.ValorSessao = (from a in _context.Especialista_Paciente
                                        where (a.Id_paciente == request.id_paciente)
                                        where (a.id_especialista == especialista.Id)
                                        select a.v_valor_sessao).FirstOrDefault();
                    //_context.Especialista_Paciente.Where(c => c.Id_paciente == request.id_paciente && c.id_especialista == especialista.Id).FirstOrDefault().v_valor_sessao;
                    obj2.usuario_inclusao = usuarioResponse.Id;
                    obj2.tipo_evolutiva = "Completa";
                    obj2.copia_sn = "Nao";
                    obj2.Especialidade = especialista.id_area_atuacao;
                    obj2.Id_Paciente = request.id_paciente;
                    obj2.Id_especialista = especialista.Id;
                    obj2.ConteudoTxt = request.texto;


                    _context.EvolucaoPacienteTxt.Add(obj2);

                    if (evolutiva >= programa_paciente)
                    {
                        return Ok("limite de atendimentos no mês já preenchidos");
                    }
                    if (faturado > 0)
                    {
                        return Ok("limite de atendimentos no mês já preenchidos");

                    }
                    if ((hoje.Month > request.dataevolutivo.Value.Month) && pendentesn == "Nao" && mesliberado == "Nao")
                    //                if ((hoje.Month > Data.Month) && pendentesn == "Nao" && mesliberado == "Nao")
                    {
                        return Ok("Evolução bloqueada devido a inserção fora do prazo. Solicite liberação ao Faturamento (017)98218-1009.");
                    }
                    if (request.dataevolutivo.Value.Date > DateTime.Now.Date)
                    {
                        return Ok("não é possivel lançar evolutivos futuros");
                    }
                    if (historicoClinico == null)
                    {
                        // return Forbid   ("Paciente sem histórico clinico.");
                        return Ok("Paciente sem histórico clinico");

                    }
                    _context.SaveChanges();
                    transaction.Commit();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
               // return await ResponseExceptionAsync(ex);
               return Ok(ex.Message);

            }
        }


        [HttpPost]
        [Route("api/Pacientes/AdicionarAvaliacao")]
        public async Task<IActionResult> AdicionarAvaliacao([FromBody] avaliacao_paciente request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();

                var obj = new Avaliacoes();
                obj.id_paciente = request.id_paciente;
                obj.id_especialista = especialista.Id;
                obj.d_data = DateTime.Now;
                obj.usuario_inclusao = usuarioResponse.Id;
                obj.data_inclusao = DateTime.Now;
                obj.especialidade = especialista.id_area_atuacao;
                obj.avaliacao_prorrogacao = "A";
                obj.ConteudoTxt = request.texto + "<br/><br/><br/>" + request.texto2 + "<br/><br/><br/>" + request.texto3 + "<br/><br/><br/>" + request.texto4 + "<br/><br/><br/>";
                obj.ConteudoTxt_2 = request.texto + "<br/><br/><br/>" + request.texto2 + "<br/><br/><br/>" + request.texto3 + "<br/><br/><br/>" + request.texto4 + "<br/><br/><br/>";


                if (!string.IsNullOrEmpty(request.url_imagem))
                {
                    var encodedTextBytes = Convert.FromBase64String(request.url_imagem);
                    Stream stream = new MemoryStream(encodedTextBytes);
                    Guid id = Guid.NewGuid();
                    var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                    .Child(id + ".jpg")
                    .PutAsync(stream);

                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    var downloadUrl = await task;
                    obj.url_imagem = downloadUrl;
                }
                if (!string.IsNullOrEmpty(request.url_imagem2))
                {
                    var encodedTextBytes = Convert.FromBase64String(request.url_imagem2);
                    Stream stream = new MemoryStream(encodedTextBytes);
                    Guid id = Guid.NewGuid();
                    var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                    .Child(id + ".jpg")
                    .PutAsync(stream);

                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    var downloadUrl = await task;
                    obj.url_imagem2 = downloadUrl;
                }
                if (!string.IsNullOrEmpty(request.url_imagem3))
                {
                    var encodedTextBytes = Convert.FromBase64String(request.url_imagem3);
                    Stream stream = new MemoryStream(encodedTextBytes);
                    Guid id = Guid.NewGuid();
                    var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                    .Child(id + ".jpg")
                    .PutAsync(stream);

                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    var downloadUrl = await task;
                    obj.url_imagem3 = downloadUrl;
                }
                if (!string.IsNullOrEmpty(request.url_imagem4))
                {
                    var encodedTextBytes = Convert.FromBase64String(request.url_imagem4);
                    Stream stream = new MemoryStream(encodedTextBytes);
                    Guid id = Guid.NewGuid();
                    var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                    .Child(id + ".jpg")
                    .PutAsync(stream);

                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    var downloadUrl = await task;
                    obj.url_imagem4 = downloadUrl;
                }
                if (!string.IsNullOrEmpty(request.url_imagem5))
                {
                    var encodedTextBytes = Convert.FromBase64String(request.url_imagem5);
                    Stream stream = new MemoryStream(encodedTextBytes);
                    Guid id = Guid.NewGuid();
                    var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                    .Child(id + ".jpg")
                    .PutAsync(stream);

                    task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                    var downloadUrl = await task;
                    obj.url_imagem5 = downloadUrl;
                }
                _context.Avaliacoes.Add(obj);


                //else if (especialista.id_area_atuacao == 2)
                //{
                //    var obj = new Avaliacao_Fonoaudiologia();
                //    obj.id_paciente = request.id_paciente;
                //    obj.id_especialista = especialista.Id;
                //    obj.d_data = DateTime.Now;
                //    obj.data_inclusao = DateTime.Now;
                //    obj.avaliacao_prorrogacao = "A";

                //    obj.modo_texto = request.texto + "<br/><br/><br/>" + request.texto2 + "<br/><br/><br/>" + request.texto3 + "<br/><br/><br/>" + request.texto4 + "<br/><br/><br/>";
                //    obj.modo_texto_2 = request.texto + "<br/><br/><br/>" + request.texto2 + "<br/><br/><br/>" + request.texto3 + "<br/><br/><br/>" + request.texto4 + "<br/><br/><br/>";



                //    if (!string.IsNullOrEmpty(request.url_imagem))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem2))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem2);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem2 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem3))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem3);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem3 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem4))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem4);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem4 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem5))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem5);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem5 = downloadUrl;
                //    }




                //    _context.Avaliacao_Fonoaudiologia.Add(obj);
                //}
                //else if (especialista.id_area_atuacao == 3)
                //{
                //    var obj = new Avaliacao_Terapia_Ocupacional();
                //    obj.id_paciente = request.id_paciente;
                //    obj.id_especialista = especialista.Id;
                //    obj.d_data = DateTime.Now;
                //    obj.data_inclusao = DateTime.Now;
                //    obj.avaliacao_prorrogacao = "A";

                //    obj.modo_texto = request.texto + "<br/><br/><br/>" + request.texto2 + "<br/><br/><br/>" + request.texto3 + "<br/><br/><br/>" + request.texto4 + "<br/><br/><br/>";
                //    obj.modo_texto_2 = request.texto + "<br/><br/><br/>" + request.texto2 + "<br/><br/><br/>" + request.texto3 + "<br/><br/><br/>" + request.texto4 + "<br/><br/><br/>";


                //    if (!string.IsNullOrEmpty(request.url_imagem))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem2))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem2);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem2 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem3))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem3);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem3 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem4))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem4);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem4 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem5))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem5);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem5 = downloadUrl;
                //    }




                //    _context.Avaliacao_Terapia_Ocupacional.Add(obj);

                //}
                //else if (especialista.id_area_atuacao == 4)
                //{
                //    var obj = new Avaliacao_Nutricao();
                //    obj.id_paciente = request.id_paciente;
                //    obj.id_especialista = especialista.Id;
                //    obj.d_data = DateTime.Now;
                //    obj.data_inclusao = DateTime.Now;
                //    obj.avaliacao_prorrogacao = "A";
                //    obj.modo_texto = request.texto + "<br/><br/><br/>" + request.texto2 + "<br/><br/><br/>" + request.texto3 + "<br/><br/><br/>" + request.texto4 + "<br/><br/><br/>";
                //    obj.modo_texto_2 = request.texto + "<br/><br/><br/>" + request.texto2 + "<br/><br/><br/>" + request.texto3 + "<br/><br/><br/>" + request.texto4 + "<br/><br/><br/>";




                //    if (!string.IsNullOrEmpty(request.url_imagem))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem2))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem2);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem2 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem3))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem3);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem3 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem4))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem4);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem4 = downloadUrl;
                //    }
                //    if (!string.IsNullOrEmpty(request.url_imagem5))
                //    {
                //        var encodedTextBytes = Convert.FromBase64String(request.url_imagem5);
                //        Stream stream = new MemoryStream(encodedTextBytes);
                //        Guid id = Guid.NewGuid();
                //        var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                //        .Child(id + ".jpg")
                //        .PutAsync(stream);

                //        task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                //        var downloadUrl = await task;
                //        obj.url_imagem5 = downloadUrl;
                //    }

                //    _context.Avaliacao_Nutricao.Add(obj);

                //}
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }




        [HttpPost]
        [Route("api/Pacientes/AdicionarResumo")]
        public async Task<IActionResult> AdicionarResumo([FromBody] EvolucaoPacienteTxtViewModel request)
        {
            try
            {
                int mesFaturamento = 0;
                int AnoFaturamento = 0;

                if (!string.IsNullOrEmpty(request.mesesevolutivo))
                {
                    mesFaturamento = Convert.ToInt32(request.mesesevolutivo.Split('/')[0]);
                    AnoFaturamento = Convert.ToInt32(request.mesesevolutivo.Split('/')[1]);
                }

                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();


                var obj2 = new EvolucaoPacienteTxt();
                obj2.Data = new DateTime(AnoFaturamento, mesFaturamento, 1);
                obj2.HoraInicio = DateTime.Now.ToString("hh:mm");
                obj2.HoraTermino = DateTime.Now.AddHours(1).ToString("hh:mm");
                obj2.data_inclusao = DateTime.Now;
                obj2.ValorSessao = (from a in _context.Especialista_Paciente
                                    where (a.Id_paciente == request.id_paciente)
                                    where (a.id_especialista == especialista.Id)
                                    select a.v_valor_sessao).FirstOrDefault();
                //_context.Especialista_Paciente.Where(c => c.Id_paciente == request.id_paciente && c.id_especialista == especialista.Id).FirstOrDefault().v_valor_sessao;
                obj2.usuario_inclusao = usuarioResponse.Id;
                obj2.tipo_evolutiva = "Completa";
                obj2.copia_sn = "Nao";
                obj2.Especialidade = especialista.id_area_atuacao;
                obj2.Id_Paciente = request.id_paciente;
                obj2.Id_especialista = especialista.Id;
                obj2.ConteudoTxt = request.texto;

                var encodedTextBytes = Convert.FromBase64String(request.imagem_url);
                Stream stream = new MemoryStream(encodedTextBytes);
                Guid id = Guid.NewGuid();
                var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                .Child(id + ".jpg")
                .PutAsync(stream);

                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                var downloadUrl = await task;
                obj2.imagem_url = downloadUrl;
                _context.EvolucaoPacienteTxt.Add(obj2);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }


        //[HttpPost]
        //[Route("api/Pacientes/AdicionarEndereco")]
        //public async Task<IActionResult> AdicionarEndereco([FromBody]encontreviewmodel request)
        //{
        //    try
        //    {
        //        string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
        //        DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
        //        var especialista = (from f in _context.Cadastro_Especialista
        //                            where (f.id_usuario == usuarioResponse.Id)
        //                            select f).FirstOrDefault();


        //        var obj = new Endereco_Especialista();
        //        obj.c_cep = request.cep;
        //        obj.c_logradouro = request.logradouro + " " +request.bairro+" " + request.cidade + " " + request.estado;
        //        obj.id_especialista = especialista.Id;
        //        ob
        //        _context.Endereco_Especialista.Add(obj);
        //        _context.SaveChanges();
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return await ResponseExceptionAsync(ex);
        //    }
        //}




        [HttpPost]
        [Route("api/Pacientes/AdicionarFicha")]
        public async Task<IActionResult> AdicionarFicha([FromBody] inserirFichaViewModel request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();


                var obj2 = new Produtividade_Mensal();
                var encodedTextBytes = Convert.FromBase64String(request.imagem_url);
                Stream stream = new MemoryStream(encodedTextBytes);
                Guid id = Guid.NewGuid();
                var task = new FirebaseStorage("fisaep-4819e.appspot.com")
                .Child(id + ".jpg")
                .PutAsync(stream);

                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                var downloadUrl = await task;
                obj2.url_imagem = downloadUrl;
                obj2.url_google = downloadUrl;

                obj2.atendimentos_dentro_imagem = string.IsNullOrEmpty(request.atendimentos) ? "1" : request.atendimentos;
                obj2.id_especialista = especialista.Id;
                obj2.observacao = request.texto;
                obj2.paciente = request.id_paciente;
                obj2.periodo = request.mes;
                obj2.data_inclusao = DateTime.Now;
                obj2.usuario_inclusao = usuarioResponse.Id;
                obj2.id_especialidade = especialista.id_area_atuacao;
                _context.Produtividade_Mensal.Add(obj2);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok("Erro ai inserir avaliação");
            }
        }




        [HttpPost]
        [Route("api/Pacientes/Checkin")]
        public async Task<IActionResult> Checkin([FromBody] checkinviewmodel request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();


                var obj = new Checkin();
                obj.Data = request.dataevolutivo;
                obj.id_paciente = request.id_paciente;
                obj.id_especialista = especialista.Id;
                obj.Latitude = request.latitude;
                obj.Longitude = request.longitude;
                obj.tipo_operacao = "I";
                obj.Logradouro = request.endereco;
                _context.Add(obj);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Pacientes/RegistrarDevice")]
        public async Task<IActionResult> RegistrarDevice([FromBody] DeviceVieoModel model)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();

                especialista.token = model.tokennotification;
                _context.Entry(especialista).State = EntityState.Modified;


                //if (model.acesso == "S")
                //{
                //    var obj = new MensagensApp();
                //    obj.titulo = "Bem Vindo ao Aplicativo Fisaep";
                //    obj.descricao = "Aqui você poderá realizar todos os procedimentos e terá um suporte a todos os processos realizados aqui.<br/> Onde você poderá enviar sua Ficha de Produtividade, seus evolutivos, e sua prorrogação mais rápido e fácil!<br/> Com novos processos o aplicativo Fisaep vem para revolucionar.";
                //    obj.id_especialista = especialista.Id;
                //    _context.MensagensApp.Add(obj);
                //}

                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }


        [HttpGet]
        [Route("api/Pacientes/Faturamento")]
        public IList<faturamentomensal> Faturamento()
        {
            string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
            DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);

            var especialista = (from f in _context.Cadastro_Especialista
                                where f.id_usuario == usuarioResponse.Id
                                //  where f.id_usuario == "078fcc64-02c5-4106-ba0b-71cfb73d65f7"

                                select f).FirstOrDefault();

            var fat = (from f in _context.Faturamento
                       where (f.data_exclusao == null)
                       where f.id_especialista == especialista.Id
                       select f);

            var fatextra = (from f in _context.Faturamento_Extra
                            where (f.data_exclusao == null)
                            where f.Especialista == especialista.Id
                            select f);

            var fatcorreios = (from f in _context.Faturamento_Correios
                               where (f.data_exclusao == null)
                               where f.EspecialistaId == especialista.Id
                               select f);

            var listaDatas = new List<DateTime>();

            foreach (var item in fat)
            {
                listaDatas.Add(new DateTime(item.data_autorizacao.Value.Year, item.data_autorizacao.Value.Month, 1));
            }
            foreach (var item in fatextra)
            {
                //listaDatas.Add(item.DataHora.Value.Date);
                listaDatas.Add(new DateTime(item.DataHora.Value.Year, item.DataHora.Value.Month, 1));

            }
            foreach (var item in fatcorreios)
            {
                listaDatas.Add(new DateTime(item.DataHora.Value.Year, item.DataHora.Value.Month, 1));
            }

            listaDatas = listaDatas.Distinct().OrderByDescending(c => c.Date).ToList();


            var listaFat = new List<faturamentomensal>();
            foreach (var item in listaDatas)
            {
                var obj = new faturamentomensal();
                obj.mes_faturamento = item.Month.ToString().PadLeft(2, '0') + "/" + item.Year;
                var faturamentos = (from f in fat
                                    where (f.data_autorizacao.Value.Month == item.Month && f.data_autorizacao.Value.Year == item.Year)
                                    select new FaturamentoViewModel
                                    {
                                        Mes_Referencia = f.mes_referencia,
                                        Paciente = f.id_paciente > 0 ? (from p in _context.Cadastro_Pacientes
                                                                        where (p.Id == f.id_paciente)
                                                                        select p.c_nome).FirstOrDefault() : "",
                                        ValorTotal = f.valor_pagto.Value.ToString("N2"),
                                        ValorDecimal = f.valor_pagto.Value,
                                    }).ToList();
                obj.FaturamentoViewModel = faturamentos;


                var faturamentosextra = (from f in fatextra
                                         where (f.DataHora.Value.Month == item.Month && f.DataHora.Value.Year == item.Year)
                                         select new FaturamentoExtraViewModel
                                         {
                                             MesReferencia = f.DataRef,
                                             Descricao = "",
                                             Valor = f.Valor.Value.ToString("N2"),
                                             ValorDecimal = f.Valor.Value,

                                         }).ToList();
                obj.FaturamentoExtraViewModel = faturamentosextra;

                var faturamentoCorreio = (from f in fatcorreios
                                          where (f.DataHora.Value.Month == item.Month && f.DataHora.Value.Year == item.Year)
                                          select new FaturamentoCorreiosViewModel
                                          {
                                              MesReferencia = f.DataRef,
                                              Valor = f.Valor.ToString("N2"),
                                              ValorDecimal = f.Valor,
                                          }).ToList();
                obj.FaturamentoCorreiosViewModel = faturamentoCorreio;

                obj.Desconto = BuscarDesconto(especialista.Id).Value.ToString("N2");
                obj.Total = ((faturamentos.Sum(c => c.ValorDecimal) + faturamentosextra.Sum(c => c.ValorDecimal) + faturamentoCorreio.Sum(c => c.ValorDecimal)) - (BuscarDesconto(especialista.Id).Value)).ToString("N2");

                listaFat.Add(obj);
            }
            return listaFat;
        }

        //faltas do especialista
        [HttpGet]
        [Route("api/Pacientes/FaltasEspecialista")]
        public IList<getfaltas> FaltasEspecialista()
        {
            string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
            DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);

            var especialista = (from f in _context.Cadastro_Especialista
                                where f.id_usuario == usuarioResponse.Id
                                select f).FirstOrDefault();


            var select = (from f in _context.falta_especialista
                          where (f.id_especialista == especialista.Id)
                          select new getfaltas
                          {
                              datafalta = f.data_falta,
                              motivo = f.motivo_falta,
                              paciente = (from p in _context.Cadastro_Pacientes
                                          where p.Id == f.id_paciente
                                          select p.c_nome).FirstOrDefault()
                          }).OrderByDescending(c => c.datafalta).ToList();


            return select;

        }



        [HttpPost]
        [Route("api/Pacientes/AdicionarFalta")]
        public async Task<IActionResult> AdicionarFalta([FromBody] faltaviewmodel request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();


                var obj = new falta_especialista();
                obj.data_falta = request.data_falta;
                obj.data_inclusao = DateTime.Now;
                obj.id_especialista = especialista.Id;
                obj.id_paciente = request.id_paciente;
                obj.motivo_falta = request.motivo_falta;
                obj.usuario_inclusao = usuarioResponse.Id;
                _context.falta_especialista.Add(obj);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }


        [HttpPost]
        [Route("api/Pacientes/excluirEndereco")]
        public async Task<IActionResult> excluirEndereco([FromBody] especialistaEndereco model)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();


                var busca = (from f in _context.Endereco_Especialista
                             where f.Id == model.id
                             select f).FirstOrDefault();


                busca.data_exclusao = DateTime.Now;
                busca.usuario_exclusao = usuarioResponse.Id;
                _context.Entry(busca).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }



        [HttpPost]
        [Route("api/Pacientes/SalvarEndereco")]
        public async Task<IActionResult> SalvarEndereco([FromBody] encontreviewmodel request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();




                var obj = new Endereco_Especialista();
                obj.c_logradouro = request.logradouro;

                IGeocoder geocoder = new GoogleGeocoder() { ApiKey = "AIzaSyBoezbbpAPUtqW3WmG-VvQtN_191DBDwy4" };
                IEnumerable<Address> addresses = await geocoder.GeocodeAsync(obj.c_logradouro);

                obj.latitude = addresses.First().Coordinates.Latitude.ToString();
                obj.longitude = addresses.First().Coordinates.Longitude.ToString();
                // obj.c_cep = addresses.First().
                obj.c_cep = GetPostalCode(request.logradouro);
                obj.id_especialista = especialista.Id;
                obj.usuario_inclusao = usuarioResponse.Id;
                _context.Endereco_Especialista.Add(obj);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }



        [HttpGet]
        [Route("api/Pacientes/GetEnderecos")]
        public IList<especialistaEndereco> GetEnderecos()
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                DadosUsuario usuarioResponse = JsonConvert.DeserializeObject<DadosUsuario>(usuarioClaims);
                var especialista = (from f in _context.Cadastro_Especialista
                                    where (f.id_usuario == usuarioResponse.Id)
                                    select f).FirstOrDefault();


                var busca = (from f in _context.Endereco_Especialista
                             where (f.id_especialista == especialista.Id)
                             where (f.data_exclusao == null)
                             select new especialistaEndereco
                             {
                                 endereco = f.c_logradouro,
                                 complemento = f.c_complemento,
                                 cep = f.c_cep,
                                 id = f.Id
                             }).ToList();
                return busca;
            }
            catch (Exception ex)
            {
                return new List<especialistaEndereco>();
            }
        }

        public ActionResult BuscarCep(string cep)
        {
            if (!string.IsNullOrEmpty(cep))
            {
                var buscacep = ViaCEPClient.Search(cep.Replace(".", "").Replace("-", ""));


                var endereco = buscacep.Street + "  " + buscacep.Neighborhood + " " + buscacep.StateInitials;

                return Json(endereco);
            }
            else
            {
                return Json(new { Logradouro = "" });
            }
        }

        string GetPostalCode(string address)
        {
            string postalCode = "";
            var xml = new XmlDocument();

            var url = "https://maps.googleapis.com/maps/api/geocode/xml?address=" + address + "&sensor=true&key=AIzaSyBoezbbpAPUtqW3WmG-VvQtN_191DBDwy4";
            xml.Load(url);
            var components = xml["GeocodeResponse"]["result"].ChildNodes;
            foreach (XmlElement x in components)
            {
                if (x.Name == "address_component" && x["type"].InnerText == "postal_code")
                {
                    postalCode = x["long_name"].InnerText;
                    break;
                }
            }
            return postalCode;
        }


        private decimal? BuscarDesconto(int? key)
        {

            var retorno = 0;

            // var list = _context.NaoDescontarDocs.Where(c => c.data_exclusao == null).Select(c => c.id_especialista).ToList();
            var list = (from f in _context.NaoDescontarDocs
                        where (f.id_especialista == key)
                        where (f.data_exclusao == null)
                        select f
                        ).FirstOrDefault();


            if (list != null)
            {
                //  var conta = _context.Contas_Bancaria.Where(c => c.id_especialista == key).OrderByDescending(c => c.Id).FirstOrDefault();
                var conta = (from f in _context.Contas_Bancaria
                             where f.id_especialista == key
                             select f).OrderByDescending(c => c.Id).FirstOrDefault();
                if (!conta.c_banco.Contains("33"))
                {
                    retorno = retorno + 3;
                }
            }

            return retorno;
        }


    }
}
