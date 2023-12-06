using MMIP.Shared.Utilities;

namespace MMIP.Shared.Enums
{
    public enum CommentType
    {
        [CommentType(
            iconPath: "Assets/Img/CommentQuestion.png",
            name: "Ik heb een vraag!",
            description: "Deze type reactie houdt in dat de gebruiker een vraag heeft over de challenge. De maker van de challenge kan hierbij de gebruiker een mailtje sturen om de vraag te beantwoorden."
        )]
        Question,

        [CommentType(
            iconPath: "Assets/Img/CommentFeedback.png",
            name: "Ik heb feedback!",
            description: "Deze type reactie houdt in dat de gebruiker feedback heeft over de challenge. Feedback kan variëren van typefouten tot missende informatie."
        )]
        Feedback,

        [CommentType(
            iconPath: "Assets/Img/CommentParticipation.png",
            name: "Ik zou de challenge willen uitvoeren!",
            description: "Deze type reactie houdt in dat de gebruiker zich openstelt om de challenge uit te voeren. De maker van de challenge kan de reactie afvinken en de gebruiker laten weten dat hij of zij is uitgekozen om de challenge uit te voeren."
        )]
        Participation,

        [CommentType(
            iconPath: "Assets/Img/CommentIdea.png",
            name: "Ik heb een idee!",
            description: "Deze type reactie houdt in dat de gebruiker een idee heeft dat bij de challenge past. De maker van de challenge kan goede ideeën afvinken en toevoegen aan de challenge."
        )]
        Idea
    }
}
