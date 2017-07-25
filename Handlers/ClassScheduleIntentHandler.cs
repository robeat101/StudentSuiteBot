using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Zummer.Models.ClassSchedule;
using YamlDotNet.Serialization;
using System.IO;
using System.Text;

namespace Zummer.Handlers
{
    internal sealed class ClassScheduleIntentHandler : IIntentHandler
    {
        private readonly IBotToUser botToUser;

        public ClassScheduleIntentHandler(IBotToUser botToUser)
        {
            SetField.NotNull(out this.botToUser, nameof(botToUser), botToUser);
        }

        public async Task Respond(IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            var testCourse = new Course();
            var serializer = new Serializer();
            var stringBuilder = new StringBuilder(); 
            var testStringWriter = new StringWriter(stringBuilder);
            serializer.Serialize(testStringWriter, testCourse);
            await this.botToUser.PostAsync("```" + stringBuilder.ToString() + "```");
        }
    }
}