using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Entities
{
    public class Usuario
    {
        public Guid UsuarioId { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;
        public DateTime DataCriacao { get; private set; }
        public Endereco Endereco { get; private set; }

        public TipoUsuario Tipo { get; private set; }

        public Usuario() { } // Construtor vazio para o framework conseguir mapear
        public Usuario(string nome, string email, string senhaHash, string telefone, Endereco endereco, TipoUsuario tipo)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome é obrigatório");
            if (!email.Contains("@")) throw new ArgumentException("Email inválido");
            if (string.IsNullOrWhiteSpace(senhaHash)) throw new ArgumentException("Senha é obrigatória");

            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Telefone = telefone;
            DataCriacao = DateTime.Now; // Data de criação no momento da instância
            Endereco = endereco;
            Tipo = tipo;
        }

        public void AtualizarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone)) throw new ArgumentException("Telefone inválido");
            Telefone = telefone;
        }

        public void AtualizarSenha(string novaSenhaHash)
        {
            if (string.IsNullOrWhiteSpace(novaSenhaHash)) throw new ArgumentException("Senha não pode ser vazia");
            SenhaHash = novaSenhaHash;
        }


    }
    public enum TipoUsuario
    {
        Cliente = 0,
        Prestador = 1
    }
}
