using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBooking.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;
        public TipoUsuario Tipo { get; private set; } // Cliente ou Prestador

        public Usuario(string nome, string email, string senhaHash, string telefone, TipoUsuario tipo)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome é obrigatório");
            if (!email.Contains("@")) throw new ArgumentException("Email inválido");
            if (string.IsNullOrWhiteSpace(senhaHash)) throw new ArgumentException("Senha é obrigatória");

            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Telefone = telefone;
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
        Cliente,
        Prestador
    }

}
