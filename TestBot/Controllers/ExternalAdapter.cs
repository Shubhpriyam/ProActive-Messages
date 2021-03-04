using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using System.Collections.Concurrent;
using System.Net;
using WebApiHandson.DTOs;
using AdaptiveCards;


namespace TestBot.Controllers
{
    [Route("api/calling")]
    [ApiController]
    public class ExternalAdapter : ControllerBase
    {
        //Adapter is external adapter
        private readonly IBotFrameworkHttpAdapter Adapter;
        private readonly IBot Bot;
        private readonly ConcurrentDictionary<string,ConversationReference> _conversationReferences;
        public ExternalAdapter(IBotFrameworkHttpAdapter adapter, IBot bot, ConcurrentDictionary<string,ConversationReference> conversationReferences)
        {
            Adapter = adapter;
            Bot = bot;
           _conversationReferences = conversationReferences;
        }

        public async Task<IActionResult> ExternalCalling(CommandReadDto cmd)
        {
            foreach (var item in _conversationReferences.Values)
            {
                await ((BotAdapter)Adapter).ContinueConversationAsync("cad35b6c-bdaf-4583-8e19-a680cc500b06", item,async (Context, Token) => await ExternalCallback(cmd,Context,Token), default(CancellationToken));
            }
            var con = new ContentResult();
            con.StatusCode = (int)HttpStatusCode.OK;
            return con;     
        }

        private async Task ExternalCallback(CommandReadDto cmd,ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var Name = cmd.Name;
            var Email = cmd.Email;

            await turnContext.SendActivityAsync(MessageFactory.Attachment(getJson(Name,Email)));
        }

        private Attachment getJson(string name, string email)
        {
            AdaptiveCard card = new AdaptiveCard("1.2")
            {
                Body = new List<AdaptiveElement>()
                {
                    new AdaptiveTextBlock
                    {
                        Text="Adaptive card using Proactive message"
                    },
                    new AdaptiveTextBlock
                    {
                        Text=name
                    },
                    new AdaptiveTextBlock
                    {
                        Text=email
                    }
                }
            };
            Attachment attachment = new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = card
            };
            return attachment;
        }
    }
}
