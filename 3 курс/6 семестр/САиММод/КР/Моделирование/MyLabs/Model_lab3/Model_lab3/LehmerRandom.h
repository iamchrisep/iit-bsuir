

namespace Model_lab3{
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Text;
    public ref class LehmerRandom
    {
	private: ulong a, m, Rprev, R0;
	public: LehmerRandom(ulong a, ulong m, ulong R0)
        {
            this.a = a;
            this.m = m;
            this.Rprev = R0;
            this.R0 = R0;
        }

	public: double Next()
        {
            Rprev = (a * Rprev) % m;
            return (double)Rprev / m;
        }
    }
}
