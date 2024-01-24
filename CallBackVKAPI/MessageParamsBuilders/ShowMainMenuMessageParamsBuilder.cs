using CallBackVKAPI.Controllers.BotCommands;
using CallBackVKAPI.Controllers.ButtonsBuilders;
using VkNet.Model;

namespace CallBackVKAPI.Controllers.MessageParamsBuilders
{
    public class ShowMainMenuMessageParamsBuilder : BaseMessageParamsBuilder
    {
        public ShowMainMenuMessageParamsBuilder(long PeerID) : base(PeerID) => _params = new MessagesSendParams();


        public override IMessageParamsBuilder AddContent()
        {
            _params.RandomId = new DateTime().Millisecond;
            _params.Message = "Меню бота";
            _params.PeerId = _peerID;
            return this;
        }

        public override IMessageParamsBuilder AddKeyboard()
        {
            _params.Keyboard = new MessageKeyboard()
            {
                Inline = true,
                OneTime = false,
                Buttons = MessageKeyboardButtons
            };
            return this;
        }


        /// <summary>
        /// Набор кнопок в отправляемой клавиатуре
        /// </summary>
        private IEnumerable<IEnumerable<MessageKeyboardButton>> MessageKeyboardButtons
        {
            get => new List<List<MessageKeyboardButton>>
                {
                    new List<MessageKeyboardButton>() 
                    {
                        new ShowTodayScheduleButtonBuilder()
                        .SetAction()
                        .SetColor()
                        .Build()
                    },
                    new List<MessageKeyboardButton>()
                    {
                        new ShowTomorrowScheduleButtonBuilder()
                        .SetAction()
                        .SetColor()
                        .Build()
                    },
                    new List<MessageKeyboardButton>()
                    {
                        new AddScheduleTomorrowButtonBuilder()
                        .SetAction()
                        .SetColor()
                        .Build()
                    },
                    new List<MessageKeyboardButton>()
                    {
                        new SubscribeOnUpdateButtonBuilder()
                        .SetAction()
                        .SetColor()
                        .Build()
                    },
                    new List<MessageKeyboardButton>()
                    {
                        new UnSubscribeOnUpdateButtonBuilder()
                        .SetAction()
                        .SetColor()
                        .Build()
                    }
                };
        }
    }
}
