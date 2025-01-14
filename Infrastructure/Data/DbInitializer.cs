﻿using ApplicationCore.Models;
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
                    new Adjective{AdjName="Able",AdjDefinition="having the power, skill, means, or opportunity to do something",AdjType=true},
                    new Adjective{AdjName="Accepting",AdjDefinition="tending to regard different AdjTypes of people and ways of life with tolerance and acceptance",AdjType=true},
                    new Adjective{AdjName="Adaptable",AdjDefinition="capable of being or becoming adapted (suited by nature, character, or design to a particular use, purpose, or situation)",AdjType=true},
                    new Adjective{AdjName="Bold",AdjDefinition="showing or requiring a fearless daring spirit",AdjType=true},
                    new Adjective{AdjName="Brave",AdjDefinition="having or showing mental or moral strength to face danger, fear, or difficulty",AdjType=true},
                    new Adjective{AdjName="Calm",AdjDefinition="a quiet and peaceful state or condition",AdjType=true},
                    new Adjective{AdjName="Caring",AdjDefinition="feeling or showing concern for or kindness to others",AdjType=true},
                    new Adjective{AdjName="Cheerful",AdjDefinition="full of good spirits",AdjType=true},
                    new Adjective{AdjName="Clever",AdjDefinition="showing intelligent thinking",AdjType=true},
                    new Adjective{AdjName="Complex",AdjDefinition="hard to separate, analyze, or solve",AdjType=true},
                    new Adjective{AdjName="Confident",AdjDefinition="having a feeling or belief that you can do something well or succeed at something",AdjType=true},
                    new Adjective{AdjName="Dependable",AdjDefinition="capable of being trusted or depended on",AdjType=true},
                    new Adjective{AdjName="Dignified",AdjDefinition="showing or expressing dignity (the quality or state of being worthy, honored, or esteemed)",AdjType=true},
                    new Adjective{AdjName="Energetic",AdjDefinition="operating with or marked by vigor or effect",AdjType=true},
                    new Adjective{AdjName="Extroverted",AdjDefinition="possessing or arising from an outgoing and gregarious nature",AdjType=true},
                    new Adjective{AdjName="Friendly",AdjDefinition="showing kindly interest and goodwill",AdjType=true},
                    new Adjective{AdjName="Giving",AdjDefinition="affectionate and generous where one's feelings are concerned",AdjType=true},
                    new Adjective{AdjName="Happy",AdjDefinition="showing or causing feelings of pleasure and enjoyment",AdjType=true},
                    new Adjective{AdjName="Helpful",AdjDefinition="of service or assistance",AdjType=true},
                    new Adjective{AdjName="Idealistic",AdjDefinition="having a strong belief in perfect standards and trying to achieve them, even when this is not realistic",AdjType=true},
                    new Adjective{AdjName="Independent",AdjDefinition="confident and free to do things without needing help from other people",AdjType=true},
                    new Adjective{AdjName="Ingenious",AdjDefinition="having a lot of clever new ideas and good at inventing things",AdjType=true},
                    new Adjective{AdjName="Intelligent",AdjDefinition="good at learning, understanding and thinking in a logical way about things; showing this ability",AdjType=true},
                    new Adjective{AdjName="Introverted",AdjDefinition="more interested in your own thoughts and feelings than in spending time with other people",AdjType=true},
                    new Adjective{AdjName="Kind",AdjDefinition="caring about others; gentle, friendly and generous",AdjType=true},
                    new Adjective{AdjName="Knowledgeable",AdjDefinition="knowing a lot",AdjType=true},
                    new Adjective{AdjName="Logical",AdjDefinition="following or able to follow the rules of logic in which ideas or facts are based on other true ideas or facts",AdjType=true},
                    new Adjective{AdjName="Loving",AdjDefinition="feeling or showing love and care for somebody/something",AdjType=true},
                    new Adjective{AdjName="Mature",AdjDefinition="behaving in a sensible way",AdjType=true},
                    new Adjective{AdjName="Modest",AdjDefinition="not talking much about your own abilities or possessions",AdjType=true},
                    new Adjective{AdjName="Nervous",AdjDefinition="easily worried or frightened",AdjType=true},
                    new Adjective{AdjName="Observant",AdjDefinition="good at noticing things around you",AdjType=true},
                    new Adjective{AdjName="Organized",AdjDefinition="able to plan your work, life, etc. well and in an efficient way",AdjType=true},
                    new Adjective{AdjName="Patient",AdjDefinition="able to wait for a long time or accept annoying behaviour or difficulties without becoming angry",AdjType=true},
                    new Adjective{AdjName="Powerful",AdjDefinition="being able to control and influence people and events",AdjType=true},
                    new Adjective{AdjName="Proud",AdjDefinition="feeling pleased and satisfied about something that you own or have done, or are connected with",AdjType=true},
                    new Adjective{AdjName="Quiet",AdjDefinition="(of a feeling or an attitude) definite but not expressed in an obvious way",AdjType=true},
                    new Adjective{AdjName="Reflective",AdjDefinition="thinking deeply about things",AdjType=true},
                    new Adjective{AdjName="Relaxed",AdjDefinition="calm and not anxious or worried",AdjType=true},
                    new Adjective{AdjName="Spiritual",AdjDefinition="believing strongly in a particular religion and obeying its laws and practices",AdjType=true},
                    new Adjective{AdjName="Responsive",AdjDefinition="reacting with interest or enthusiasm",AdjType=true},
                    new Adjective{AdjName="Searching",AdjDefinition="trying to find out the truth about something; complete and serious",AdjType=true},
                    new Adjective{AdjName="Self-assertive",AdjDefinition="very confident and not afraid to express your opinions",AdjType=true},
                    new Adjective{AdjName="Self-conscious",AdjDefinition="nervous or embarrassed about your appearance or what other people think of you",AdjType=true},
                    new Adjective{AdjName="Sensible",AdjDefinition="able to make good judgements based on reason and experience rather than emotion; practical",AdjType=true},
                    new Adjective{AdjName="Sentimental",AdjDefinition="connected with your emotions, rather than reason",AdjType=true},
                    new Adjective{AdjName="Shy",AdjDefinition="nervous or embarrassed about meeting and speaking to other people",AdjType=true},
                    new Adjective{AdjName="Silly",AdjDefinition="showing a lack of thought, understanding, or judgement",AdjType=true},
                    new Adjective{AdjName="Spontaneous",AdjDefinition="often doing things without planning to, because you suddenly want to do them",AdjType=true},
                    new Adjective{AdjName="Sympathetic",AdjDefinition="kind to somebody who is hurt or sad; showing that you understand and care about their problems",AdjType=true},
                    new Adjective{AdjName="Tense",AdjDefinition="nervous or worried, and unable to relax",AdjType=true},
                    new Adjective{AdjName="Trustworthy",AdjDefinition="that you can rely on to be good, honest, sincere, etc.",AdjType=true},
                    new Adjective{AdjName="Warm",AdjDefinition="showing enthusiasm, friendship or love",AdjType=true},
                    new Adjective{AdjName="Wise",AdjDefinition="able to make sensible decisions and give good advice because of the experience and knowledge that you have",AdjType=true},
                    new Adjective{AdjName="Witty",AdjDefinition="clever and humorous",AdjType=true},
                    new Adjective{AdjName="Conscientious",AdjDefinition="taking care to do things carefully and correctly",AdjType=true},
                    new Adjective{AdjName="Attentive",AdjDefinition="listening or watching carefully and with interest",AdjType=true},
                    new Adjective{AdjName="Incompetent",AdjDefinition="not having the skill or ability to do your job or a task as it should be done",AdjType=false},
                    new Adjective{AdjName="Violent",AdjDefinition="showing or caused by very strong emotion",AdjType=false},
                    new Adjective{AdjName="Insecure",AdjDefinition="not confident about yourself or your relationships with other people",AdjType=false},
                    new Adjective{AdjName="Hostile",AdjDefinition="aggressive or unfriendly and ready to argue or fight",AdjType=false},
                    new Adjective{AdjName="Needy",AdjDefinition="not confident, and needing a lot of love and emotional support from other people",AdjType=false},
                    new Adjective{AdjName="Ignorant",AdjDefinition="not having or showing much knowledge or information about things; not educated",AdjType=false},
                    new Adjective{AdjName="Blase",AdjDefinition="not impressed, excited or worried about something, because you have seen or experienced it many times before",AdjType=false},
                    new Adjective{AdjName="Embarrassed",AdjDefinition="shy, uncomfortable or ashamed, especially in a social situation",AdjType=false},
                    new Adjective{AdjName="Insensitive",AdjDefinition="not realizing or caring how other people feel, and therefore likely to hurt or offend them",AdjType=false},
                    new Adjective{AdjName="Dispassionate",AdjDefinition="not influenced by emotion",AdjType=false},
                    new Adjective{AdjName="Inattentive",AdjDefinition="not paying attention to something/somebody",AdjType=false},
                    new Adjective{AdjName="Intolerant",AdjDefinition="not willing to accept ideas or ways of behaving that are different from your own",AdjType=false},
                    new Adjective{AdjName="Aloof",AdjDefinition="not friendly or interested in other people",AdjType=false},
                    new Adjective{AdjName="Irresponsible",AdjDefinition="not thinking enough about the effects of what they do; not showing a feeling of responsibility",AdjType=false},
                    new Adjective{AdjName="Selfish",AdjDefinition="caring only about yourself rather than about other people",AdjType=false},
                    new Adjective{AdjName="Unimaginative",AdjDefinition="not having any original or new ideas",AdjType=false},
                    new Adjective{AdjName="Irrational",AdjDefinition="not based on, or not using, clear logical thought",AdjType=false},
                    new Adjective{AdjName="Imperceptive",AdjDefinition="lacking in perception or insight",AdjType=false},
                    new Adjective{AdjName="Loud",AdjDefinition="talking very loudly, too much and in a way that is annoying",AdjType=false},
                    new Adjective{AdjName="Self-satisfied",AdjDefinition="too pleased with yourself or your own achievements",AdjType=false},
                    new Adjective{AdjName="Overdramatic",AdjDefinition="excessively dramatic or exaggerated",AdjType=false},
                    new Adjective{AdjName="Unreliable",AdjDefinition="that cannot be trusted or depended on",AdjType=false},
                    new Adjective{AdjName="Inflexible",AdjDefinition="unwilling to change their opinions, decisions, etc., or the way they do things",AdjType=false},
                    new Adjective{AdjName="Glum",AdjDefinition="sad, quiet and unhappy",AdjType=false},
                    new Adjective{AdjName="Vulgar",AdjDefinition="not having or showing good taste; not polite, pleasant or well behaved",AdjType=false},
                    new Adjective{AdjName="Unhappy",AdjDefinition="not pleased or satisfied with somebody/something",AdjType=false},
                    new Adjective{AdjName="Inane",AdjDefinition="stupid or silly; with no meaning",AdjType=false},
                    new Adjective{AdjName="Distant",AdjDefinition="not friendly; not wanting a close relationship with somebody",AdjType=false},
                    new Adjective{AdjName="Chaotic",AdjDefinition="without any order; in a completely confused state",AdjType=false},
                    new Adjective{AdjName="Vacuous",AdjDefinition="showing no sign of intelligence or sensitive feelings",AdjType=false},
                    new Adjective{AdjName="Passive",AdjDefinition="accepting what happens or what people do without trying to change anything or oppose them",AdjType=false},
                    new Adjective{AdjName="Dull",AdjDefinition="not interesting or exciting",AdjType=false},
                    new Adjective{AdjName="Cold",AdjDefinition="without emotion; not friendly",AdjType=false},
                    new Adjective{AdjName="Timid",AdjDefinition="shy and nervous; not brave",AdjType=false},
                    new Adjective{AdjName="Stupid",AdjDefinition="showing a lack of thought or good judgement",AdjType=false},
                    new Adjective{AdjName="Lethargic",AdjDefinition="without any energy or enthusiasm for doing things",AdjType=false},
                    new Adjective{AdjName="Unhelpful",AdjDefinition="not helpful or useful; not willing to help somebody",AdjType=false},
                    new Adjective{AdjName="Brash",AdjDefinition="confident in an aggressive way",AdjType=false},
                    new Adjective{AdjName="Childish",AdjDefinition="behaving in a stupid or silly way",AdjType=false},
                    new Adjective{AdjName="Impatient",AdjDefinition="annoyed by somebody/something, especially because you have to wait for a long time",AdjType=false},
                    new Adjective{AdjName="Panicky",AdjDefinition="very anxious about something; feeling or showing panic",AdjType=false},
                    new Adjective{AdjName="Smug",AdjDefinition="looking or feeling too pleased about something you have done or achieved",AdjType=false},
                    new Adjective{AdjName="Predictable",AdjDefinition="behaving or happening in a way that you would expect and therefore boring",AdjType=false},
                    new Adjective{AdjName="Foolish",AdjDefinition="not showing good sense or judgement",AdjType=false},
                    new Adjective{AdjName="Cowardly",AdjDefinition="not brave; not having the courage to do things that other people do not think are especially difficult",AdjType=false},
                    new Adjective{AdjName="Simple",AdjDefinition="ordinary; not special",AdjType=false},
                    new Adjective{AdjName="Withdrawn",AdjDefinition="not wanting to talk to other people; extremely quiet and shy",AdjType=false},
                    new Adjective{AdjName="Cynical",AdjDefinition="believing that people only do things to help themselves rather than for good or honest reasons",AdjType=false},
                    new Adjective{AdjName="Cruel",AdjDefinition="having a desire to cause physical or mental pain and make somebody suffer",AdjType=false},
                    new Adjective{AdjName="Boastful",AdjDefinition="talking about yourself in a very proud way",AdjType=false},
                    new Adjective{AdjName="Weak",AdjDefinition="easy to influence; not having much power",AdjType=false},
                    new Adjective{AdjName="Unethical",AdjDefinition="not morally acceptable",AdjType=false},
                    new Adjective{AdjName="Rash",AdjDefinition="doing something that may not be sensible without first thinking about the possible results; done in this way",AdjType=false},
                    new Adjective{AdjName="Callous",AdjDefinition="not caring about other peopleâ€™s feelings, pain or problems",AdjType=false},
                    new Adjective{AdjName="Humourless",AdjDefinition="not having or showing the ability to laugh at things that other people think are funny",AdjType=false}
                };
                context.Adjective.AddRange(adjectives);
            }

            context.SaveChanges();
        }
    }
}
