using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SeaFightGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameWindow());
        }
    }
}

//-1. Коли гра закінчена, показати кораблі противника
// 0. Відрефакторити весь код
// 1. Не розставляє кораблі компютер, якщо одразу розставити самому
// 2. Коли гра закінчена, на своєму полі можна знову розставляти кораблі
// 3. Діалог нової гри не закінчений
// 4. Довести до пуття діалог кінця гри
// 5. Рознести незалежні рівні по різних dll-ках (графіка-контрол, модель, алгоритми)
// 6. Залити гру на GitHub
// 7. Скомпонувати все, використавши якийсь DI контейнер
// 8. Реалізувати гру по мережі (десктоп-десктоп)
// 9. Реалізувати гру по мережі (десктоп-браузер)
// 10. Добавити більш сильний алгоритм AI.
// 11. Зробити графіку через WPF.