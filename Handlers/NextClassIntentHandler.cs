using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Zummer.Models.ClassSchedule;
using System;

namespace Zummer.Handlers
{
    internal sealed class NextClassIntentHandler : IIntentHandler
    {
        private readonly IBotToUser botToUser;

        public NextClassIntentHandler(IBotToUser botToUser)
        {
            SetField.NotNull(out this.botToUser, nameof(botToUser), botToUser);
        }

        public async Task Respond(IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            var testCourse = new Course();
            var currentTime = DateTime.Now;
            string output = "";

            if (testCourse.Schedule.Count == 0)
            {
                await this.botToUser.PostAsync("There are no classes for this course");
            }
            PeriodDetail nextPeriod = testCourse.Schedule[0];
            nextPeriod.Start = nextPeriod.Start.AddYears(999);

            foreach (PeriodDetail periodDetail in testCourse.Schedule)
            {
                if ((periodDetail.Start >= currentTime) && (periodDetail.Start < nextPeriod.Start))
                {
                    nextPeriod = periodDetail;
                }

            }
            output += "#### Your next class is about " + nextPeriod.LectureTopic + ".\n";
            output += "#### It's on " + nextPeriod.Start.ToShortDateString() + " at " + nextPeriod.Start.ToShortTimeString() + " in " + nextPeriod.Location + ".\n";
            await this.botToUser.PostAsync(output);
        }
    }
}