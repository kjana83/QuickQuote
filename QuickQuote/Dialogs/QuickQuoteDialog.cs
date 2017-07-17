using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;

namespace QuickQuote.Dialogs
{
    [Serializable]
    public class QuickQuoteDialog
    {
        public static readonly IDialog<string> dialog = Chain.PostToChain()
            .Select(msg => msg.Text)
            .Switch(
            //new RegexCase<IDialog<string>>(new Regex("^hi", RegexOptions.IgnoreCase), (context, text) =>
            //{
            //    return Chain.ContinueWith(new GreetingDialog(), AfterGreetingContinuation);
            //}),
            new DefaultCase<string, IDialog<string>>((context, text) =>
            {
                return Chain.ContinueWith(FormDialog.FromForm(Model.QuickQuote.BuildForm, FormOptions.PromptInStart), AfterGreetingContinuation);
            }))
            .Unwrap()
            .PostToUser();

        private async static Task<IDialog<string>> AfterGreetingContinuation(IBotContext context, IAwaitable<object> item)
        {
            var token = await item;
            var name = "user";
            context.UserData.TryGetValue("Name", out name);
            var refNumber = "QTE0012455356";
            return Chain.Return($"Thanks for using Quick Quote Bot,Premium is £150, Your quote reference number is {refNumber}");
        }

    }
}