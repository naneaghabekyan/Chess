using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Data;
using Models;
using System.Security.Principal;

namespace Chess
{
    public class AccountService
    {
        private PlayerRepository playerRepository = new PlayerRepository();

        public void RegisterPlayer(string nickname,string password)
        {
            if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(password))
                throw new InvalidNickOrPasException("Invalid nickname or password");
            
            Player player = new Player(nickname);

            var pas = new PasswordHasher<Player>().HashPassword(player, password);
            player.PasswordHash = pas;

            try
            {
                playerRepository.AddPlayer(player);
            }
            catch { throw new NotUniqueNickException("The nickname already exists"); }
            
        }


        public string Login(string nickname, string password)
        {
            Player player = playerRepository.CheckPlayerExists(nickname);

            if (player == null)
                throw new PlayerDoesNotExistException("Incorrect login");
            
            var result = new PasswordHasher<Player>().VerifyHashedPassword(player, player.PasswordHash, password);
            if (result == PasswordVerificationResult.Success)
            {
                JwtService jwtToken = new JwtService();
                return jwtToken.GenerateToken(player);
            } 
            else
            {
                throw new IncorrectPasswordException("Incorrect password");
            }
            
        }
    }
}
