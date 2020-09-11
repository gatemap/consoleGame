using System;
using System.Diagnostics;

namespace OnlineDay04_01
{
    class TimeCheck
    {
        Stopwatch timer;
        int min = 0;
        
        public TimeCheck()
        {
            timer = new Stopwatch();
            timer.Restart();
        }

        public void TimerPrint()
        {
            timeCheck();
            string str = String.Format("{0:f1}", timer.ElapsedMilliseconds * 0.001);
            if (min < 1)
                Console.Write($"{str}초 ");
            else
                Console.Write($"{min}분 {str}초");
        }

        void timeCheck()
        {
            if(timer.IsRunning)
            {
                if (timer.ElapsedMilliseconds * 0.001 > 60)
                {
                    min++;
                    timer.Restart();
                }
            }
        }
    }
}
