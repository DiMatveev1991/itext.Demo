﻿using TelegramBot_11;
using TelegramBot_11.Models;
using TelegramBot_11.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot_11.Controllers
{
    public class InlineKeyboardController
    {
        //private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;
        public InlineKeyboardController(ITelegramBotClient telegramClient/*,IStorage memoryStorage*/)
        {
            //_memoryStorage = memoryStorage;
            _telegramClient = telegramClient;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if(callbackQuery?.Data == null)
                return;

            Bot.TextTask = callbackQuery.Data;

            //_memoryStorage.GetSession(callbackQuery.From.Id).TextTask = callbackQuery.Data;
            Console.WriteLine($"Контроллер {GetType().Name} обнаружил нажатие на кнопку {callbackQuery.Data}");

            string description = callbackQuery.Data switch
            {
                "len" => " Подсчет длины сообщения",
                "sum" => " Суммирование чисел",
                _ => String.Empty
            };

            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Выбрано: {description}", cancellationToken: ct);
        }
    }
}
