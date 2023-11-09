using Fisaep.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fisaep.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
        public virtual DbSet<alteracao_pad_paciente> alteracao_pad_paciente { get; set; }
        public virtual DbSet<AspNetClaims> AspNetClaims { get; set; }
        public virtual DbSet<AspNetClients> AspNetClients { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<Avaliacoes> Avaliacoes { get; set; }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Avaliacao_Fisioterapia_Adulto> Avaliacao_Fisioterapia_Adulto { get; set; }
        public virtual DbSet<AvaliacaoAdimissionalPaciente> AvaliacaoAdimissionalPaciente { get; set; }
        public virtual DbSet<Cadastro_Especialista> Cadastro_Especialista { get; set; }
        public virtual DbSet<Cadastro_Historico_Pacientes> Cadastro_Historico_Pacientes { get; set; }
        public virtual DbSet<Cadastro_Pacientes> Cadastro_Pacientes { get; set; }
        public virtual DbSet<Cidades> Cidades { get; set; }
        public virtual DbSet<Clientes_Fisiolar> Clientes_Fisiolar { get; set; }
        public virtual DbSet<Contas_Bancaria> Contas_Bancaria { get; set; }
        public virtual DbSet<Dias> Dias { get; set; }
        public virtual DbSet<Endereco_Especialista> Endereco_Especialista { get; set; }
        public virtual DbSet<endereco_pacientes> endereco_pacientes { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Especialista_Cidades_Atendidas> Especialista_Cidades_Atendidas { get; set; }
        public virtual DbSet<Especialista_Email> Especialista_Email { get; set; }
        public virtual DbSet<Especialista_Especializacoes> Especialista_Especializacoes { get; set; }
        public virtual DbSet<Especialista_Paciente> Especialista_Paciente { get; set; }
        public virtual DbSet<Especialista_Paciente_Permissao> Especialista_Paciente_Permissao { get; set; }
        public virtual DbSet<Especialista_Telefone> Especialista_Telefone { get; set; }
        public virtual DbSet<Estado_Civil> Estado_Civil { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<EvolucaoPaciente> EvolucaoPaciente { get; set; }
        public virtual DbSet<Grupo_Usuario> Grupo_Usuario { get; set; }
        public virtual DbSet<Grupo_Usuario_Permissao> Grupo_Usuario_Permissao { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Nivel_Escolaridade> Nivel_Escolaridade { get; set; }
        public virtual DbSet<Paciente_Internacao> Paciente_Internacao { get; set; }
        public virtual DbSet<Pacientes_Telefone> Pacientes_Telefone { get; set; }
        public virtual DbSet<Procedimentos> Procedimentos { get; set; }
        public virtual DbSet<produtividade_mensal_paciente> produtividade_mensal_paciente { get; set; }
        public virtual DbSet<Programa> Programa { get; set; }
        public virtual DbSet<Programa_Sugestao_Dias> Programa_Sugestao_Dias { get; set; }
        public virtual DbSet<Programacao_Pacientes> Programacao_Pacientes { get; set; }
        public virtual DbSet<responsavel_tecnico> responsavel_tecnico { get; set; }
        public virtual DbSet<Servico_integracao> Servico_integracao { get; set; }
        public virtual DbSet<Sexo> Sexo { get; set; }
        public virtual DbSet<SimNao> SimNao { get; set; }
        public virtual DbSet<solicitacao_material_paciente> solicitacao_material_paciente { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Status_Historico_Pacientes> Status_Historico_Pacientes { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Alteracao_Pad> Alteracao_Pad { get; set; }
        public virtual DbSet<Produtividade_Mensal> Produtividade_Mensal { get; set; }
        public virtual DbSet<solicitacao_material> solicitacao_material { get; set; }
        public virtual DbSet<Evolutiva_Simples> Evolutiva_Simples { get; set; }
        public virtual DbSet<Faturamento> Faturamento { get; set; }
        public virtual DbSet<Avaliacao_Nutricao> Avaliacao_Nutricao { get; set; }
        public virtual DbSet<Avaliacao_Fisioterapia_Infantil> Avaliacao_Fisioterapia_Infantil { get; set; }
        public virtual DbSet<Avaliacao_Terapia_Ocupacional> Avaliacao_Terapia_Ocupacional { get; set; }
        public virtual DbSet<Faturamento_Extra> Faturamento_Extra { get; set; }
        public virtual DbSet<Avaliacao_Fonoaudiologia> Avaliacao_Fonoaudiologia { get; set; }
        public virtual DbSet<Convenios> Convenios { get; set; }
        public virtual DbSet<EvolucaoPacienteTxt> EvolucaoPacienteTxt { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<Especialidade_Licenca> Especialidade_Licenca { get; set; }
        public virtual DbSet<Especialidade_Conselho> Especialidade_Conselho { get; set; }
        public virtual DbSet<Polos_Pacientes> Polos_Pacientes { get; set; }
        public virtual DbSet<Geolocalizacao> Geolocalizacao { get; set; }
        public virtual DbSet<Sequencia_banco> Sequencia_banco { get; set; }
        public virtual DbSet<EvolucaoFono> EvolucaoFono { get; set; }
        public virtual DbSet<evolucao_to> evolucao_to { get; set; }
        public virtual DbSet<CadastrarBancos> CadastrarBancos { get; set; }
        public virtual DbSet<Email_Mkt> Email_Mkt { get; set; }
        public virtual DbSet<PagamentosAvulso> PagamentosAvulso { get; set; }
        public virtual DbSet<Faturamento_Correios> Faturamento_Correios { get; set; }
        public virtual DbSet<pgto_pendentes> pgto_pendentes { get; set; }
        public virtual DbSet<LogErro> LogErro { get; set; }
        public virtual DbSet<ImportacaoPad> ImportacaoPad { get; set; }
        public virtual DbSet<Checkin> Checkin { get; set; }
        public virtual DbSet<NaoDescontarDocs> NaoDescontarDocs { get; set; }
        public virtual DbSet<Clientes_Valores_Padrao> Clientes_Valores_Padrao { get; set; }
        public virtual DbSet<FaturamentoDesconto> FaturamentoDesconto { get; set; }
        public virtual DbSet<Pacientes_Valores> Pacientes_Valores { get; set; }
        public virtual DbSet<CaptacaoProfissionais> CaptacaoProfissionais { get; set; }
        public virtual DbSet<CaptacaoProfissionaisHistorico> CaptacaoProfissionaisHistorico { get; set; }
        public virtual DbSet<EspelhamentoPads> EspelhamentoPads { get; set; }
        public virtual DbSet<StatusEspelhamentos> StatusEspelhamentos { get; set; }
        public virtual DbSet<LoteCobrancas> LoteCobrancas { get; set; }
        public virtual DbSet<TitulosPosGraduacoes> TitulosPosGraduacoes { get; set; }
        public virtual DbSet<CadastroAlunos> CadastroAlunos { get; set; }
       public virtual DbSet<MensagensApp> MensagensApp { get; set; }
        public virtual DbSet<falta_especialista> falta_especialista { get; set; }
        public virtual DbSet<rdstation> rdstation { get; set; }

    }
}
