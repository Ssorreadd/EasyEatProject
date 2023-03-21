using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EasyEat.HelperClasses
{
    public static class AnimationManager
    {
        public static bool IsPlaying { get; private set; }

        /// <summary>
        /// Стандартная версия аниматора.<br/>
        /// Принимает в качестве параметра страницу, на которую нужно перейти.<br/>
        /// Если оставить принимаемое значение пустым - будет произведен переход на предыдущую страницу, если такая имеется.
        /// </summary>
        /// <param name="requiredPage">Страница для перехода</param>
        public static async void GoToPageAnimation(Page? requiredPage = null)
        {
            await Task.Run(() =>
            {
                if (IsPlaying)
                {
                    return;
                }

                IsPlaying = true;

                for (double i = 1.0; i >= 0; i -= 0.05)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new Action(() =>
                    {
                        FrameManager.MainFrame.Opacity = i;
                    }));

                    Thread.Sleep(5);
                }

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new Action(() =>
                {
                    if (requiredPage != null)
                    {
                        FrameManager.MainFrame.Navigate(requiredPage);
                    }
                    else if (FrameManager.MainFrame.CanGoBack)
                    {
                        FrameManager.MainFrame.GoBack();
                    }
                }));

                for (double i = 0.0; i <= 1.0; i += 0.05)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new Action(() =>
                    {
                        FrameManager.MainFrame.Opacity = i;
                    }));

                    Thread.Sleep(5);
                }

                IsPlaying = false;
            });
        }

        /// <summary>
        /// Универсальная версия аниматора.<br/>
        /// Принимает в качестве параметров экземпляр объекта Frame и страницу для перехода.<br/>
        /// Если страница имеет значение NULL, то будет осуществлена полная очистка свойства Frame.Content.
        /// </summary>
        /// <param name="hostFrame">Экземпляр объекта Frame</param>
        /// <param name="requiredPage">Страница для перехода</param>
        public static async void UniversalAnimation(Frame hostFrame, Page requiredPage = null)
        {
            await Task.Run(() =>
            {
                if (IsPlaying)
                {
                    return;
                }

                IsPlaying = true;

                for (double i = 1.0; i >= 0; i -= 0.1)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new Action(() =>
                    {
                        hostFrame.Opacity = i;
                    }));

                    Thread.Sleep(1);
                }

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new Action(() =>
                {
                    if (requiredPage != null)
                    {
                        hostFrame.Navigate(requiredPage);
                    }
                    else
                    {
                        hostFrame.Content = null;

                        while (hostFrame.NavigationService.RemoveBackEntry() != null)
                        {
                            hostFrame.Content = null;
                        }
                    }
                }));

                for (double i = 0.0; i <= 1.0; i += 0.1)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new Action(() =>
                    {
                        hostFrame.Opacity = i;
                    }));

                    Thread.Sleep(1);
                }

                IsPlaying = false;
            });
        }
    }
}
