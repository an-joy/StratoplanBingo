using System.Collections.Generic;

namespace StratoplanBingo.Dictionaries
{
    public static class Storage
    {
        public static Dictionary<int, string> BingoValues = new Dictionary<int, string>();
        static Storage()
        {
            BingoValues.Add(1, "Не начали вовремя");
            BingoValues.Add(2, "Не закончили вовремя");
            BingoValues.Add(3, "Бенефис Андрея Финка");
            BingoValues.Add(4, "Цитаты Стива Джобса");
            BingoValues.Add(5, "НБО - говно");
            BingoValues.Add(6, "Игорь кого-нибудь\r\nобматерил");
            BingoValues.Add(7, "Жалобы\r\nна Белова");
            BingoValues.Add(8, "Бесконечное\r\nподведение итогов");
            BingoValues.Add(9, "Павел сменил\r\nриторику");
            BingoValues.Add(10, "За Связькомом -\r\nбудущее!");
            BingoValues.Add(11, "Григорий,\r\nпокажи ганта");
            BingoValues.Add(12, "Экосистема");
            BingoValues.Add(13, "Нет\r\nпроцесса");
            BingoValues.Add(14, "Нет\r\nбизнес-модели");
            BingoValues.Add(15, "Ну, Белов-то\r\nне дурак");
            BingoValues.Add(16, "Срок\r\nдо ВТ\\ПТ");
            BingoValues.Add(17, "Задействовать Анвара");
            BingoValues.Add(18, "Жень,\r\nты тут?");
            BingoValues.Add(19, "Тут по-быстрому\r\nсделайте хуйню");
            BingoValues.Add(20, "Не Billing, а\r\nBalanceHandler");
            BingoValues.Add(21, "Работать нужно в\r\nкайф");
            BingoValues.Add(22, "Мы не делаем хуйню");
            BingoValues.Add(23, "Алексей\r\nподключился в ВКС");
            BingoValues.Add(24, "Врываемся\r\nс двух ног");
            BingoValues.Add(25, "Приватный\r\nразговор с Павлом");
            BingoValues.Add(26, "Влад, ты думаешь\r\nты умнее меня?");
            BingoValues.Add(27, "Отключайте\r\nNQM нахуй");
            BingoValues.Add(28, "Бедные казахи");
            BingoValues.Add(29, "Не лезьте\r\nв бизнес");
            
            //Накидывай сюда по образцу, \r\n для разделения строк
        }
    }
}
