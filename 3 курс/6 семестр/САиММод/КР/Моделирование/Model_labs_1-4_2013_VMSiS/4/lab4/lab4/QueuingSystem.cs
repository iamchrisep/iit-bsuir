using System;
using System.Collections.Generic;

namespace lab4
{
    class QueuingSystem
    {
        private readonly double _λ;     // Интенсивность входного потока заявок
        private Phase _phase1, _phase2;

        public int DenialCount1 { get { return _phase1.DenialCount; } }   // Счётчик отказов фазы 1
        public int DenialCount2 { get { return _phase2.DenialCount; } }   // Счётчик отказов фазы 2

        public int DenialCount { get { return DenialCount1 + DenialCount2; } }    // Счётчик отказов

        public int RequestsNumber { get; private set; }    // Количество заявок
        public int RequestsNumber2 { get; private set; }   // Количество заявок, попавшее во 2-ю фазу

        public double DenialProbability1 { get { return (double)_phase1.DenialCount / RequestsNumber; } }   // Вероятность отказа фазы 1
        public double DenialProbability2 { get { return (double)_phase2.DenialCount / RequestsNumber2; } }  // Вероятность отказа фазы 2
        public double DenialProbability { get { return (double)(_phase1.DenialCount + _phase2.DenialCount) / RequestsNumber; } }    // Вероятность отказа

        public QueuingSystem(double λ, double μ1, double μ2, int maxQueueCount1, int maxQueueCount2)
        {
            _phase1 = new Phase(μ1, maxQueueCount1);
            _phase2 = new Phase(μ2, maxQueueCount2);
            _λ = λ;
        }

        public void Imitate(int requestsNumber = 100000)
        {
            RequestsNumber = requestsNumber;
            Random rnd = new Random(RandomProvider.Next() ^ Environment.TickCount);

            // Генерация входящего потока
            List<double> requestStream = new List<double>();
            double currentTime = 0;
            requestStream.Add(0);
            for (int i = 1; i < requestsNumber; i++)
            {
                currentTime += -Math.Log(rnd.NextDouble()) / _λ;
                requestStream.Add(currentTime);
            }

            // 1-я фаза
            List<double> requestStream2 = _phase1.Imitate(requestStream); // Формируем выходной поток / входной поток для 2-й фазы
            
            // 2-я фаза
            _phase2.Imitate(requestStream2);

            RequestsNumber2 = requestStream2.Count;
        }
    }
}
