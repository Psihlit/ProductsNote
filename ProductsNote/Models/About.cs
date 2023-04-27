using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsNote.Models
{
    internal class About
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://learn.microsoft.com/ru-ru/dotnet/maui/tutorials/notes-app/?view=net-maui-6.0";
        public string Message => "Это приложение написано с помощью XAML и C#, используя .NET MAUI.";
        public string Message2 => "Для создания использовался гайд, предоставленный ниже.";
        public string Message3 => "Работу выполнил студент группы 090304-РПИа-о20 Кушнеров А. С.";
    }
}
