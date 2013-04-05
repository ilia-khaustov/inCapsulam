using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Optimization;

namespace inCapsulam
{
    [Serializable()]
    public class PreDefinedTarget : BlackBox, ITarget
    {
        public const short Parabola = 0;
        public const short Rastrigina = 1;
        public const short Schweifel = 2;
        public const short Sombrero = 3;
        public const short Griewank = 4;
        public const short Rozenbrok = 5;
        public const short ParabolaWithWait = 6;

        public short IdSelected;

        public string Name
        {
            get
            {
                switch (IdSelected)
                {
                    case Parabola:
                        return "Парабола";
                    case Rastrigina:
                        return "Функция Растригина";
                    case Schweifel:
                        return "Функция Швефеля";
                    case Sombrero:
                        return "Функция 'Сомбреро'";
                    case Griewank:
                        return "Функция Гривонка";
                    case Rozenbrok:
                        return "Функция Розенброка";
                    case ParabolaWithWait:
                        return "Парабола с задержкой";
                    default:
                        return "Константа";
                }
            }
        }
        double _Blur;
        public double Blur
        {
            get
            {
                return _Blur;
            }
            set
            {
                _Blur = value;
            }
        }

        public PreDefinedTarget()
        {

        }

        public PreDefinedTarget(short id, short parametersCount)
        {
            IdSelected = id;
            if (id > 2) parametersCount = 2;
            Parameters = new double[parametersCount];
        }

        public override double TargetFunction()
        {
            double error = Various.GenerateNormallyDistributedValue(0, 3 * Blur);
            switch (IdSelected)
            {
                case Parabola:
                    return Function.Parabola(Parameters) + error;
                case Rastrigina:
                    return Function.Rastrigina(Parameters) + error;
                case Schweifel:
                    return Function.Schwefel(Parameters) + error;
                case Sombrero:
                    return Function.Sombrero(Parameters[0], Parameters[1]) + error;
                case Griewank:
                    return Function.Griewank(Parameters[0], Parameters[1]) + error;
                case Rozenbrok:
                    return Function.Rozenbrok(Parameters[0], Parameters[1]) + error;
                case ParabolaWithWait:
                    return Function.ParabolaWithWait(Parameters) + error;
                default:
                    return 0 + error;
            }
        }
    }
}
