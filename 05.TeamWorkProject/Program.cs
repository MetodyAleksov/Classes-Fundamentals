using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace _05.TeamWorkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(teamCount);
            for (int i = 0; i < teamCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("-")
                    .ToArray();
                Team newTeam = new Team(input[0], input[1]);
                if (teams.Select(x => x.Name).Contains(newTeam.Name))
                {
                    Console.WriteLine($"Team {newTeam.Name} was already created!");
                }
                else if (teams.Select(x => x.Creator).Contains(newTeam.Creator))
                {
                    Console.WriteLine($"{newTeam.Creator} cannot create another team!");
                }
                else
                {
                    teams.Add(newTeam);
                    Console.WriteLine($"Team {newTeam.Name} has been created by {newTeam.Creator}!");
                }
            }
            string[] users = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while(users[0] != "end of assignment")
            {
                bool isCreator = teams.Select(x => x.Creator).Contains(users[0]);
                bool isMember = teams.Select(x => x.Members).Any(x => x.Contains(users[0]));
                if (!teams.Select(x => x.Name).Contains(users[1]))
                {
                    Console.WriteLine($"Team {users[1]} does not exist!");
                }
                else if (isCreator == true || isMember == true)
                {
                    Console.WriteLine($"Member {users[0]} cannot join team {users[1]}!");
                }
                else
                {
                    int index = teams.FindIndex(x => x.Name == users[1]);
                    teams[index].Members.Add(users[0]);
                }
                users = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            List<Team> disbandingTeams = new List<Team>();
            List<Team> finalTeam = new List<Team>();
            foreach (Team item in teams)
            {
                if (item.Members.Count == 0)
                {
                    disbandingTeams.Add(item);
                }
                else
                {
                    finalTeam.Add(item);
                }
            }
            finalTeam = finalTeam.OrderByDescending(x => x.Members.Count)
                         .ThenBy(x => x.Name)
                         .ToList();
            disbandingTeams = disbandingTeams.OrderBy(x => x.Name).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (Team item in finalTeam)
            {
                sb.AppendLine($"{item.Name}");
                sb.AppendLine($"- {item.Creator}");

                foreach (string member in item.Members)
                {
                    sb.AppendLine($"-- {member}");
                }
            }
            sb.AppendLine("Teams to disband: ");
            foreach (Team item in disbandingTeams)
            {
                sb.AppendLine(item.Name);
            }
            Console.WriteLine(sb.ToString());
        }
    }
    class Team
    {
        public Team(string creator, string name)
        {
            Creator = creator;
            Name = name;
            Members = new List<string>();
        }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
        public string Name { get; set; }
    }
}
