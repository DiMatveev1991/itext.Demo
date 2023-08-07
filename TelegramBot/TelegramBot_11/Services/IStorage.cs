using TelegramBot_11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_11.Services
{
    public interface IStorage
    {
        Session GetSession(long chatId);
    }
}
