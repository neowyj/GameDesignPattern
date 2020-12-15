using System;
using System.Collections.Generic;

namespace SingletonPattern
{
    public class HungrySingleton
    {
        private static HungrySingleton instance = new HungrySingleton();

        private HungrySingleton()
        {

        }

        public static HungrySingleton GetInstance()
        {
            return instance;
        }
    }
}

