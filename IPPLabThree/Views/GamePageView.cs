using IPPLabThree.Models;
using System;
using System.Windows;
using System.Windows.Shapes;

namespace IPPLabThree.Views
{
    public class GamePageView
    {
        private Rectangle itsPlayer;

        public GamePageView(Rectangle player) { itsPlayer = player; }

        public void ChangePositionOfPlayer(ArrowType arrowType)
        {
            itsPlayer.Dispatcher.BeginInvoke(new Action(() =>
            {
                Thickness playerMargin = itsPlayer.Margin;
                if (arrowType == ArrowType.ArrowLeft)
                {
                    if (playerMargin.Left - 100 >= -700)
                        playerMargin.Left -= 100;
                }
                else if (arrowType == ArrowType.ArrowUp)
                {
                    if (playerMargin.Top - 100 >= -400)
                        playerMargin.Top -= 100;
                }
                else if (arrowType == ArrowType.ArrowRight)
                {
                    if (playerMargin.Left + 100 <= 700)
                        playerMargin.Left += 100;
                }
                else
                {
                    if (playerMargin.Top + 100 <= 400)
                        playerMargin.Top += 100;
                }
                itsPlayer.Margin = playerMargin;
            }));
        }
    }
}