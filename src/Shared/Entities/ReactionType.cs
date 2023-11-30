using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class ReactionType : BaseEntity
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Description { get; set; }

        // TODO: Remove this once reaction types are defined in the database.
        public static ReactionType Question()
        {
            ReactionType question = new ReactionType();
            question.Name = "Ik heb een vraag!";
            question.Description =
                "Deze type reactie houdt in dat de gebruiker een vraag heeft over de challenge. De maker van de challenge kan hierbij de gebruiker een mailtje sturen om de vraag te beantwoorden.";
            question.IconPath = "Assets/Img/ReactionQuestion.png";
            return question;
        }

        public static ReactionType Idea()
        {
            ReactionType idea = new ReactionType();
            idea.Name = "Ik heb een idee!";
            idea.Description =
                "Deze type reactie houdt in dat de gebruiker een idee heeft dat bij de challenge past. De maker van de challenge kan goede ideeën afvinken en toevoegen aan de challenge.";
            idea.IconPath = "Assets/Img/ReactionIdea.png";
            return idea;
        }

        public static ReactionType Participate()
        {
            ReactionType participate = new ReactionType();
            participate.Name = "Ik zou de challenge willen uitvoeren!";
            participate.Description =
                "Deze type reactie houdt in dat de gebruiker zich openstelt om de challenge uit te voeren. De maker van de challenge kan de reactie afvinken en de gebruiker laten weten dat hij of zij is uitgekozen om de challenge uit te voeren.";
            participate.IconPath = "Assets/Img/ReactionParticipation.png";
            return participate;
        }

        public static ReactionType Feedback()
        {
            ReactionType feedback = new ReactionType();
            feedback.Name = "Ik heb feedback!";
            feedback.Description =
                "Deze type reactie houdt in dat de gebruiker feedback heeft over de challenge. Feedback kan variëren van typefouten tot missende informatie.";
            feedback.IconPath = "Assets/Img/ReactionFeedback.png";
            return feedback;
        }
    }
}
