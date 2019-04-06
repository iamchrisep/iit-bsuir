using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    class Phase
    {
        private readonly double _μ;
        private readonly int _maxQueueCount;

        public int DenialCount;  

        public Phase(double serviceRate, int maxQueueCount){
            _μ = serviceRate;                
            _maxQueueCount = maxQueueCount; 
        }

        public List<double> Imitate(List<double> inputStream){
            Random rnd = new Random(MyRandom.Next() ^ Environment.TickCount);
            double currentTime = 0; 
            int queueCount = 0;
            int denialCount = 0;

            List<double> outputStream = new List<double>();

            int currentRequest = 0;
            while (currentRequest < inputStream.Count){
                if (inputStream[currentRequest] < currentTime){
                    if (queueCount == _maxQueueCount)
                        denialCount++;
                    else queueCount++;

                    currentRequest++;
                }
                else{
                    if (queueCount > 0){
                        currentTime += -Math.Log(rnd.NextDouble())/_μ;
                        queueCount--;
                    }
                    else currentTime = inputStream[currentRequest++] + -Math.Log(rnd.NextDouble())/_μ;
                    
                    outputStream.Add(currentTime);
                }
            }

            DenialCount = denialCount;
            return outputStream;
        }
    }
}
