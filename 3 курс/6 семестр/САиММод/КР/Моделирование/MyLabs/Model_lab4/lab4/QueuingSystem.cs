using System;
using System.Collections.Generic;

namespace lab4
{
    class QueuingSystem
    {
        private readonly double _λ;     
        private Phase _phase1, _phase2;

        public int DenialCount1 { get { return _phase1.DenialCount; } }   
        public int DenialCount2 { get { return _phase2.DenialCount; } }   

        public int DenialCount { get { return DenialCount1 + DenialCount2; } } 

        public int RequestsNumber;    
        public int RequestsNumber2;   

        public double DenialProbability1 { get { return (double)_phase1.DenialCount / RequestsNumber; } }   
        public double DenialProbability2 { get { return (double)_phase2.DenialCount / RequestsNumber2; } }  
        public double DenialProbability { get { return (double)(_phase1.DenialCount + _phase2.DenialCount) / RequestsNumber; } } 

        public QueuingSystem(double λ, double μ1, double μ2, int maxQueueCount1, int maxQueueCount2){
            _phase1 = new Phase(μ1, maxQueueCount1);
            _phase2 = new Phase(μ2, maxQueueCount2);
            _λ = λ;
        }

        public void Imitate(int requestsNumber = 100000){
            RequestsNumber = requestsNumber;
            Random rnd = new Random(MyRandom.Next() ^ Environment.TickCount);

            List<double> requestStream = new List<double>();
            double currentTime = 0;
            requestStream.Add(0);
            for (int i = 1; i < requestsNumber; i++){
                currentTime += -Math.Log(rnd.NextDouble()) / _λ;
                requestStream.Add(currentTime);
            }

            /*Первая фаза*/
            List<double> requestStream2 = _phase1.Imitate(requestStream);
            
            /*Вторая фаза*/
            _phase2.Imitate(requestStream2);

            RequestsNumber2 = requestStream2.Count;
        }
    }
}
