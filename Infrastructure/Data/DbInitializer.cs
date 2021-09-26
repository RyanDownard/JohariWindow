using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Adjective.Any())
            {
                var adjectives = new List<Adjective>
                {
                    new Adjective { AdjName = "Able", AdjDefinition = "Having the power, skill, means, or opportunity to do something", AdjType = true },
                    new Adjective { AdjName = "Accepting", AdjDefinition = "Tending to regard different types of people and ways of life with tolerance and acceptance", AdjType = true },
                    new Adjective { AdjName = "Adaptable", AdjDefinition = "Capable of being or becoming adapted (suited by nature, character, or design to a particular use, purpose, or situation)", AdjType = true },
                    new Adjective { AdjName = "Bold", AdjDefinition = "Showing or requiring a fearless daring spirit", AdjType = true },
                    new Adjective { AdjName = "Brave", AdjDefinition = "Having or showing mental or moral strength to face danger, fear, or difficulty", AdjType = true },
                    new Adjective { AdjName = "Calm", AdjDefinition = "A quiet and peaceful state or condition", AdjType = true },
                    new Adjective { AdjName = "Caring", AdjDefinition = "Feeling or showing concern for or kindness to others", AdjType = true },
                    new Adjective { AdjName = "Cheerful", AdjDefinition = "Full of good spirits", AdjType = true },
                    new Adjective { AdjName = "Clever", AdjDefinition = "Showing intelligent thinking", AdjType = true },
                    new Adjective { AdjName = "Incompetent", AdjDefinition = "Not having the skill or ability to do your job or a task as it should be done", AdjType = false },
                    new Adjective { AdjName = "Violent", AdjDefinition = "Showing or caused by very strong emotion", AdjType = false },
                    new Adjective { AdjName = "Insecure", AdjDefinition = "Not confident about yourself or your relationships with other people", AdjType = false },
                    new Adjective { AdjName = "Hostile", AdjDefinition = "Aggressive or unfriendly and ready to argue or fight", AdjType = false },
                    new Adjective { AdjName = "Needy", AdjDefinition = "Not confident, and needing a lot of love and emotional support from other people", AdjType = false },
                    new Adjective { AdjName = "Ignorant", AdjDefinition = "Not having or showing much knowledge or information about things; not educated", AdjType = false },
                    new Adjective { AdjName = "Blasé", AdjDefinition = "Not impressed, excited or worried about something, because you have seen or experienced it many times before", AdjType = false },
                    new Adjective { AdjName = "Embarrassed", AdjDefinition = "Shy, uncomfortable or ashamed, especially in a social situation", AdjType = false },
                    new Adjective { AdjName = "Insensitive", AdjDefinition = "Not realizing or caring how other people feel, and therefore likely to hurt or offend them", AdjType = false },
                    new Adjective { AdjName = "Dispassionate", AdjDefinition = "Not influenced by emotion", AdjType = false },
                    new Adjective { AdjName = "Inattentive", AdjDefinition = "Not paying attention to something/somebody", AdjType = false },
                    new Adjective { AdjName = "Intolerant", AdjDefinition = "Not willing to accept ideas or ways of behaving that are different from your own", AdjType = false },
                    new Adjective { AdjName = "Aloof", AdjDefinition = "Not friendly or interested in other people", AdjType = false },
                    new Adjective { AdjName = "Irresponsible", AdjDefinition = "Not thinking enough about the effects of what they do; not showing a feeling of responsibility", AdjType = false }
                };
                context.Adjective.AddRange(adjectives);
            }

            if (!context.Client.Any())
            {
                var client = new Client
                {
                    FirstName = "Ryan",
                    LastName = "Downard",
                    DOB = new DateTime(1991, 2, 7),
                    Gender = "Male"
                };
                context.Client.Add(client);
            }

            context.SaveChanges();
        }
    }
}
